using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace CareerCloudCore.UnitTests.Assignment1
{
    public static class GetCharacteristics
    {
        public static Type GetType(Type[] types, string name)
        {
            Type type = types.Where(t => t.Name == name).FirstOrDefault();
            if (type == null)
            {
                Assert.Fail($"Type {name} not found.");
            }
            return type;
        }

        public static PropertyInfo GetProperty(Type t, string propName)
        {
            PropertyInfo propInfo = t.GetProperties().Where(i => i.Name == propName).FirstOrDefault();
            if (propInfo == null)
            {
                Assert.Fail($"{propName} not found for {t.Name}");
            }
            return propInfo;
        }

        public static bool GetPropertyType(Type t, Type propType, string propName)
        {
            PropertyInfo propinfo = GetProperty(t, propName);
            return propinfo.PropertyType == propType;
        }

        public static bool HasTable(Type type, string name)
        {
            var tableAttrib = (TableAttribute)type.GetCustomAttribute(typeof(TableAttribute));
            if (tableAttrib == null)
            {
                Assert.Fail($"Table attribute not found {name}");
            }
            return string.Equals(name, tableAttrib.Name);
        }

        public static bool HasKey(PropertyInfo prop)
        {
            return Attribute.IsDefined(prop, typeof(KeyAttribute));
        }

        public static bool HasColumn(PropertyInfo prop, string name)
        {
            if (!Attribute.IsDefined(prop, typeof(ColumnAttribute)))
            {
                return false;
            }
            var attrib = (ColumnAttribute)prop.GetCustomAttributes(typeof(ColumnAttribute), false).FirstOrDefault();
            return string.Equals(name, attrib.Name);
        }

        public static bool ImplementsInterface(Type type, string interfaceName)
        {
            return type.GetInterfaces().Any(t => t.Name == interfaceName);
        }
    }
}
