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
  public class EntityService<T> : IEntityService<T> where T : BaseEntity

  {
    private readonly ApplicationDbContext context;
    private DbSet<T> _dbSet;
    string errorMessage = string.Empty;
    private readonly UserManager<AppUser> _userManager;
    public object ViewModel { get; set; }
    public IMapper mapper { get; }
    public ILogger log;
    public IUserResolverService userService;
    public EntityService(ApplicationDbContext context, UserManager<AppUser> userManager, IMapper mapper, ILoggerFactory loggerFactory, IUserResolverService userService)
    {

      this.context = context;
      this._dbSet = context.Set<T>();
      _userManager = userManager;
      this.mapper = mapper;
      this.log = loggerFactory.CreateLogger<EntityService<T>>();
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
        T ent = this.GetById(vm.Id);
        ent = mapper.Map<object, T>(viewModel, ent);
        return ent;
      }
      return mapper.Map<T>(viewModel);
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _dbSet.ToListAsync();
    }
    public IEnumerable<T> GetAll()
    {
      return _dbSet.AsEnumerable();
    }
    public IQueryable<T> AsQueryable()
    {
      return _dbSet.AsNoTracking();
    }
    public IQueryable<T> AsQueryableForUser(string userId = null)
    {
      if (userId == null)
        return _dbSet.AsNoTracking().Where(p => p.IdentityId == userService.GetUserId());
      return _dbSet.AsNoTracking().Where(p => p.IdentityId == userId);
    }
    public IQueryable<T> AsQueryableTrack()
    {
      return _dbSet;
    }
    public T GetById(long id)
    {
      return _dbSet.AsNoTracking().FirstOrDefault(s => s.Id == id);
    }
    public T GetByIdTrack(long id)
    {
      return _dbSet.FirstOrDefault(s => s.Id == id);
    }
    public T Create(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      entity.IdentityId = userService.GetUserId();
      _dbSet.Add(entity);
      context.SaveChanges();
      return entity;
    }
    public T CreateFromViewModel(object viewModel)
    {
      var entity = this.ViewModelToEntity(viewModel);
      return Create(entity);
    }
    public T Update(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      if (ViewModel != null)
      {
        entity = mapper.Map<object, T>(ViewModel, entity);
      }
      entity.ModifiedDate = DateTime.Now;
      try
      {
        context.Entry(entity).State = EntityState.Modified;
      }
      catch 
      {

      }
    
      context.SaveChanges();
      return entity;
    }
    public int Delete(T entity,bool directlyDelete=true)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      _dbSet.Remove(entity);
      if(directlyDelete)
      return context.SaveChanges();
      return 0;
    }

  }
}
