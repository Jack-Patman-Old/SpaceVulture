using System;
using System.ComponentModel;
using System.Reflection;

namespace SpaceVulture.Core.Utility.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            
            return value.ToString();
        }
    }
}
