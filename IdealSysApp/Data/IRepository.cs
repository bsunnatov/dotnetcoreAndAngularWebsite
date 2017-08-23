using IdealSysApp.Models.Entities;
using IdealSysApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    void InsertViewModel(object entity);
    void Update(T entity);
    void Delete(T entity);
    T ViewModelToEntity(object viewModel);

  }
}
