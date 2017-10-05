using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using IdealSysApp.Data;
using Microsoft.EntityFrameworkCore;
using IdealSysApp.Models;
using Microsoft.IdentityModel.Tokens;
using IdealSysApp.Auth;
using System.Text;
using IdealSysApp.Helpers;
using IdealSysApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using IdealSysApp.Extensions;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Routing;
using IdealSysApp.ViewModels;
using Microsoft.Extensions.FileProviders;
using IdealSysApp.Services;
using Microsoft.AspNetCore.Identity;
using IdealSysApp.Server.Services;

namespace IdealSysApp
{
  public class Startup
  {
    private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
    private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
    ILogger _logger;
    public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
      _logger = loggerFactory.CreateLogger<Startup>();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      // Add framework services.
      services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
      b => b.MigrationsAssembly("IdealSysApp").MigrationsHistoryTable("_Migrations")));
      services.AddSingleton<IJwtFactory, JwtFactory>();
      var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
      // Configure JwtIssuerOptions
      services.Configure<JwtIssuerOptions>(options =>
      {
        options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
        options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

      });
      // api user claim policy
      //services.AddAuthorization();//Deafult
      services.AddAuthorization(//with custom policy
        options =>
      {
        options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
        ;
      }
      );

      services.AddIdentity<AppUser, AppRole>
          (o =>
          {
            // configure identity options
            o.Password.RequireDigit = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 6;
          })
          .AddEntityFrameworkStores<ApplicationDbContext>()
          .AddDefaultTokenProviders();
      services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
      services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
      //  services.AddScoped<RoleManager<AppRole>>();
      services.AddMvc().AddJsonOptions(o =>
      {
        o.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        o.SerializerSettings.ContractResolver = new DefaultContractResolver();
        o.SerializerSettings.ReferenceLoopHandling =Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      });
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddTransient<IUserResolverService, UserResolverService>();

      services.AddAutoMapper();
      services.AddRouting();
      _logger.LogInformation($"Total Services Initially: {services.Count}");
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddFile("Logs/myapp-{Date}.txt");
      app.SeedData().Wait();
      _logger.LogInformation("Working SeedData");
      app.UseCors(builder => builder
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
      //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      //loggerFactory.AddDebug();
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
      var tokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

        ValidateAudience = true,
        ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = _signingKey,

        RequireExpirationTime = false,
        ValidateLifetime = false,
        ClockSkew = TimeSpan.Zero,

      };
      app.UseJwtBearerAuthentication(new JwtBearerOptions
      {
        AutomaticAuthenticate = true,
        AutomaticChallenge = true,
        TokenValidationParameters = tokenValidationParameters,

      });
      //var myRouteHandler = new RouteHandler(Handle);
      //var routeBuilder = new RouteBuilder(app, myRouteHandler);
      //routeBuilder.MapRoute("default", "");
      //app.UseRouter(routeBuilder.Build());
      app.UseDefaultFiles();
      app.UseStaticFiles();// For the wwwroot folder

      app.UseStaticFiles(new StaticFileOptions()
      {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"Uploads")),//Dostup k Folder static file
        RequestPath = new PathString("/Uploads")
      });
      app.UseDirectoryBrowser(new DirectoryBrowserOptions()
      {
        FileProvider = new PhysicalFileProvider(
           Path.Combine(Directory.GetCurrentDirectory(), @"Uploads")),
        RequestPath = new PathString("/Uploads")
      });
      app.UseMvc();
      app.Use(async (context, next) =>//Per request handling
      {
        await next();
        _logger.LogInformation("Working peer request");
        if (context.Response.StatusCode == 404
                  && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("api"))
        {
          context.Request.Path = "/index.html";
          context.Response.StatusCode = 200;
          await next();
        }
      });

    }
    // собственно обработчик маршрута
    private async Task Handle(HttpContext context)
    {
      await context.Response.WriteAsync("Hello ASP.NET Core! Service is working!!!");
    }
  }
}
