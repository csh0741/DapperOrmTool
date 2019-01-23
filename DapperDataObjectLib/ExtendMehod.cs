using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DapperDataObjectLib
{
    public static class ExtendMehod
    {
        public static DataTable IEnumerableToTable<T>(this IEnumerable<T> paramlist)
        {
            DataTable dt = new DataTable();
            bool schemaIsBuild = false;
            System.Reflection.PropertyInfo[] props = null;
            if (!schemaIsBuild)
            {
                props = typeof(T).GetProperties();                
                foreach (var p in props)
                {
                    Type propType = p.PropertyType;
                    if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        propType = Nullable.GetUnderlyingType(propType);
                    }
                    dt.Columns.Add(new DataColumn(p.Name, propType));
                }
                schemaIsBuild = true;
            }
            foreach (object item in paramlist)
            {
                var row = dt.NewRow();
                foreach (var pi in props)
                {
                    if (pi.GetValue(item, null) == null)
                    {
                        row[pi.Name] = DBNull.Value;
                    }
                    else
                    {
                        row[pi.Name] = pi.GetValue(item, null);
                    }
                }
                dt.Rows.Add(row);
            }
            dt.TableName = "InputTable";
            return dt;
        }
    }
}
