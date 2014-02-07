using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessEntity.Model;
using System.Collections.Generic;
namespace BusinessEntity.DAL
{
    /// <summary>
    /// 数据访问类:Checkin
    /// </summary>
    public partial class CheckinDAO
    {
        public CheckinDAO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BusinessEntity.Model.Checkin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Checkin(");
            strSql.Append("CheckinID,CheckinCode,CustomerID,Note,CustomerType,MemberID)");
            strSql.Append(" values (");
            strSql.Append("@CheckinID,@CheckinCode,@CustomerID,@Note,@CustomerType,@MemberID)");
            SqlParameter[] parameters = {
					new SqlParameter("@CheckinID", SqlDbType.VarChar,36),
					new SqlParameter("@CheckinCode", SqlDbType.VarChar,40),
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@CustomerType", SqlDbType.VarChar,40),
					new SqlParameter("@MemberID", SqlDbType.VarChar,36)};
            parameters[0].Value = model.CheckinID;
            parameters[1].Value = model.CheckinCode;
            parameters[2].Value = model.CustomerID;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.CustomerType;
            parameters[5].Value = model.MemberID;

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
        public bool Update(BusinessEntity.Model.Checkin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Checkin set ");
            strSql.Append("CheckinCode=@CheckinCode,");
            strSql.Append("CustomerID=@CustomerID,");
            strSql.Append("Note=@Note,");
            strSql.Append("CustomerType=@CustomerType,");
            strSql.Append("MemberID=@MemberID");
            strSql.Append(" where CheckinID=@CheckinID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CheckinCode", SqlDbType.VarChar,40),
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@CustomerType", SqlDbType.VarChar,40),
					new SqlParameter("@MemberID", SqlDbType.VarChar,36),
					new SqlParameter("@CheckinID", SqlDbType.VarChar,36)};
            parameters[0].Value = model.CheckinCode;
            parameters[1].Value = model.CustomerID;
            parameters[2].Value = model.Note;
            parameters[3].Value = model.CustomerType;
            parameters[4].Value = model.MemberID;
            parameters[5].Value = model.CheckinID;

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
        public bool Delete(string CheckinID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Checkin ");
            strSql.Append(" where CheckinID=@CheckinID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CheckinID", SqlDbType.VarChar,36)			};
            parameters[0].Value = CheckinID;

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
        public bool DeleteList(string CheckinIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Checkin ");
            strSql.Append(" where CheckinID in (" + CheckinIDlist + ")  ");
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
        public BusinessEntity.Model.Checkin DataRowToModel(DataRow row)
        {
            BusinessEntity.Model.Checkin model = new BusinessEntity.Model.Checkin();
            if (row != null)
            {
                if (row["CheckinID"] != null)
                {
                    model.CheckinID = row["CheckinID"].ToString();
                }
                if (row["CheckinCode"] != null)
                {
                    model.CheckinCode = row["CheckinCode"].ToString();
                }
                if (row["CustomerID"] != null)
                {
                    model.CustomerID = row["CustomerID"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["CustomerType"] != null)
                {
                    model.CustomerType = row["CustomerType"].ToString();
                }
                if (row["MemberID"] != null)
                {
                    model.MemberID = row["MemberID"].ToString();
                }
                if (row["FinanceStatus"] != null)
                {
                    model.FinanceStatus = row["FinanceStatus"].ToString();
                }
                if (row["Money"] != null)
                {
                    model.Money = row["Money"].ToString();
                }
                if (row["CustomerName"] != null)
                {
                    model.CustomerName = row["CustomerName"].ToString();
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
            strSql.Append(" select c.Status as FinanceStatus, c.Money as Money, d.* from T_CheckinFinance c ");
            strSql.Append(" left join "); 
            strSql.Append(" (select a.*, b.Name as CustomerName ");
            strSql.Append(" FROM T_Checkin a ");
            strSql.Append(" left join  T_Customer b on a.CustomerID = b.CustomerID) d ");
            strSql.Append(" on c.CheckinID = d.CheckinID ");
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
            strSql.Append(" CheckinID,CheckinCode,CustomerID,Note,CustomerType,MemberID ");
            strSql.Append(" FROM T_Checkin ");
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
            strSql.Append("select count(1) FROM T_Checkin ");
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
                strSql.Append("order by T.CheckinID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Checkin T ");
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
            parameters[0].Value = "T_Checkin";
            parameters[1].Value = "CheckinID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return new DbHelperSQL().RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        public List<Checkin> GetList()
        {
            DataSet ds = GetList("");
            List<Checkin> list = new List<Checkin>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }
            return list;
        }

        #endregion  ExtensionMethod

        public bool AddTran(Checkin currentCheckin)
        {
            try
            {
                List<CommandInfo> cmds = new List<CommandInfo>();
                //修改房态
                currentCheckin.arr_Rooms.ForEach(delegate(Checkin2Room room)
                {
                    cmds.Add(new RoomDAO().GetUpdateStatusSql(room.RoomID, "住客"));
                });
                //插入房间
                currentCheckin.arr_Rooms.ForEach(delegate(Checkin2Room room)
                {
                    cmds.Add(new Checkin2RoomDAO().GetAddSql(room));
                });
                //插入客人
                cmds.Add(new CustomerDAO().GetAddSql(currentCheckin.Customer));
                //插入财务单
                cmds.Add(new CheckinFinanceDAO().GetAddSql(currentCheckin.Finance));
                //插入入住单
                cmds.Add(GetAddSql(currentCheckin));

                int rows = new DbHelperSQL().ExecuteSqlTran(cmds);

                if (rows > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private CommandInfo GetAddSql(Checkin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Checkin(");
            strSql.Append("CheckinID,CheckinCode,CustomerID,Note,CustomerType,MemberID)");
            strSql.Append(" values (");
            strSql.Append("@CheckinID,@CheckinCode,@CustomerID,@Note,@CustomerType,@MemberID)");
            SqlParameter[] parameters = {
					new SqlParameter("@CheckinID", SqlDbType.VarChar,36),
					new SqlParameter("@CheckinCode", SqlDbType.VarChar,40),
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@CustomerType", SqlDbType.VarChar,40),
					new SqlParameter("@MemberID", SqlDbType.VarChar,36)};
            parameters[0].Value = model.CheckinID;
            parameters[1].Value = model.CheckinCode;
            parameters[2].Value = model.CustomerID;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.CustomerType;
            parameters[5].Value = model.MemberID;

            return new CommandInfo(strSql.ToString(), parameters);
        }
    }
}

