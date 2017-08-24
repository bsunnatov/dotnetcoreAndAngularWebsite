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
namespace IdealSysApp.Data
{
  public class Repository<T> : IRepository<T> where T : BaseEntity
   
  {
    private readonly ApplicationDbContext context;
    private DbSet<T> _dbSet;
    string errorMessage = string.Empty;
    private readonly UserManager<AppUser> _userManager;
    public object ViewModel { get; set; }
    public  IMapper _mapper { get; }

    public Repository(ApplicationDbContext context, UserManager<AppUser> userManager,IMapper mapper)
    {
     
      this.context = context;
      this._dbSet = context.Set<T>();
      _userManager = userManager;
      _mapper = mapper;
      
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
    public  T ViewModelToEntity(object viewModel) {
      var vm = (IViewModel)viewModel;
      if (vm.Id > 0)
      {
        T ent = this.Get(vm.Id);
        ent= _mapper.Map<T>(viewModel);
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
    public T Get(long id)
    {
      return _dbSet.AsNoTracking().FirstOrDefault(s => s.Id == id);
    }
    public void Insert(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      entity.CreatedDate = DateTime.Now;
      entity.ModifiedDate = DateTime.Now;
      try
      {
        entity.IdentityId = _userManager.GetUserId(ClaimsPrincipal.Current);
      }
      catch (Exception)
      {

       
      }
 
      _dbSet.Add(entity);
      context.SaveChanges();
    }
    public T InsertViewModel(object viewModel)
    {
      var entity = this.ViewModelToEntity(viewModel);
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      entity.CreatedDate = DateTime.Now;
      entity.ModifiedDate = DateTime.Now;
      try
      {
        entity.IdentityId = _userManager.GetUserId(ClaimsPrincipal.Current);
      }
      catch (Exception)
      {


      }

      _dbSet.Add(entity);
      context.SaveChanges();
      return entity;
    }
    public T Update(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      if (ViewModel != null)
      {
        entity = _mapper.Map<T>(ViewModel);
      }
      entity.ModifiedDate = DateTime.Now;
      context.Entry(entity).State = EntityState.Modified;
      context.SaveChanges();
      return entity;
    }
    public void Delete(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      _dbSet.Remove(entity);
      context.SaveChanges();
    }

  }
}
