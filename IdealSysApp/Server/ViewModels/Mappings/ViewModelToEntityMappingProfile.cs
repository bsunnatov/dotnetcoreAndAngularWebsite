using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdealSysApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdealSysApp.Data;
using IdealSysApp.Server.ViewModels;
using IdealSysApp.Server.Entities;

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
      CreateMap<OrderViewModel, Order>().ForMember(s => s.OrderItems, m => m.MapFrom(a => a.OrderItems));
      CreateMap<OrderItemViewModel, OrderItem>();
      CreateMap<CustomerViewModel, Customer>();
      //Entity to ViewModel
      CreateMap<ProductCategory, ProductCategoryViewModel>()
        .ForMember(s => s.HasChild, m => m.MapFrom(v => v.Childs.Any()))
        .ForMember(s => s.PropertyInProductCategories, m => m.MapFrom(a => a.PropertyInProductCategories));
      CreateMap<Product, ProductViewModel>();
      CreateMap<AppUser, UserViewModel>().AfterMap((src, dist) =>
      {
        dist.RoleIds = src.Roles.Select(s => s.RoleId).ToArray();
      }).ForMember(vm => vm.FullName, map => map.MapFrom(au => au.FirstName + " " + au.LastName));
      CreateMap<Storage, StorageViewModel>();
      CreateMap<Product, ProductViewModel>().ForMember(p => p.ProductImages, m => m.MapFrom(v => v.ProductImages));
      CreateMap<DynamicPropertyValue, DynamicPropertyValueViewModel>();
      CreateMap<PropertyInProductCategory, PropertyInProductCategoryViewModel>();
      CreateMap<DynamicProperty, DynamicPropertyViewModel>().ForMember(s => s.DynamicPropertyValues, m => m.MapFrom(a => a.DynamicPropertyValues));

      CreateMap<ProductProperty, ProductPropertyViewModel>().ForMember(m => m.Key, map => map.MapFrom(s => s.DynamicProperty.Key)).ForMember(m => m.DynamicPropertyValues, map => map.MapFrom(s => s.DynamicProperty.DynamicPropertyValues));
      CreateMap<ProductImage, ProductImageViewModel>();
      CreateMap<ProductCategory, Select2ViewModel>().AfterMap((src, dist) =>
      {
        dist.children = src.Childs.Any()?src.Childs.Select(RecursiveSelect).ToList():null;
      }).ForMember(p => p.text, m => m.MapFrom(s => s.Name));
      CreateMap<Customer, CustomerViewModel>();
      CreateMap<Order, OrderViewModel>().ForMember(m => m.CustomerObject, map => map.MapFrom(e => e.Customer)); 
      CreateMap<OrderItem, OrderItemViewModel>()
        .ForMember(m => m.ProductObject, map => map.MapFrom(e => e.Product));
      //Integration with 1c ViewModel
      // CreateMap<GoodViewModel, Product>().ForMember(p=>p.goodID,m=>m.MapFrom(vm=>vm.Id));
    }
    public Select2ViewModel InternalSelect(ProductCategory ent)
    {
      // ent.Childs.Select(RecursiveSelect);
      return new Select2ViewModel
      {
        id = ent.Id,
        text = ent.Name,
        children = ent.Childs.Any() ? ent.Childs.Select(RecursiveSelect).ToList() : null
      };

    }
    public Select2ViewModel RecursiveSelect(ProductCategory ent)
    {
      return this.InternalSelect(ent);
    }
  }
}


