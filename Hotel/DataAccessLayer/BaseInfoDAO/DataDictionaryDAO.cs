using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BusinessEntity;
using Common;
using BusinessEntity.Model;
namespace DataAccessLayer
{
    /// 模块：
    /// 作用：数据访问类:字典DataDictionaryDAO
    /// 作者：phq
    /// 日期：2011-12-28
    /// 说明：
    public partial class DataDictionaryDAO
    {
        /// <summary>
        /// 获取数据字典model
        /// </summary>
        /// <param name="dataDictionaryID"></param>
        /// <returns></returns>
        public DataDictionary GetDataDictionaryModel(Guid dataDictionaryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from T_Dictionary ");
            strSql.Append(" where DataDictionaryID=@DataDictionaryID");
            SqlParameter[] parameters = {
					new SqlParameter("@DataDictionaryID", SqlDbType.UniqueIdentifier)
             };
            parameters[0].Value = dataDictionaryID;

            DataDictionary model = new DataDictionary();
            DataSet ds = new DbHelperSQL().Query(strSql.ToString(), parameters);
            model = EntityHelper.GetEntityListByDT<DataDictionary>(ds);
            return model;
        }
        /// <summary>
        /// 获取数据字典list
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<DataDictionary> GetDataDictionaryList(string DataDictionaryType)
        {

            StringBuilder strSql = new StringBuilder();
            List<SqlParameter> parameters = new List<SqlParameter>();
            strSql.Append("select a.* from T_Dictionary a ");
            //strSql.Append("left join T_Employee b on a.OperateID=b.EmployeeID");
            if (DataDictionaryType == "all")
            {
               // strSql.Append(" where a.State=1");
            }
            else
            {
                strSql.Append(" where DataDictionaryType=@DataDictionaryType");
                parameters.Add(new SqlParameter("@DataDictionaryType", SqlDbType.VarChar));
                parameters[0].Value = DataDictionaryType;
            }

            SqlDataReader dr = null;
            List<DataDictionary> lisT_Dictionary = new List<DataDictionary>();
            try
            {
                dr = new DbHelperSQL().ExecuteReader(strSql.ToString(), parameters.ToArray());
                while (dr.Read())
                {
                    lisT_Dictionary.Add(EntityHelper.GetEntityListByDT<DataDictionary>(dr));
                }
                return lisT_Dictionary;
            }
            catch (SqlException ex)
            {

                throw new HotelException("获取数据字典列表失败", ex);
            }
            finally
            {
                if (dr != null)
                {
                    dr.Dispose();

                }
            }
        }
        /// <summary>
        /// 数据字典操作
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="operateType">add,update,delete</param>
        /// <returns></returns>
        public object DataDictionary_Operate(DataDictionary dict, string operateType)
        {
            if (operateType == "add" || operateType == "update")
            {
                string result = CheckCodeAndNameExists(dict);
                if (result == "DataDictionaryCode")
                {
                    return -100;
                }
                else if (result == "DataDictionaryName")
                {
                    return -200;
                }
            }
            switch (operateType)
            {
                case "add":
                    return this.Add(dict);
                    break;
                case "update":
                    return this.Update(dict);
                    break;
                case "delete":
                    return this.Delete(dict.DataDictionaryID);
                    break;
            }
            return 0;
        }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string CheckCodeAndNameExists(DataDictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DataDictionaryCode,DataDictionaryName from T_Dictionary");
            strSql.Append(" where (DataDictionaryCode=@DataDictionaryCode or DataDictionaryName=@DataDictionaryName) and DataDictionaryID<>@DataDictionaryID");
            strSql.Append(" and DataDictionaryType=@DataDictionaryType");
            SqlParameter[] parameters = {
					new SqlParameter("@DataDictionaryCode", SqlDbType.VarChar),
                    new SqlParameter("@DataDictionaryName", SqlDbType.VarChar),
                    new SqlParameter("@DataDictionaryID", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@DataDictionaryType", SqlDbType.VarChar)
                };
            parameters[0].Value = model.DataDictionaryCode;
            parameters[1].Value = model.DataDictionaryName;
            parameters[2].Value = model.DataDictionaryID;
            parameters[3].Value = model.DataDictionaryType;
            SqlDataReader dr = null;
            DataDictionary result = new DataDictionary();
            try
            {
                dr = new DbHelperSQL().ExecuteReader(strSql.ToString(), parameters);
                if (dr.Read())
                {
                    if (dr["DataDictionaryCode"] != null && dr["DataDictionaryCode"] != DBNull.Value)
                    {
                        result.DataDictionaryCode = dr["DataDictionaryCode"].ToString();
                    }
                    if (dr["DataDictionaryName"] != null && dr["DataDictionaryName"] != DBNull.Value)
                    {
                        result.DataDictionaryName = dr["DataDictionaryName"].ToString();
                    }
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (dr != null)
                    dr.Dispose();
            }
            if (string.IsNullOrEmpty(result.DataDictionaryCode) && string.IsNullOrEmpty(result.DataDictionaryName))
            {
                return "";
            }
            else if (result.DataDictionaryCode == model.DataDictionaryCode)
            {
                return "DataDictionaryCode";
            }
            else if (result.DataDictionaryName == model.DataDictionaryName)
            {
                return "DataDictionaryName";
            }
            return "";
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Guid Add(DataDictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            Guid guid = Guid.NewGuid();
            strSql.Append("insert into T_Dictionary(");
            strSql.Append("DataDictionaryID, DataDictionaryCode,DataDictionaryName,DataDictionaryDescription,DataDictionaryType,Array,State,Note,OperateID,OperateTime)");
            strSql.Append(" values (");
            strSql.Append("@DataDictionaryID, @DataDictionaryCode,@DataDictionaryName,@DataDictionaryDescription,@DataDictionaryType,@Array,@State,@Note,@OperateID,@OperateTime)");
            SqlParameter[] parameters = {
                    
					new SqlParameter("@DataDictionaryCode", SqlDbType.VarChar,50),
					new SqlParameter("@DataDictionaryName", SqlDbType.VarChar,100),
					new SqlParameter("@DataDictionaryDescription", SqlDbType.VarChar,200),
					new SqlParameter("@DataDictionaryType", SqlDbType.VarChar,50),
					new SqlParameter("@Array", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@Note", SqlDbType.VarChar),
					new SqlParameter("@OperateID", SqlDbType.Int,4),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
                    new SqlParameter("@DataDictionaryID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = model.DataDictionaryCode;
            parameters[1].Value = model.DataDictionaryName;
            parameters[2].Value = model.DataDictionaryDescription;
            parameters[3].Value = model.DataDictionaryType;
            parameters[4].Value = model.Array;
            parameters[5].Value = model.State;
            parameters[6].Value = model.Note;
            parameters[7].Value = model.OperateID;
            parameters[8].Value = System.DateTime.Now;
            parameters[9].Value = guid;

            new DbHelperSQL().ExecuteSql(strSql.ToString(), parameters);

            return guid;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private int Update(DataDictionary model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Dictionary set ");
            strSql.Append("DataDictionaryCode=@DataDictionaryCode,");
            strSql.Append("DataDictionaryName=@DataDictionaryName,");
            strSql.Append("DataDictionaryDescription=@DataDictionaryDescription,");
            strSql.Append("DataDictionaryType=@DataDictionaryType,");
            strSql.Append("Array=@Array,");
            strSql.Append("State=@State,");
            strSql.Append("Note=@Note,");
            strSql.Append("OperateID=@OperateID,");
            strSql.Append("OperateTime=@OperateTime");
            strSql.Append(" where DataDictionaryID=@DataDictionaryID");
            SqlParameter[] parameters = {
					new SqlParameter("@DataDictionaryCode", SqlDbType.VarChar,50),
					new SqlParameter("@DataDictionaryName", SqlDbType.VarChar,100),
					new SqlParameter("@DataDictionaryDescription", SqlDbType.VarChar,200),
					new SqlParameter("@DataDictionaryType", SqlDbType.VarChar,50),
					new SqlParameter("@Array", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Bit,1),
					new SqlParameter("@Note", SqlDbType.VarChar),
					new SqlParameter("@OperateID", SqlDbType.Int,4),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@DataDictionaryID", SqlDbType.UniqueIdentifier)};
            parameters[0].Value = model.DataDictionaryCode;
            parameters[1].Value = model.DataDictionaryName;
            parameters[2].Value = model.DataDictionaryDescription;
            parameters[3].Value = model.DataDictionaryType;
            parameters[4].Value = model.Array;
            parameters[5].Value = model.State;
            parameters[6].Value = model.Note;
            parameters[7].Value = model.OperateID;
            parameters[8].Value = System.DateTime.Now;
            parameters[9].Value = model.DataDictionaryID;

            int rows = new DbHelperSQL().ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private int Delete(Guid DataDictionaryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Dictionary ");
            strSql.Append(" where DataDictionaryID=@DataDictionaryID");
            SqlParameter[] parameters = {
					new SqlParameter("@DataDictionaryID", SqlDbType.UniqueIdentifier)
                };
            parameters[0].Value = DataDictionaryID;

            int rows = new DbHelperSQL().ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }
    }
}
