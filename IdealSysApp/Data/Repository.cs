﻿using IdealSysApp.Models.Entities;
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

namespace IdealSysApp.Data
{
  public class Repository<T> : IRepository<T> where T : BaseEntity
   
  {
    private readonly ApplicationDbContext context;
    private DbSet<T> entities;
    string errorMessage = string.Empty;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public Repository(ApplicationDbContext context, UserManager<AppUser> userManager,IMapper mapper)
    {
     
      this.context = context;
      this.entities = context.Set<T>();
      _userManager = userManager;
      _mapper = mapper;
      
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
      return entities.AsEnumerable();
    }
    public IQueryable<T> AsQueryable()
    {
      return entities.AsQueryable();
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
      try
      {
        entity.IdentityId = _userManager.GetUserId(ClaimsPrincipal.Current);
      }
      catch (Exception)
      {

       
      }
 
      entities.Add(entity);
      context.SaveChanges();
    }
    public void InsertViewModel(object viewModel)
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
