using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.Utils
{
    public static class EnumUtil
    {
        public static T[] Values<T>()
            where T : struct
        {
            var values = Enum.GetValues(typeof(T));
            return values.Cast<T>().ToArray();
        }

        public static T ParseAs<T>(string text)
            where T : struct
        {
            T result;
            if (!Enum.TryParse(text, out result))
            {
                return default(T);
            }
            return result;
        }

        public static string EnumFieldDisplayName(this Enum value)
        {
            var type = value.GetType();
            var name = value.ToString("G");
            var field = type.GetTypeInfo().GetField(name);
            var attr =
                field?.GetCustomAttributes(typeof(EnumFieldDisplayAttribute), false)
                    .Cast<EnumFieldDisplayAttribute>()
                    .FirstOrDefault();
            return attr?.Name ?? name;
        }

        public static string EnumFieldDisplayNames(Type type, object value)
        {
            List<string> list = new List<string>();
            var enums = Enum.GetValues(type);
            string text = string.Empty;
            foreach (Enum e in enums)
            {
                text = e.EnumFieldDisplayName();
                if (text == "无效状态") continue;
                if (e.HasFlag(value))
                {
                    list.Add(text);
                }
            }
            return string.Join("、", list);
        }

        public static bool HasFlag(this Enum uType, object value)
        {
            return ((int)value & (int)uType.EnumValue()) == (int)uType.EnumValue();
        }

        public static object EnumValue(this Enum type)
        {
            return (object)type;
        }

    }

    [AttributeUsage(AttributeTargets.Field)]
    public class EnumFieldDisplayAttribute : Attribute
    {
        public EnumFieldDisplayAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }

    public enum DefaultEnum
    {
        [EnumFieldDisplay("无效")]
        Empty = 0,
    }

}
