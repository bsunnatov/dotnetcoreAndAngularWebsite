﻿using IdealSysApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;

namespace IdealSysApp.Data
{
  public class Repository<T> : IRepository<T> where T : BaseEntity
  {
    private readonly ApplicationDbContext context;
    private DbSet<T> entities;
    string errorMessage = string.Empty;
    public Repository(ApplicationDbContext context)
    {
      this.context = context;
      entities = context.Set<T>();
    }
    public IEnumerable<T> GetAll()
    {
      return entities.AsEnumerable();
    }
    public T Get(long id)
    {
      return entities.SingleOrDefault(s => s.Id == id);
    }
    public void Insert(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      } 
      entity.CreatedDate = DateTime.Now;
      entity.ModifiedDate = DateTime.Now;
     // entity.IdentityId= 
      entities.Add(entity);
      context.SaveChanges();
    }
    public void Update(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      entity.ModifiedDate = DateTime.Now;
      context.SaveChanges();
    }
    public void Delete(T entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException("entity");
      }
      entities.Remove(entity);
      context.SaveChanges();
    }
  }
}
