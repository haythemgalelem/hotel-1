using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntity.Model;
using System.Data.SqlClient;
using Common;

namespace DataAccessLayer
{
    public partial class UserDAO
    {
        public List<User> GetAllUserList()
        {
            string strSql = @"select * from T_User";
            SqlDataReader dr = null;
            List<User> list_AllUser = new List<User>();
            try
            {
                dr = new DbHelperSQL().ExecuteReader(strSql);
                while (dr.Read())
                {
                    list_AllUser.Add(EntityHelper.GetEntityListByDT<User>(dr));
                }
                return list_AllUser;
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
    }
}
