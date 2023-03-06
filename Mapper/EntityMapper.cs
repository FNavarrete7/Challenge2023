using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace Mapper
{
    public static class EntityMapper
    {
        public static T2 Map<T1, T2>(this T1 entity1)
        {
            if (entity1 == null)
                return default;

            var entity2 = Activator.CreateInstance<T2>();
            foreach (PropertyInfo property in entity1.GetType().GetProperties())
            {
                PropertyInfo property2 = entity2.GetType().GetProperty(property.Name);
                if (property2 != null)
                    property2.SetValue(entity2, property.GetValue(entity1));
            }
            return entity2;
        }

        public static IList<T2> MapList<T1, T2>(this IList<T1> entityList1)
        {
            if (entityList1 == null)
                return default(List<T2>);

            T2 entity2;
            List<T2> entityList2 = new List<T2>();
            foreach (T1 entity in entityList1)
            {
                entity2 = Activator.CreateInstance<T2>();
                foreach (var property in entity.GetType().GetProperties())
                {
                    PropertyInfo property2 = entity2.GetType().GetProperty(property.Name);
                    if (property2 != null)
                        property2.SetValue(entity2, property.GetValue(entity));
                }
                entityList2.Add(entity2);
            }
            return entityList2;
        }

        public static IList<LogsDTO> MapListLogs<Logs, LogsDTO>(this IList<Logs> entityList1)
        {
            if (entityList1 == null)
                return default(List<LogsDTO>);

            LogsDTO entity2;
            List<LogsDTO> entityList2 = new List<LogsDTO>();
            foreach (Logs entity in entityList1)
            {
                entity2 = Activator.CreateInstance<LogsDTO>();
                foreach (var property in entity.GetType().GetProperties())
                {
                    PropertyInfo property2 = entity2.GetType().GetProperty(property.Name);
                    if (property2 != null)
                    {
                        if (property2.Name == "Properties")
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.LoadXml(property.GetValue(entity).ToString());
                            XmlNodeList nodes = doc.GetElementsByTagName("property");
                            property2.SetValue(entity2, property.GetValue(entity));

                            foreach (XmlNode n in nodes)
                            {
                                property2 = entity2.GetType().GetProperty(n.Attributes[0].Value);
                                property2.SetValue(entity2, n.InnerXml);
                            }
                        }
                        else

                            property2.SetValue(entity2, property.GetValue(entity));
                    }
                }
                entityList2.Add(entity2);
            }
            return entityList2;
        }
    }
}
