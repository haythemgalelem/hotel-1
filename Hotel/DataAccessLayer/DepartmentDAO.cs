using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntity.Model;
using System.Data.SqlClient;
using Common;

namespace DataAccessLayer
{
    public partial class DepartmentDAO
    {
        public List<Department> GetAllDepartmentList()
        {
            string strSql = @"select * from T_Department";
            SqlDataReader dr = null;
            List<Department> list_AllRoomType = new List<Department>();
            try
            {
                dr = new DbHelperSQL().ExecuteReader(strSql);
                while (dr.Read())
                {
                    list_AllRoomType.Add(EntityHelper.GetEntityListByDT<Department>(dr));
                }
                return list_AllRoomType;
            }
            catch (SqlException ex)
            {
                throw new HotelException("获取获取房间类型信息失败", ex);

            }
            finally
            {
                if (dr != null)
                    dr.Dispose();
            }
        }


        public List<Department> GetNodeDepartmentList()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from T_RoomType where RoomTypeName=@RoomTypeName");
                SqlParameter[] parameters = { new SqlParameter("@RoomTypeName", SqlDbType.NVarChar, 20) };
                parameters[0].Value = RoomTypeName;
                return new DbHelperSQL().Exists(strSql.ToString(), parameters);
            }
            catch (SqlException ex)
            {
                throw new HotelException("判断是否存在类型名房间失败", ex);

            }
            finally
            {
            }
        }
    }
}
