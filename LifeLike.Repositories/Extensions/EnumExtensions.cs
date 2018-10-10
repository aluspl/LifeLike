
using System;

namespace LifeLike.Repositories.Extensions
{
 public static class EnumExtensions
    {
        public  static T ToEnum<T>(this string value, T defaultValue)  where T : struct, IComparable
        {            
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            return defaultValue;
        }
    }
}