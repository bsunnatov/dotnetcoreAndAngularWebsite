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
  public interface IRepository<T,ViewModel> where T : BaseEntity
    where ViewModel:IViewModel
  {
    IEnumerable<T> GetAll();
    T Get(long id);
    void Insert(T entity);
    void InsertViewModel(ViewModel entity);
    void Update(T entity);
    void Delete(T entity);
    T ViewModelToEntity(ViewModel viewModel);

  }
}
