﻿using System;
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
namespace IdealSysApp
{
  public class Startup
  {
    private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
    private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
      {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
      }));
      // Add framework services.
      services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
      b => b.MigrationsAssembly("IdealSysApp")));
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
      services.AddAuthorization(options =>
      {
        options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
      });

      services.AddIdentity<AppUser, IdentityRole>
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

      services.AddMvc();
      services.AddAutoMapper();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      app.UseCors("MyPolicy");
      loggerFactory.AddConsole();
   
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      //app.UseExceptionHandler(
      //      builder =>
      //      {
      //        builder.Run(
      //          async context =>
      //          {
      //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      //            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
      //            var error = context.Features.Get<IExceptionHandlerFeature>();
      //            if (error != null)
      //            {
      //              context.Response.AddApplicationError(error.Error.Message);
      //              await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
      //            }
      //          });
      //      });
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
        ClockSkew = TimeSpan.Zero
      };

      app.UseJwtBearerAuthentication(new JwtBearerOptions
      {
        AutomaticAuthenticate = true,
        AutomaticChallenge = true,
        TokenValidationParameters = tokenValidationParameters
      });
      app.Use(async (context, next) =>
      {
        await next();

        if (context.Response.StatusCode == 404
                  && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("api"))
        {
          context.Request.Path = "/index.html";
          context.Response.StatusCode = 200;
          await next();
        }
      });
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseMvc();
    }
  }
}
