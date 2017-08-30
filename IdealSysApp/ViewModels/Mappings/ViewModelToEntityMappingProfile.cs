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
      CreateMap<ProductViewModel, Product>();
      CreateMap<DynamicPropertyViewModel, DynamicProperty>();
      CreateMap<DynamicPropertyValueViewModel, DynamicPropertyValue>();
      CreateMap<ProductPropertyViewModel, ProductProperty>();
      CreateMap<ProductImageViewModel, ProductImage>();
      //Entity to ViewModel
      CreateMap<ProductCategory, ProductCategoryViewModel>().ForMember(s=>s.HasChild,m=>m.MapFrom(v=>v.Childs.Any()));
      CreateMap<Product, ProductViewModel>();
      CreateMap<AppUser, UserViewModel>().AfterMap((src, dist) =>
      {
        dist.RoleIds = src.Roles.Select(s => s.RoleId).ToArray();
      }).ForMember(vm => vm.FullName, map => map.MapFrom(au => au.FirstName + " " + au.LastName));
      CreateMap<Storage, StorageViewModel>();
      CreateMap<Product, ProductViewModel>().ForMember(p=>p.ProductImages,m=>m.MapFrom(v=>v.ProductImages));
      CreateMap<DynamicProperty, DynamicPropertyViewModel>();
      CreateMap<DynamicPropertyValue, DynamicPropertyValueViewModel>();
      CreateMap<ProductProperty, ProductPropertyViewModel>();
      CreateMap<ProductImage, ProductImageViewModel>();
      //Integration with 1c ViewModel
      // CreateMap<GoodViewModel, Product>().ForMember(p=>p.goodID,m=>m.MapFrom(vm=>vm.Id));
    }
  }
}
