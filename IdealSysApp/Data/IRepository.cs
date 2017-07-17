using IdealSysApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace IdealSysApp.Data
{
  public interface IRepository<T> where T : BaseEntity
  {
    IEnumerable<T> GetAll();
    T Get(long id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
  }
}
