using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdealSysApp.Helpers
{
  public static class Constants
  {
    public static class Strings
    {
      public static class JwtClaimIdentifiers
      {
        public const string Rol = "rol", Id = "id", Roles = "Roles";
      }

      public static class JwtClaims
      {
        public const string ApiAccess = "api_access";
        public const string Administrator = "Administrator";
      }
      public static  class AppSettings
      {
        public static readonly string DefaultPassword = "123456";
      }
    }
  }
}
