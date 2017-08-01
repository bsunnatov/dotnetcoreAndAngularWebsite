using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IdealSysApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace IdealSysApp.ViewModels.Mappings
{
  public class AutoMapperProfileConfiguration : Profile
  {
    public AutoMapperProfileConfiguration()
    {
      CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
      CreateMap<UserViewModel,AppUser>();
      CreateMap<AppUser, UserViewModel>().AfterMap((src,dist)=> {

        dist.Roles = src.Roles.Select(s => s.RoleId).ToArray();
      }).ForMember(vm=>vm.FullName,map=>map.MapFrom(au=>au.FirstName+" "+ au.LastName));
      //CreateMap<IList<AppUser>, IList<UserViewModel>>();
    }
  }
}
