using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Orders.API.Utilities
{
    public class EnumUtils<T>
    {
        public static string GetDescription(T enumValue, string defDesc)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());

            var attributes = field?.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attributes != null && attributes.Length > 0)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }
            return defDesc;
        }

        public static string GetDescription(T enumValue)
        {
            return GetDescription(enumValue, string.Empty);
        }

        public static T FromDescription(string description)
        {
            var t = typeof(T);
            foreach (var fi in t.GetFields())
            {
                var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs.Length <= 0) continue;
                foreach (DescriptionAttribute attr in attrs)
                {
                    if (attr.Description.Equals(description))
                    {
                        return (T)fi.GetValue(null);
                    }
                }
            }
            return default(T);
        }

        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }

        public static T GetEnumValue(int intValue)
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }

            var val = ((T[])Enum.GetValues(typeof(T)))[0];

            foreach (var enumValue in (T[])Enum.GetValues(typeof(T)))
            {
                if (!Convert.ToInt32(enumValue).Equals(intValue))
                {
                    continue;
                }
                val = enumValue;
                break;
            }
            return val;
        }

        public static List<T> GetAllEnumValueList()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);

            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }

        public static List<T> GetAllEnumValueList(out List<string> lstEnumDescription)
        {
            Type enumType = typeof(T);
            lstEnumDescription = new List<string>();
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);

            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
                lstEnumDescription.Add(GetDescription((T)Enum.Parse(enumType, val.ToString())));
            }
            return enumValList;
        }

        public static List<string> GetAllEnumDescriptionList()
        {
            Type enumType = typeof(T);
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);

            List<string> lstEnumDescription = new List<string>();

            foreach (int val in enumValArray)
            {
                lstEnumDescription.Add(GetDescription((T)Enum.Parse(enumType, val.ToString())));
            }
            return lstEnumDescription;
        }

        public static List<string> GetAllEnumDescriptionList(List<T> enumsList)
        {
            Type enumType = typeof(T);
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = enumsList.ToArray();

            List<string> lstEnumDescription = new List<string>();

            foreach (int val in enumValArray)
            {
                lstEnumDescription.Add(GetDescription((T)Enum.Parse(enumType, val.ToString())));
            }
            return lstEnumDescription;
        }

        public static string GetDisplayName(T enumValue, string defDesc)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());

            var attributes = field?.GetCustomAttributes(typeof(DisplayAttribute), true);
            if (attributes != null && attributes.Length > 0)
            {
                return ((DisplayAttribute)attributes[0]).Name;
            }
            return defDesc;
        }

        public static string GetDisplayName(T enumValue)
        {
            return GetDisplayName(enumValue, string.Empty);
        }

        public static string GetDisplayDescription(T enumValue, string defDesc)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());

            var attributes = field?.GetCustomAttributes(typeof(DisplayAttribute), true);
            if (attributes != null && attributes.Length > 0)
            {
                return ((DisplayAttribute)attributes[0]).Description;
            }
            return defDesc;
        }

        public static string GetDisplayDescription(T enumValue)
        {
            return GetDisplayDescription(enumValue, string.Empty);
        }
    }
}
