using System.ComponentModel;
using System.Reflection;

namespace TerceiroSetor.WebApp.Client.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType()?.GetField(value.ToString());
            DescriptionAttribute[] attributes = fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }
            return value.ToString();
        }

        public static int GetValue(this Enum enumValue)
        {
            return (int)((object)enumValue);
        }

    }
}
