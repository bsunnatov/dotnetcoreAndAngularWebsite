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
  public interface IRepository<T> 
  {
    IEnumerable<T> GetAll();
    IQueryable<T> AsQueryable();
    IQueryable<T> AsQueryableTrack();
    T Get(long id);
    T GetTrack(long id);
    T Insert(T entity);
    T InsertViewModel(object entity);
    T Update(T entity);
    int Delete(T entity);
    IMapper _mapper { get; }
    object ViewModel { get; set; }
    IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
    IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
  }
}
