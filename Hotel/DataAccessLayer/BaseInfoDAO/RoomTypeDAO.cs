using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Collections.Generic;
using BusinessEntity.Model;

namespace BusinessEntity.DAL
{
    /// <summary>
    /// 数据访问类:RoomType
    /// </summary>
    public partial class RoomTypeDAO
    {
        public RoomTypeDAO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BusinessEntity.Model.RoomType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_RoomType(");
            strSql.Append("ID,Name,Price,Description,Note,HourRoomPrice,AllowHourRoom)");
            strSql.Append(" values (");
            strSql.Append("@ID,@Name,@Price,@Description,@Note,@HourRoomPrice,@AllowHourRoom)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,36),
					new SqlParameter("@Name", SqlDbType.VarChar,40),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Description", SqlDbType.VarChar,1000),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@HourRoomPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AllowHourRoom", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.Note;
            parameters[5].Value = model.HourRoomPrice;
            parameters[6].Value = model.AllowHourRoom;

            int rows = new DbHelperSQL().ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BusinessEntity.Model.RoomType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_RoomType set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Price=@Price,");
            strSql.Append("Description=@Description,");
            strSql.Append("Note=@Note,");
            strSql.Append("HourRoomPrice=@HourRoomPrice,");
            strSql.Append("AllowHourRoom=@AllowHourRoom");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,40),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Description", SqlDbType.VarChar,1000),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@HourRoomPrice", SqlDbType.Decimal,9),
					new SqlParameter("@AllowHourRoom", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.VarChar,36)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Price;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.HourRoomPrice;
            parameters[5].Value = model.AllowHourRoom;
            parameters[6].Value = model.ID;

            int rows = new DbHelperSQL().ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_RoomType ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,36)			};
            parameters[0].Value = ID;

            int rows = new DbHelperSQL().ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_RoomType ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = new DbHelperSQL().ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BusinessEntity.Model.RoomType GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Price,Description,Note,HourRoomPrice,AllowHourRoom from T_RoomType ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,36)			};
            parameters[0].Value = ID;

            BusinessEntity.Model.RoomType model = new BusinessEntity.Model.RoomType();
            DataSet ds = new DbHelperSQL().Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BusinessEntity.Model.RoomType DataRowToModel(DataRow row)
        {
            BusinessEntity.Model.RoomType model = new BusinessEntity.Model.RoomType();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["HourRoomPrice"] != null && row["HourRoomPrice"].ToString() != "")
                {
                    model.HourRoomPrice = decimal.Parse(row["HourRoomPrice"].ToString());
                }
                if (row["AllowHourRoom"] != null && row["AllowHourRoom"].ToString() != "")
                {
                    model.AllowHourRoom = int.Parse(row["AllowHourRoom"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Name,Price,Description,Note,HourRoomPrice,AllowHourRoom ");
            strSql.Append(" FROM T_RoomType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return new DbHelperSQL().Query(strSql.ToString());
        }

        public List<RoomType> GetList()
        {
            DataSet ds = new DataSet();
            List<RoomType> list = new List<RoomType>();

            ds = GetList("");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }

            return list;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,Name,Price,Description,Note,HourRoomPrice,AllowHourRoom ");
            strSql.Append(" FROM T_RoomType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return new DbHelperSQL().Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_RoomType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = new DbHelperSQL().GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from T_RoomType T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return new DbHelperSQL().Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "T_RoomType";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return new DbHelperSQL().RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

