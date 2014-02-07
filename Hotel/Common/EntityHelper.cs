using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Common
{
    /// <summary>
    /// 模块号：
    /// 作用：把行数据转换成数据实体
    /// 作者：lb
    /// 日期：2012-04-24
    /// 说明：把行数据转换成数据实体
    /// 修改：noly
    /// </summary>
    public class EntityHelper
    {
        /// <summary>
        /// 根据数据表生成相应的实体对象列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="srcDT">数据</param>
        /// <param name="relation">数据库表列名与对象属性名对应关系；如果列名与实体对象属性名相同，该参数可为空</param>
        /// <returns>对象列表</returns>
        public static List<T> GetEntityListByDT<T>(DataTable srcDT, Hashtable relation)
        {
            List<T> list = null;
            T destObj = default(T);

            if (srcDT != null && srcDT.Rows.Count > 0)
            {
                list = new List<T>();
                foreach (DataRow row in srcDT.Rows)
                {
                    destObj = GetEntityListByDT<T>(row, relation);
                    list.Add(destObj);
                }
            }

            return list;
        }

        /// <summary>
        ///  将SqlDataReader转换成数据实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="relation"></param>
        /// <returns></returns>
        public static T GetEntityListByDT<T>(SqlDataReader dr)
        {
            Type type = typeof(T);
            T destObj = Activator.CreateInstance<T>();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                try
                {
                    if (dr[prop.Name] != null && dr[prop.Name] != DBNull.Value)
                    {
                        SetPropertyValue(prop, destObj, dr[prop.Name]);
                    }
                }
                catch
                {
                }
            }
            return destObj;
        }

        /// <summary>
        ///  将数据行转换成数据实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static T GetEntityListByDT<T>(DataSet ds)
        {
            Type type = typeof(T);
            T destObj = Activator.CreateInstance<T>();

            try
            {
                DataRow row = ds.Tables[0].Rows[0];
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    if (row.Table.Columns.Contains(prop.Name) &&
                        row[prop.Name] != DBNull.Value)
                    {
                        SetPropertyValue(prop, destObj, row[prop.Name]);
                    }
                }
            }
            catch (Exception)
            {
            }

            return destObj;
        }

        /// <summary>
        ///  将数据行转换成数据实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="relation"></param>
        /// <returns></returns>
        public static T GetEntityListByDT<T>(DataRow row, Hashtable relation)
        {
            Type type = typeof(T);
            T destObj = Activator.CreateInstance<T>();
            PropertyInfo temp = null;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (row.Table.Columns.Contains(prop.Name) &&
                    row[prop.Name] != DBNull.Value)
                {
                    SetPropertyValue(prop, destObj, row[prop.Name]);
                }
            }

            if (relation != null)
            {
                foreach (string name in relation.Keys)
                {
                    temp = type.GetProperty(relation[name].ToString());
                    if (temp != null &&
                        row[name] != DBNull.Value)
                    {
                        SetPropertyValue(temp, destObj, row[name]);
                    }
                }
            }

            return destObj;
        }

        /// <summary>
        ///  将多数据行转换成数据实体列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="relation"></param>
        /// <returns></returns>
        public static List<T> GetEntityListByDT<T>(DataRow[] rows, Hashtable relation)
        {
            List<T> list = null;
            T destObj = default(T);

            if (rows != null && rows.Length > 0)
            {
                list = new List<T>();
                foreach (DataRow row in rows)
                {
                    destObj = GetEntityListByDT<T>(row, relation);
                    list.Add(destObj);
                }
            }

            return list;
        }

        /// <summary>
        /// 将数据集转换成数据实体列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ds"></param>
        /// <param name="relation"></param>
        /// <returns></returns>
        public static List<T> GetEntityListByDT<T>(DataSet ds, Hashtable relation)
        {
            DataRowCollection drClec = ds.Tables[0].Rows;
            List<DataRow> drList = new List<DataRow>();
            foreach (DataRow dr in drClec)
            {
                drList.Add(dr);
            }
            return GetEntityListByDT<T>(drList.ToArray(), relation);
        }

        /// <summary>
        /// 为对象的属性赋值
        /// </summary>
        /// <param name="prop">属性</param>
        /// <param name="destObj">目标对象</param>
        /// <param name="value">源值</param>
        private static void SetPropertyValue(PropertyInfo prop, object destObj, object value)
        {
            object temp = ChangeType(prop.PropertyType, value);
            prop.SetValue(destObj, temp, null);
        }

        /// <summary>
        /// 用于类型数据的赋值
        /// </summary>
        /// <param name="type">目标类型</param>
        /// <param name="value">原值</param>
        /// <returns></returns>
        private static object ChangeType(Type type, object value)
        {
            int temp = 0;
            if ((value == null) && type.IsGenericType)
            {
                return Activator.CreateInstance(type);
            }
            if (value == null)
            {
                return null;
            }
            if (type == value.GetType())
            {
                return value;
            }
            if (type.IsEnum)
            {
                if (value is string)
                {
                    return Enum.Parse(type, value as string);
                }
                return Enum.ToObject(type, value);
            }

            if (type == typeof(bool) && typeof(int).IsInstanceOfType(value))
            {
                temp = int.Parse(value.ToString());
                return temp != 0;
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                Type type1 = type.GetGenericArguments()[0];
                object obj1 = ChangeType(type1, value);
                return Activator.CreateInstance(type, new object[] { obj1 });
            }
            if ((value is string) && (type == typeof(Guid)))
            {
                return new Guid(value as string);
            }
            if ((value is string) && (type == typeof(Version)))
            {
                return new Version(value as string);
            }
            if (!(value is IConvertible))
            {
                return value;
            }
            return Convert.ChangeType(value, type);
        }

        /// <summary>
        /// 判断DataSet默认表是否为空:true:不为空 false:为空。
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static bool CheckDataSet(DataSet ds)
        {
            bool isNull = CheckDataSet(ds, 0);
            return isNull;
        }

        /// <summary>
        /// 判断DataSet指定索引表是否为空:true:不为空 false:为空。
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <param name="tableIndex">表的索引值</param>
        /// <returns></returns>
        public static bool CheckDataSet(DataSet ds, int tableIndex)
        {
            bool isNull = false;
            if (ds != null && ds.Tables != null && ds.Tables.Count > tableIndex && ds.Tables[tableIndex] != null && ds.Tables[tableIndex].Rows != null && ds.Tables[tableIndex].Rows.Count > 0)
            {
                isNull = true;
            }
            return isNull;
        }

        /// <summary>
        /// 将集合类转换成DataTable
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static DataTable GetDataTableByList(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <returns>数据集(表)</returns>
        public static DataTable GetDataTableByList<T>(IList<T> list)
        {
            return EntityHelper.GetDataTableByList<T>(list, null);
        }

        /// <summary>
        /// 将泛型集合类转换成DataTable
        /// </summary>
        /// <typeparam name="T">集合项类型</typeparam>
        /// <param name="list">集合</param>
        /// <param name="propertyName">需要返回的列的列名</param>
        /// <returns>数据集(表)</returns>
        public static DataTable GetDataTableByList<T>(IList<T> list, params string[] propertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (propertyName != null)
                propertyNameList.AddRange(propertyName);
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            result.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(list[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(list[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        /// <summary>
        /// 将泛型对象转化为属性对应的对象数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static object[] ConvertEntity2ObjectArray<T>(T t)
        {
            Type type = typeof(T);
            int length = type.GetProperties().Length;
            object[] objs = new object[length];
            int i = 0;
            foreach (PropertyInfo prop in type.GetProperties())
            {
                objs[i] = prop.GetValue(t, null);
                i++;
            }
            return objs;
        }

        /// <summary>
        /// 将ArrayList对象类型转化为泛型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static T ConvertArrayListObject2Entity<T>(object obj)
        {
            T destObj = Activator.CreateInstance<T>();
            try
            {
                ArrayList objs = (ArrayList)obj;
                Type type = typeof(T);
                int i = 0;
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    prop.SetValue(destObj, objs[i], null);
                    i++;
                }
            }
            catch
            { }
            return destObj;
        }
    }
}