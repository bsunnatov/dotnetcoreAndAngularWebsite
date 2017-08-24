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
    T Get(long id);
    void Insert(T entity);
    T InsertViewModel(object entity);
    T Update(T entity);
    void Delete(T entity);
    IMapper _mapper { get; }
    object ViewModel { get; set; }
    IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);
    IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
  }
}
