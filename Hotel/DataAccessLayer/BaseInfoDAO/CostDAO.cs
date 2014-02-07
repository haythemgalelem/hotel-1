using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using BusinessEntity;
using Common;
namespace DataAccessLayer
{
    /// 模块：
    /// 作用：数据访问类:字典DataDictionaryDAO
    /// 作者：phq
    /// 日期：2011-12-28
    /// 说明：
    public partial class CostStypeDAO
    {
        public List<coststype> getAllCostStype()
        {
            string strSql = @"select * from T_CostStype";
            SqlDataReader dr = null;
            List<coststype> list_All = new List<coststype>();
            try
            {
                dr = new DbHelperSQL().ExecuteReader(strSql);

                while (dr.Read())
                {
                    list_All.Add(EntityHelper.GetEntityListByDT<coststype>(dr));

                }
                return list_All;
            }
            catch (SqlException ex)
            {
                throw new HotelException("获取费用类型列表失败", ex);
            }
            finally
            {
                if (dr != null)
                    dr.Dispose();
            }
            
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
          public int Add(coststype model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_CostStype(");
            strSql.Append("Type,Reserve,Note,OperatorID,OperatorTime)");
            strSql.Append(" values (");
            strSql.Append("@Type,@Reserve,@Note,@OperatorID,@OperatorTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@Type",model.Type);
            parameters[1] = new SqlParameter("@Reserve", model.Reserve);
            parameters[2] = new SqlParameter("@Note", model.Note);
            parameters[3] = new SqlParameter("@OperatorID", model.OperatorID);
            parameters[4] = new SqlParameter("@OperatorTime", model.OperatorTime);

            object obj = new DbHelperSQL().GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int update(coststype model)
        {
            string sql = @"update T_CostStype set 
                                Type = @Type,
                                Reserve =@Reserve, 			
                                Note = @Note,				
                                OperatorID = @OperatorID,			
                                OperatorTime = @OperatorTime
                           where CostID = " + model.CostID;

            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@Type", model.Type);
            parameters[1] = new SqlParameter("@Reserve", model.Reserve);
            parameters[2] = new SqlParameter("@Note", model.Note);
            parameters[3] = new SqlParameter("@OperatorID", model.OperatorID);
            parameters[4] = new SqlParameter("@OperatorTime", model.OperatorTime);

            try
            {
                int rows = new DbHelperSQL().ExecuteSql(sql, parameters);
                return rows;
            }
            catch (SqlException ex)
            {
                throw new HotelException("更新费用类型列表失败", ex);
            }
        }
    }
}
