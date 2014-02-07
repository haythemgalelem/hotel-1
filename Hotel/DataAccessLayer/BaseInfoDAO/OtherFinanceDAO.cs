using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccessLayer;
namespace BusinessEntity.DAL
{
    /// <summary>
    /// 数据访问类:OtherFinance
    /// </summary>
    public partial class OtherFinanceDAO
    {
        public OtherFinanceDAO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BusinessEntity.Model.OtherFinance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_OtherFinance(");
            strSql.Append("OtherFinanceID,OtherFinanceCode,Purpost,InOrOut,Money,Description,Note,Status,Operator,OperateTime)");
            strSql.Append(" values (");
            strSql.Append("@OtherFinanceID,@OtherFinanceCode,@Purpost,@InOrOut,@Money,@Description,@Note,@Status,@Operator,@OperateTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@OtherFinanceID", SqlDbType.VarChar,36),
					new SqlParameter("@OtherFinanceCode", SqlDbType.VarChar,40),
					new SqlParameter("@Purpost", SqlDbType.VarChar,36),
					new SqlParameter("@InOrOut", SqlDbType.Int,4),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Description", SqlDbType.VarChar,1000),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@Status", SqlDbType.VarChar,10),
					new SqlParameter("@Operator", SqlDbType.VarChar,36),
					new SqlParameter("@OperateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.OtherFinanceID;
            parameters[1].Value = model.OtherFinanceCode;
            parameters[2].Value = model.Purpost;
            parameters[3].Value = model.InOrOut;
            parameters[4].Value = model.Money;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.Note;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Operator;
            parameters[9].Value = model.OperateTime;

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
        public bool Update(BusinessEntity.Model.OtherFinance model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_OtherFinance set ");
            strSql.Append("OtherFinanceCode=@OtherFinanceCode,");
            strSql.Append("Purpost=@Purpost,");
            strSql.Append("InOrOut=@InOrOut,");
            strSql.Append("Money=@Money,");
            strSql.Append("Description=@Description,");
            strSql.Append("Note=@Note,");
            strSql.Append("Status=@Status,");
            strSql.Append("Operator=@Operator,");
            strSql.Append("OperateTime=@OperateTime");
            strSql.Append(" where OtherFinanceID=@OtherFinanceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OtherFinanceCode", SqlDbType.VarChar,40),
					new SqlParameter("@Purpost", SqlDbType.VarChar,36),
					new SqlParameter("@InOrOut", SqlDbType.Int,4),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@Description", SqlDbType.VarChar,1000),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@Status", SqlDbType.VarChar,10),
					new SqlParameter("@Operator", SqlDbType.VarChar,36),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@OtherFinanceID", SqlDbType.VarChar,36)};
            parameters[0].Value = model.OtherFinanceCode;
            parameters[1].Value = model.Purpost;
            parameters[2].Value = model.InOrOut;
            parameters[3].Value = model.Money;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.Note;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.Operator;
            parameters[8].Value = model.OperateTime;
            parameters[9].Value = model.OtherFinanceID;

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
        public bool Delete(string OtherFinanceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_OtherFinance ");
            strSql.Append(" where OtherFinanceID=@OtherFinanceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OtherFinanceID", SqlDbType.VarChar,36)			};
            parameters[0].Value = OtherFinanceID;

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
        public bool DeleteList(string OtherFinanceIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_OtherFinance ");
            strSql.Append(" where OtherFinanceID in (" + OtherFinanceIDlist + ")  ");
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
        public BusinessEntity.Model.OtherFinance GetModel(string OtherFinanceID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OtherFinanceID,OtherFinanceCode,Purpost,InOrOut,Money,Description,Note,Status,Operator,OperateTime from T_OtherFinance ");
            strSql.Append(" where OtherFinanceID=@OtherFinanceID ");
            SqlParameter[] parameters = {
					new SqlParameter("@OtherFinanceID", SqlDbType.VarChar,36)			};
            parameters[0].Value = OtherFinanceID;

            BusinessEntity.Model.OtherFinance model = new BusinessEntity.Model.OtherFinance();
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
        public BusinessEntity.Model.OtherFinance DataRowToModel(DataRow row)
        {
            BusinessEntity.Model.OtherFinance model = new BusinessEntity.Model.OtherFinance();
            if (row != null)
            {
                if (row["OtherFinanceID"] != null)
                {
                    model.OtherFinanceID = row["OtherFinanceID"].ToString();
                }
                if (row["OtherFinanceCode"] != null)
                {
                    model.OtherFinanceCode = row["OtherFinanceCode"].ToString();
                }
                if (row["Purpost"] != null)
                {
                    model.Purpost = row["Purpost"].ToString();
                }
                if (row["InOrOut"] != null && row["InOrOut"].ToString() != "")
                {
                    model.InOrOut = int.Parse(row["InOrOut"].ToString());
                }
                if (row["Money"] != null && row["Money"].ToString() != "")
                {
                    model.Money = decimal.Parse(row["Money"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["Status"] != null)
                {
                    model.Status = row["Status"].ToString();
                }
                if (row["Operator"] != null)
                {
                    model.Operator = row["Operator"].ToString();
                }
                if (row["OperateTime"] != null && row["OperateTime"].ToString() != "")
                {
                    model.OperateTime = DateTime.Parse(row["OperateTime"].ToString());
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
            strSql.Append("select OtherFinanceID,OtherFinanceCode,Purpost,InOrOut,Money,Description,Note,Status,Operator,OperateTime ");
            strSql.Append(" FROM T_OtherFinance ");
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
            strSql.Append(" OtherFinanceID,OtherFinanceCode,Purpost,InOrOut,Money,Description,Note,Status,Operator,OperateTime ");
            strSql.Append(" FROM T_OtherFinance ");
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
            strSql.Append("select count(1) FROM T_OtherFinance ");
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
                strSql.Append("order by T.OtherFinanceID desc");
            }
            strSql.Append(")AS Row, T.*  from T_OtherFinance T ");
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
            parameters[0].Value = "T_OtherFinance";
            parameters[1].Value = "OtherFinanceID";
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

