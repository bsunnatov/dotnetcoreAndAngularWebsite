using AutoMapper;
using IdealSysApp.Models.Entities;
using IdealSysApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace IdealSysApp.Data
{
  public interface IEntityService<T> 
  {
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> GetAll();
    IQueryable<T> AsQueryable();
    IQueryable<T> AsQueryableForUser(string userId=null);
    IQueryable<T> AsQueryableTrack();
    T GetById(long id);
    T GetByIdTrack(long id);
    T Create(T entity);
    T CreateFromViewModel(object entity);
    T Update(T entity);
    int Delete(T entity,bool directlyDelete=true);
    IMapper mapper { get; }
    object ViewModel { get; set; }
    IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
    IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
  }
}
