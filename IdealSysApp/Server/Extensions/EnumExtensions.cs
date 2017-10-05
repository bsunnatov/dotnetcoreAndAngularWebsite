using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IdealSysApp
{
  public static class EnumExtensions
  {
    public static string GetEnumDescription(this Enum value)
    {
      FieldInfo fi = value.GetType().GetField(value.ToString());

      DescriptionAttribute[] attributes =
          (DescriptionAttribute[])fi.GetCustomAttributes(
          typeof(DescriptionAttribute),
          false);

      if (attributes != null &&
          attributes.Length > 0)
        return attributes[0].Description;
      else
        return value.ToString();
    }
    public static List<string> GetListOfDescription<T>() where T : struct
    {
      Type t = typeof(T);
      TypeInfo t_i = t.GetTypeInfo();
      return !t_i.IsEnum ? null : Enum.GetValues(t).Cast<Enum>().Select(x => x.GetEnumDescription()).ToList();
    }
  }

}
