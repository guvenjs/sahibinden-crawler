using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Pragma.AdminCoreMvc.Helper
{
    public static class CustomHelper
    {
        public static string SafeSubstring(this string text, int start, int length)
        {
            if (text == null) return null;

            return text.Length <= start ? ""
                : text.Length - start <= length ? text.Substring(start).Trim()
                : text.Substring(start, length).Trim() + "...";
        }

        public static string GetEnumDisplayName(this Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}
