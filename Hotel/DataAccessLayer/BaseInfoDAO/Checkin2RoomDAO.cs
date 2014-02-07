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
    /// 数据访问类:Checkin2Room
    /// </summary>
    public partial class Checkin2RoomDAO
    {
        public Checkin2RoomDAO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BusinessEntity.Model.Checkin2Room model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Checkin2Room(");
            strSql.Append("Checkin2RoomID,CheckinID,RoomID,Note,CheckinType,OriginalPrice,TotalPrice,Discount,DiscountPrice,TimeCount,CheckoutTime,IsCheckOut,RealCheckoutTime)");
            strSql.Append(" values (");
            strSql.Append("@Checkin2RoomID,@CheckinID,@RoomID,@Note,@CheckinType,@OriginalPrice,@TotalPrice,@Discount,@DiscountPrice,@TimeCount,@CheckoutTime,@IsCheckOut,@RealCheckoutTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@Checkin2RoomID", SqlDbType.VarChar,36),
					new SqlParameter("@CheckinID", SqlDbType.VarChar,36),
					new SqlParameter("@RoomID", SqlDbType.VarChar,36),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@CheckinType", SqlDbType.VarChar,40),
					new SqlParameter("@OriginalPrice", SqlDbType.Money,8),
					new SqlParameter("@TotalPrice", SqlDbType.Money,8),
					new SqlParameter("@Discount", SqlDbType.Int,4),
					new SqlParameter("@DiscountPrice", SqlDbType.Money,8),
					new SqlParameter("@TimeCount", SqlDbType.Int,4),
					new SqlParameter("@CheckoutTime", SqlDbType.DateTime),
					new SqlParameter("@IsCheckOut", SqlDbType.Int,4),
					new SqlParameter("@RealCheckoutTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Checkin2RoomID;
            parameters[1].Value = model.CheckinID;
            parameters[2].Value = model.RoomID;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.CheckinType;
            parameters[5].Value = model.OriginalPrice;
            parameters[6].Value = model.TotalPrice;
            parameters[7].Value = model.Discount;
            parameters[8].Value = model.DiscountPrice;
            parameters[9].Value = model.TimeCount;
            parameters[10].Value = model.CheckoutTime;
            parameters[11].Value = model.IsCheckOut;
            parameters[12].Value = model.RealCheckoutTime;

            int rows =  new DbHelperSQL().ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(BusinessEntity.Model.Checkin2Room model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Checkin2Room set ");
            strSql.Append("CheckinID=@CheckinID,");
            strSql.Append("RoomID=@RoomID,");
            strSql.Append("Note=@Note,");
            strSql.Append("CheckinType=@CheckinType,");
            strSql.Append("OriginalPrice=@OriginalPrice,");
            strSql.Append("TotalPrice=@TotalPrice,");
            strSql.Append("Discount=@Discount,");
            strSql.Append("DiscountPrice=@DiscountPrice,");
            strSql.Append("TimeCount=@TimeCount,");
            strSql.Append("CheckoutTime=@CheckoutTime,");
            strSql.Append("IsCheckOut=@IsCheckOut,");
            strSql.Append("RealCheckoutTime=@RealCheckoutTime");
            strSql.Append(" where Checkin2RoomID=@Checkin2RoomID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CheckinID", SqlDbType.VarChar,36),
					new SqlParameter("@RoomID", SqlDbType.VarChar,36),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@CheckinType", SqlDbType.VarChar,40),
					new SqlParameter("@OriginalPrice", SqlDbType.Money,8),
					new SqlParameter("@TotalPrice", SqlDbType.Money,8),
					new SqlParameter("@Discount", SqlDbType.Int,4),
					new SqlParameter("@DiscountPrice", SqlDbType.Money,8),
					new SqlParameter("@TimeCount", SqlDbType.Int,4),
					new SqlParameter("@CheckoutTime", SqlDbType.DateTime),
					new SqlParameter("@IsCheckOut", SqlDbType.Int,4),
					new SqlParameter("@RealCheckoutTime", SqlDbType.DateTime),
					new SqlParameter("@Checkin2RoomID", SqlDbType.VarChar,36)};
            parameters[0].Value = model.CheckinID;
            parameters[1].Value = model.RoomID;
            parameters[2].Value = model.Note;
            parameters[3].Value = model.CheckinType;
            parameters[4].Value = model.OriginalPrice;
            parameters[5].Value = model.TotalPrice;
            parameters[6].Value = model.Discount;
            parameters[7].Value = model.DiscountPrice;
            parameters[8].Value = model.TimeCount;
            parameters[9].Value = model.CheckoutTime;
            parameters[10].Value = model.IsCheckOut;
            parameters[11].Value = model.RealCheckoutTime;
            parameters[12].Value = model.Checkin2RoomID;

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
        public bool Delete(string Checkin2RoomID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Checkin2Room ");
            strSql.Append(" where Checkin2RoomID=@Checkin2RoomID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Checkin2RoomID", SqlDbType.VarChar,36)			};
            parameters[0].Value = Checkin2RoomID;

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
        public bool DeleteList(string Checkin2RoomIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Checkin2Room ");
            strSql.Append(" where Checkin2RoomID in (" + Checkin2RoomIDlist + ")  ");
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
        public BusinessEntity.Model.Checkin2Room GetModel(string Checkin2RoomID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Checkin2RoomID,CheckinID,RoomID,Note,CheckinType,OriginalPrice,TotalPrice,Discount,DiscountPrice,TimeCount,CheckoutTime,IsCheckOut,RealCheckoutTime from T_Checkin2Room ");
            strSql.Append(" where Checkin2RoomID=@Checkin2RoomID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Checkin2RoomID", SqlDbType.VarChar,36)			};
            parameters[0].Value = Checkin2RoomID;

            BusinessEntity.Model.Checkin2Room model = new BusinessEntity.Model.Checkin2Room();
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
        public BusinessEntity.Model.Checkin2Room DataRowToModel(DataRow row)
        {
            BusinessEntity.Model.Checkin2Room model = new BusinessEntity.Model.Checkin2Room();
            if (row != null)
            {
                if (row["Checkin2RoomID"] != null)
                {
                    model.Checkin2RoomID = row["Checkin2RoomID"].ToString();
                }
                if (row["CheckinID"] != null)
                {
                    model.CheckinID = row["CheckinID"].ToString();
                }
                if (row["RoomID"] != null)
                {
                    model.RoomID = row["RoomID"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["CheckinType"] != null)
                {
                    model.CheckinType = row["CheckinType"].ToString();
                }
                if (row["OriginalPrice"] != null && row["OriginalPrice"].ToString() != "")
                {
                    model.OriginalPrice = decimal.Parse(row["OriginalPrice"].ToString());
                }
                if (row["TotalPrice"] != null && row["TotalPrice"].ToString() != "")
                {
                    model.TotalPrice = decimal.Parse(row["TotalPrice"].ToString());
                }
                if (row["Discount"] != null && row["Discount"].ToString() != "")
                {
                    model.Discount = int.Parse(row["Discount"].ToString());
                }
                if (row["DiscountPrice"] != null && row["DiscountPrice"].ToString() != "")
                {
                    model.DiscountPrice = decimal.Parse(row["DiscountPrice"].ToString());
                }
                if (row["TimeCount"] != null && row["TimeCount"].ToString() != "")
                {
                    model.TimeCount = int.Parse(row["TimeCount"].ToString());
                }
                if (row["CheckoutTime"] != null && row["CheckoutTime"].ToString() != "")
                {
                    model.CheckoutTime = DateTime.Parse(row["CheckoutTime"].ToString());
                }
                if (row["IsCheckOut"] != null && row["IsCheckOut"].ToString() != "")
                {
                    model.IsCheckOut = int.Parse(row["IsCheckOut"].ToString());
                }
                if (row["RealCheckoutTime"] != null && row["RealCheckoutTime"].ToString() != "")
                {
                    model.RealCheckoutTime = DateTime.Parse(row["RealCheckoutTime"].ToString());
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
            strSql.Append("select Checkin2RoomID,CheckinID,RoomID,Note,CheckinType,OriginalPrice,TotalPrice,Discount,DiscountPrice,TimeCount,CheckoutTime,IsCheckOut,RealCheckoutTime ");
            strSql.Append(" FROM T_Checkin2Room ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return new DbHelperSQL().Query(strSql.ToString());
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
            strSql.Append(" Checkin2RoomID,CheckinID,RoomID,Note,CheckinType,OriginalPrice,TotalPrice,Discount,DiscountPrice,TimeCount,CheckoutTime,IsCheckOut,RealCheckoutTime ");
            strSql.Append(" FROM T_Checkin2Room ");
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
            strSql.Append("select count(1) FROM T_Checkin2Room ");
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
                strSql.Append("order by T.Checkin2RoomID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Checkin2Room T ");
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
            parameters[0].Value = "T_Checkin2Room";
            parameters[1].Value = "Checkin2RoomID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return new DbHelperSQL().RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public List<Checkin2Room> GetList()
        {
            DataSet ds = GetList("");
            List<Checkin2Room> list = new List<Checkin2Room>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }
            return list;
        }
        #endregion  ExtensionMethod

        internal CommandInfo GetAddSql(Checkin2Room model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Checkin2Room(");
            strSql.Append("Checkin2RoomID,CheckinID,RoomID,Note,CheckinType,OriginalPrice,TotalPrice,Discount,DiscountPrice,TimeCount,CheckoutTime,IsCheckOut,RealCheckoutTime)");
            strSql.Append(" values (");
            strSql.Append("@Checkin2RoomID,@CheckinID,@RoomID,@Note,@CheckinType,@OriginalPrice,@TotalPrice,@Discount,@DiscountPrice,@TimeCount,@CheckoutTime,@IsCheckOut,@RealCheckoutTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@Checkin2RoomID", SqlDbType.VarChar,36),
					new SqlParameter("@CheckinID", SqlDbType.VarChar,36),
					new SqlParameter("@RoomID", SqlDbType.VarChar,36),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@CheckinType", SqlDbType.VarChar,40),
					new SqlParameter("@OriginalPrice", SqlDbType.Money,8),
					new SqlParameter("@TotalPrice", SqlDbType.Money,8),
					new SqlParameter("@Discount", SqlDbType.Int,4),
					new SqlParameter("@DiscountPrice", SqlDbType.Money,8),
					new SqlParameter("@TimeCount", SqlDbType.Int,4),
					new SqlParameter("@CheckoutTime", SqlDbType.DateTime),
					new SqlParameter("@IsCheckOut", SqlDbType.Int,4),
					new SqlParameter("@RealCheckoutTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Checkin2RoomID;
            parameters[1].Value = model.CheckinID;
            parameters[2].Value = model.RoomID;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.CheckinType;
            parameters[5].Value = model.OriginalPrice;
            parameters[6].Value = model.TotalPrice;
            parameters[7].Value = model.Discount;
            parameters[8].Value = model.DiscountPrice;
            parameters[9].Value = model.TimeCount;
            parameters[10].Value = model.CheckoutTime;
            parameters[11].Value = model.IsCheckOut;
            parameters[12].Value = model.RealCheckoutTime;

            return new CommandInfo(strSql.ToString(), parameters);
        }

        public List<Checkin2Room> GetListByCheckin(Checkin checkin)
        {
            DataSet ds = GetList("CheckinID = '" + checkin.CheckinID + "'");
            List<Checkin2Room> list = new List<Checkin2Room>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }
            return list;
        }
    }
}

