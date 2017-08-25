using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdealSysApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdealSysApp.Data;

namespace IdealSysApp.ViewModels.Mappings
{
  public class AutoMapperProfileConfiguration : Profile
  {

    public AutoMapperProfileConfiguration()
    {
      //ViewModel to Entity
      CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
      CreateMap<UserViewModel, AppUser>();
      CreateMap<ProductCategoryViewModel, ProductCategory>();
      CreateMap<StorageViewModel, Storage>();
      //Entity to ViewModel
      CreateMap<ProductCategory, ProductCategoryViewModel>();
      CreateMap<Product, ProductViewModel>();
      CreateMap<AppUser, UserViewModel>().AfterMap((src, dist) =>
      {
        dist.RoleIds = src.Roles.Select(s => s.RoleId).ToArray();
      }).ForMember(vm => vm.FullName, map => map.MapFrom(au => au.FirstName + " " + au.LastName));
      CreateMap<Storage, StorageViewModel>();
      //Integration with 1c ViewModel
      // CreateMap<GoodViewModel, Product>().ForMember(p=>p.goodID,m=>m.MapFrom(vm=>vm.Id));
    }
  }
}
