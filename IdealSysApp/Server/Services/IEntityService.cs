using IdealSysApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Server.Services
{
  public interface IEntityService<T>
  {
    IEntityService<T> repository { get; set; }
  }
}
