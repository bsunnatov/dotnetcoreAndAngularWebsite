using IdealSysApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdealSysApp.Models.Entities;
using IdealSysApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace IdealSysApp.Server.Services
{
  public class EntityService<T> where T : BaseEntity
  {
    Data.IEntityService<T> repository;
    public EntityService(Data.IEntityService<T> repository)
    {
      this.repository = repository;
    }
  }
}
