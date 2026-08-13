using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelperManager
{
  public static class EnumHelper
  {
    public static string GetEnumDescription(Enum value)
    {
      var field = value.GetType().GetField(value.ToString());
      var attr = field?.GetCustomAttribute<DescriptionAttribute>();
      return attr?.Description ?? value.ToString();
    }
    //public static List<string> GetEnumDescriptions<T>() where T : Enum
    //{
    //  return Enum.GetValues(typeof(T))
    //             .Cast<Enum>()
    //             .Select(x => GetEnumDescription(x))
    //             .ToList();
    //}

    public static TEnum? IntToEnum<TEnum>(int value)
    where TEnum : struct, Enum
    {
      if (Enum.IsDefined(typeof(TEnum), value))
        return (TEnum)(object)value;

      return null;
    }

    public static List<string> GetEnumDescriptions<T>() where T : Enum
    {
      var list = new List<string>();

      foreach (T value in Enum.GetValues(typeof(T)))
      {
        string name = value.ToString();
        FieldInfo? field = typeof(T).GetField(name);
        DescriptionAttribute? attr = field?.GetCustomAttribute<DescriptionAttribute>();

        list.Add(attr?.Description ?? name);
      }

      return list;
    }

    public static string GetDescription(Enum? value)
    {
      if (value == null) return "N/A";

      var field = value.GetType().GetField(value.ToString());
      if (field == null) return value.ToString();

      var attr = field.GetCustomAttribute<DescriptionAttribute>();
      return attr?.Description ?? value.ToString();
    }
  }
}
