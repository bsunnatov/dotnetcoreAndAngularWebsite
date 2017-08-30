using IdealSysApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using IdealSysApp.ViewModels;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using IdealSysApp.Services;
namespace IdealSysApp.Data
{
  public class Repository<T> : IRepository<T> where T : BaseEntity

  {
    private readonly ApplicationDbContext context;
    private DbSet<T> _dbSet;
    string errorMessage = string.Empty;
    private readonly UserManager<AppUser> _userManager;
    public object ViewModel { get; set; }
    public IMapper _mapper { get; }
    public ILogger log;
    public IUserResolverService userService;
    public Repository(ApplicationDbContext context, UserManager<AppUser> userManager, IMapper mapper, ILoggerFactory loggerFactory, IUserResolverService userService)
    {

      this.context = context;
      this._dbSet = context.Set<T>();
      _userManager = userManager;
      _mapper = mapper;
      this.log = loggerFactory.CreateLogger<Repository<T>>();
      this.userService = userService;

    }
    public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
    {
      return Include(includeProperties).ToList();
    }

    public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
        params Expression<Func<T, object>>[] includeProperties)
    {
      var query = Include(includeProperties);
      return query.Where(predicate).ToList();
    }

    private IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
    {
      IQueryable<T> query = _dbSet.AsNoTracking();
      return includeProperties
          .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
    public T ViewModelToEntity(object viewModel)
    {
      var vm = (IViewModel)viewModel;
      if (vm.Id > 0)
      {
        T ent = this.Get(vm.Id);
        ent = _mapper.Map<object, T>(viewModel, ent);
        return ent;
      }
      return _mapper.Map<T>(viewModel);
    }
    public IEnumerable<T> GetAll()
    {
      return _dbSet.AsEnumerable();
    }
    public IQueryable<T> AsQueryable()
    {
      return _dbSet.AsNoTracking();
    }
    public IQueryable<T> AsQueryableTrack()
    {
      return _dbSet;
    }
    public T Get(long id)
    {
      return _dbSet.AsNoTracking().FirstOrDefault(s => s.Id == id);
    }
    public T GetTrack(long id)
    {
      return _dbSet.FirstOrDefault(s => s.Id == id);
    }
    public T Insert(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      try
      {
        entity.IdentityId = this.userService.GetUserId();
      }
      catch (Exception ex)
      {
        entity.IntegrationKey = ex.Message;
        log.LogError(ex.Message);
      }

      _dbSet.Add(entity);
      context.SaveChanges();
      return entity;
    }
    public T InsertViewModel(object viewModel)
    {
      var entity = this.ViewModelToEntity(viewModel);
      return Insert(entity);
    }
    public T Update(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      if (ViewModel != null)
      {
        entity = _mapper.Map<object, T>(ViewModel, entity);
      }
      entity.ModifiedDate = DateTime.Now;
      context.Entry(entity).State = EntityState.Modified;
      context.SaveChanges();
      return entity;
    }
    public int Delete(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      _dbSet.Remove(entity);
      return context.SaveChanges();
    }

  }
}
