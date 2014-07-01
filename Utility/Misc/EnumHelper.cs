using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Utility.Misc
{
    public static class EnumHelper
    {
        public static T GetEnumAttribute<T>(Enum source) where T : Attribute
        {
            Type type = source.GetType();
            var sourceName = Enum.GetName(type, source);
            if (sourceName == null)
                return null;
            FieldInfo field = type.GetField(sourceName);
            object[] attributes = field.GetCustomAttributes(typeof(T), false);
            return attributes.OfType<T>().FirstOrDefault();
        }

        public static string GetDescription(Enum source)
        {
            var attr = GetEnumAttribute<DescriptionAttribute>(source);
            if (attr == null)
                return null;
            return attr.Description;
        }

        public static string GetDescriptionByCulture(Enum source)
        {
            var attr = GetEnumAttribute<DescriptionAttribute>(source);
            if (attr == null)
                return null;
            string desName = attr.Description;
            return DBEntity.EnumEntity.ResEnumEntity.ResourceManager.GetString(desName);
        }

        public static Dictionary<string, int> GetEnumDic<T>(Dictionary<string, int> enumDic)
        {
            foreach (string s in Enum.GetNames(typeof(T)))
            {
                var value = (int) Enum.Parse(typeof(T), s);
                var item = (Enum) Enum.ToObject(typeof (T), value);
                string description = GetDescriptionByCulture(item) ?? string.Empty;
                enumDic.Add(description,value);
            }
            return enumDic;
        } 

        public static List<EnumItem> GetEnumList<T>()
        {
            var enumList = new List<EnumItem>();
            foreach (string s in Enum.GetNames(typeof(T)))
            {
                var value = (int)Enum.Parse(typeof(T), s);
                var item = (Enum)Enum.ToObject(typeof(T), value);
                string description = GetDescriptionByCulture(item);
                enumList.Add(new EnumItem{Id = value, Name = description});
            }
            return enumList;
        }

        public static Dictionary<string, int> GetEnumDic<T>()
        {
            var enumDic = new Dictionary<string, int>();
            foreach (string s in Enum.GetNames(typeof(T)))
            {
                var value = (int)Enum.Parse(typeof(T), s);
                var item = (Enum)Enum.ToObject(typeof(T), value);
                string description = GetDescriptionByCulture(item);
                enumDic.Add(description, value);
            }
            return enumDic;
        }

        public static String GetDesByValue<T>(int value)
        {
            var item = (Enum)Enum.ToObject(typeof(T), value);
            return GetDescriptionByCulture(item);
        }

        public static int GetValueByDes<T>(string des)
        {
            var list= GetEnumList<T>();
            return (from item in list where item.Name == des select item.Id).FirstOrDefault();
        }

        public static EnumItem GetEnumItem<T>(int value)
        {
            return new EnumItem{Id =  value, Name = GetDesByValue<T>(value)};
        }
    }
}
