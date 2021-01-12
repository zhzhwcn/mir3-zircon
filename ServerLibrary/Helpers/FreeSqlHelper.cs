using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using FreeSql;
using MirDB;
using Server.Envir;

namespace Server.Helpers
{
    public static class FreeSqlHelper
    {
        public static void ConfigType(Type type, string index = "Index")
        {
            SEnvir.FreeSql.CodeFirst.ConfigEntity(type, fluent =>
            {
                var propList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var indexProp = propList.FirstOrDefault(p => p.Name == index);
                if (indexProp == null)
                {
                    throw new ArgumentException("missing index property", nameof(index));
                }

                fluent.Property(indexProp.Name).IsIdentity(true);
                foreach (var propertyInfo in propList)
                {
                    if (Attribute.IsDefined(propertyInfo, typeof(IgnoreProperty)))
                    {
                        fluent.Property(propertyInfo.Name).IsIgnore(true);
                    }
                }
            });
        }
    }
}
