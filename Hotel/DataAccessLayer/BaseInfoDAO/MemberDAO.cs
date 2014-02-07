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
    /// 数据访问类:Member
    /// </summary>
    public partial class MemberDAO
    {
        public MemberDAO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BusinessEntity.Model.Member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Member(");
            strSql.Append("MemberID,MemberCardID,MemberName,CardType,IDCard,Sex,BirthDay,HomeTel,MobileTel,Address,Available,Pwd,Status,RegTime,Score,Times,Discount,Balance)");
            strSql.Append(" values (");
            strSql.Append("@MemberID,@MemberCardID,@MemberName,@CardType,@IDCard,@Sex,@BirthDay,@HomeTel,@MobileTel,@Address,@Available,@Pwd,@Status,@RegTime,@Score,@Times,@Discount,@Balance)");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.VarChar,36),
					new SqlParameter("@MemberCardID", SqlDbType.VarChar,50),
					new SqlParameter("@MemberName", SqlDbType.VarChar,20),
					new SqlParameter("@CardType", SqlDbType.VarChar,36),
					new SqlParameter("@IDCard", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,5),
					new SqlParameter("@BirthDay", SqlDbType.DateTime),
					new SqlParameter("@HomeTel", SqlDbType.VarChar,20),
					new SqlParameter("@MobileTel", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Available", SqlDbType.Int,4),
					new SqlParameter("@Pwd", SqlDbType.VarChar,30),
					new SqlParameter("@Status", SqlDbType.VarChar,10),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@Times", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Decimal,5),
					new SqlParameter("@Balance", SqlDbType.Money,8)};
            parameters[0].Value = model.MemberID;
            parameters[1].Value = model.MemberCardID;
            parameters[2].Value = model.MemberName;
            parameters[3].Value = model.CardType;
            parameters[4].Value = model.IDCard;
            parameters[5].Value = model.Sex;
            parameters[6].Value = model.BirthDay;
            parameters[7].Value = model.HomeTel;
            parameters[8].Value = model.MobileTel;
            parameters[9].Value = model.Address;
            parameters[10].Value = model.Available;
            parameters[11].Value = model.Pwd;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.RegTime;
            parameters[14].Value = model.Score;
            parameters[15].Value = model.Times;
            parameters[16].Value = model.Discount;
            parameters[17].Value = model.Balance;

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
        public bool Update(BusinessEntity.Model.Member model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Member set ");
            strSql.Append("MemberCardID=@MemberCardID,");
            strSql.Append("MemberName=@MemberName,");
            strSql.Append("CardType=@CardType,");
            strSql.Append("IDCard=@IDCard,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("BirthDay=@BirthDay,");
            strSql.Append("HomeTel=@HomeTel,");
            strSql.Append("MobileTel=@MobileTel,");
            strSql.Append("Address=@Address,");
            strSql.Append("Available=@Available,");
            strSql.Append("Pwd=@Pwd,");
            strSql.Append("Status=@Status,");
            strSql.Append("RegTime=@RegTime,");
            strSql.Append("Score=@Score,");
            strSql.Append("Times=@Times,");
            strSql.Append("Discount=@Discount,");
            strSql.Append("Balance=@Balance");
            strSql.Append(" where MemberID=@MemberID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberCardID", SqlDbType.VarChar,50),
					new SqlParameter("@MemberName", SqlDbType.VarChar,20),
					new SqlParameter("@CardType", SqlDbType.VarChar,36),
					new SqlParameter("@IDCard", SqlDbType.VarChar,50),
					new SqlParameter("@Sex", SqlDbType.VarChar,5),
					new SqlParameter("@BirthDay", SqlDbType.DateTime),
					new SqlParameter("@HomeTel", SqlDbType.VarChar,20),
					new SqlParameter("@MobileTel", SqlDbType.VarChar,20),
					new SqlParameter("@Address", SqlDbType.VarChar,100),
					new SqlParameter("@Available", SqlDbType.Int,4),
					new SqlParameter("@Pwd", SqlDbType.VarChar,30),
					new SqlParameter("@Status", SqlDbType.VarChar,10),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@Times", SqlDbType.Int,4),
					new SqlParameter("@Discount", SqlDbType.Decimal,5),
					new SqlParameter("@Balance", SqlDbType.Money,8),
					new SqlParameter("@MemberID", SqlDbType.VarChar,36)};
            parameters[0].Value = model.MemberCardID;
            parameters[1].Value = model.MemberName;
            parameters[2].Value = model.CardType;
            parameters[3].Value = model.IDCard;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.BirthDay;
            parameters[6].Value = model.HomeTel;
            parameters[7].Value = model.MobileTel;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.Available;
            parameters[10].Value = model.Pwd;
            parameters[11].Value = model.Status;
            parameters[12].Value = model.RegTime;
            parameters[13].Value = model.Score;
            parameters[14].Value = model.Times;
            parameters[15].Value = model.Discount;
            parameters[16].Value = model.Balance;
            parameters[17].Value = model.MemberID;

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
        public bool Delete(string MemberID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Member ");
            strSql.Append(" where MemberID=@MemberID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.VarChar,36)			};
            parameters[0].Value = MemberID;

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
        public bool DeleteList(string MemberIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Member ");
            strSql.Append(" where MemberID in (" + MemberIDlist + ")  ");
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
        public BusinessEntity.Model.Member GetModel(string MemberID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MemberID,MemberCardID,MemberName,CardType,IDCard,Sex,BirthDay,HomeTel,MobileTel,Address,Available,Pwd,Status,RegTime,Score,Times,Discount,Balance from T_Member ");
            strSql.Append(" where MemberID=@MemberID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.VarChar,36)			};
            parameters[0].Value = MemberID;

            BusinessEntity.Model.Member model = new BusinessEntity.Model.Member();
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
        public BusinessEntity.Model.Member DataRowToModel(DataRow row)
        {
            BusinessEntity.Model.Member model = new BusinessEntity.Model.Member();
            if (row != null)
            {
                if (row["MemberID"] != null)
                {
                    model.MemberID = row["MemberID"].ToString();
                }
                if (row["MemberCardID"] != null)
                {
                    model.MemberCardID = row["MemberCardID"].ToString();
                }
                if (row["MemberName"] != null)
                {
                    model.MemberName = row["MemberName"].ToString();
                }
                if (row["CardType"] != null)
                {
                    model.CardType = row["CardType"].ToString();
                }
                if (row["IDCard"] != null)
                {
                    model.IDCard = row["IDCard"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["BirthDay"] != null && row["BirthDay"].ToString() != "")
                {
                    model.BirthDay = DateTime.Parse(row["BirthDay"].ToString());
                }
                if (row["HomeTel"] != null)
                {
                    model.HomeTel = row["HomeTel"].ToString();
                }
                if (row["MobileTel"] != null)
                {
                    model.MobileTel = row["MobileTel"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["Available"] != null && row["Available"].ToString() != "")
                {
                    model.Available = int.Parse(row["Available"].ToString());
                }
                if (row["Pwd"] != null)
                {
                    model.Pwd = row["Pwd"].ToString();
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["RegTime"] != null && row["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(row["RegTime"].ToString());
                }
                if (row["Score"] != null && row["Score"].ToString() != "")
                {
                    model.Score = int.Parse(row["Score"].ToString());
                }
                if (row["Times"] != null && row["Times"].ToString() != "")
                {
                    model.Times = int.Parse(row["Times"].ToString());
                }
                if (row["Discount"] != null && row["Discount"].ToString() != "")
                {
                    model.Discount = decimal.Parse(row["Discount"].ToString());
                }
                if (row["Balance"] != null && row["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(row["Balance"].ToString());
                }

                if (row["CardTypeName"] != null && row["CardTypeName"].ToString() != "")
                {
                    model.CardTypeName = row["CardTypeName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetDataSetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MemberID,MemberCardID,MemberName,CardType,IDCard,Sex,BirthDay,HomeTel,MobileTel,Address,Available,Pwd,Status,RegTime,Score,Times,Discount,Balance, b.TypeName as CardTypeName ");
            strSql.Append(" FROM T_Member a left join T_MemberType b on a.CardType = b.MemberTypeID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return new DbHelperSQL().Query(strSql.ToString());
        }

        public List<Member> GetList() 
        {
            DataSet ds = GetDataSetList("");
            List<Member> list = new List<Member>();

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
            strSql.Append(" MemberID,MemberCardID,MemberName,CardType,IDCard,Sex,BirthDay,HomeTel,MobileTel,Address,Available,Pwd,Status,RegTime,Score,Times,Discount,Balance ");
            strSql.Append(" FROM T_Member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return new DbHelperSQL().Query(strSql.ToString());
        }

        public CommandInfo UpdateStatus(string MemberID, string status)
        {
            StringBuilder buf = new StringBuilder();
            buf.Append("update T_Member set Status = @Status ");
            buf.Append("where MemberID = @MemberID");

            SqlParameter[] parame = {
                new SqlParameter("@Status", SqlDbType.VarChar, 40),
                new SqlParameter("@MemberID", SqlDbType.VarChar, 36)
                                    };

            parame[0].Value = status;
            parame[1].Value = MemberID;

            return new CommandInfo(buf.ToString(), parame);
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_Member ");
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
                strSql.Append("order by T.MemberID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Member T ");
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
            parameters[0].Value = "T_Member";
            parameters[1].Value = "MemberID";
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

