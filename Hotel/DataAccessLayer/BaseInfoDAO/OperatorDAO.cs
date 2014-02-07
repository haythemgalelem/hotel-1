using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using BusinessEntity.Model;

namespace DataAccessLayer.DAL
{
    /// <summary>
    /// 数据访问类:Operator
    /// </summary>
    public partial class OperatorDAO
    {
        public OperatorDAO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BusinessEntity.Model.Operator model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Operator(");
            strSql.Append("OperateID_,OperateCode,OperateName,Passwords,State,Note,OperatorID_,OperateTime)");
            strSql.Append(" values (");
            strSql.Append("@OperateID_,@OperateCode,@OperateName,@Passwords,@State,@Note,@OperatorID_,@OperateTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@OperateID_", SqlDbType.VarChar,36),
					new SqlParameter("@OperateCode", SqlDbType.VarChar,20),
					new SqlParameter("@OperateName", SqlDbType.VarChar,40),
					new SqlParameter("@Passwords", SqlDbType.VarChar,100),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@OperatorID_", SqlDbType.VarChar,36),
					new SqlParameter("@OperateTime", SqlDbType.DateTime)};
            parameters[0].Value = model.OperateID_;
            parameters[1].Value = model.OperateCode;
            parameters[2].Value = model.OperateName;
            parameters[3].Value = model.Passwords;
            parameters[4].Value = model.State;
            parameters[5].Value = model.Note;
            parameters[6].Value = model.OperatorID_;
            parameters[7].Value = model.OperateTime;

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
        public bool Update(BusinessEntity.Model.Operator model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Operator set ");
            strSql.Append("OperateCode=@OperateCode,");
            strSql.Append("Passwords=@Passwords,");
            strSql.Append("State=@State,");
            strSql.Append("Note=@Note,");
            strSql.Append("OperatorID_=@OperatorID_,");
            strSql.Append("OperateTime=@OperateTime");
            strSql.Append(" where OperateID_=@OperateID_ and OperateName=@OperateName ");
            SqlParameter[] parameters = {
					new SqlParameter("@OperateCode", SqlDbType.VarChar,20),
					new SqlParameter("@Passwords", SqlDbType.VarChar,100),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@OperatorID_", SqlDbType.VarChar,36),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@OperateID_", SqlDbType.VarChar,36),
					new SqlParameter("@OperateName", SqlDbType.VarChar,40)};
            parameters[0].Value = model.OperateCode;
            parameters[1].Value = model.Passwords;
            parameters[2].Value = model.State;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.OperatorID_;
            parameters[5].Value = model.OperateTime;
            parameters[6].Value = model.OperateID_;
            parameters[7].Value = model.OperateName;

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
        public bool Delete(string OperateID_)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Operator ");
            strSql.Append(" where OperateID_=@OperateID_");
            SqlParameter[] parameters = {
					new SqlParameter("@OperateID_", SqlDbType.VarChar,36)
                                        };
            parameters[0].Value = OperateID_;

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
        /// 得到一个对象实体
        /// </summary>
        public BusinessEntity.Model.Operator GetModel(string OperateID_, string OperateName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OperateID_,OperateCode,OperateName,Passwords,State,Note,OperatorID_,OperateTime from T_Operator ");
            strSql.Append(" where OperateID_=@OperateID_ and OperateName=@OperateName ");
            SqlParameter[] parameters = {
					new SqlParameter("@OperateID_", SqlDbType.VarChar,36),
					new SqlParameter("@OperateName", SqlDbType.VarChar,40)			};
            parameters[0].Value = OperateID_;
            parameters[1].Value = OperateName;

            BusinessEntity.Model.Operator model = new BusinessEntity.Model.Operator();
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
        public BusinessEntity.Model.Operator DataRowToModel(DataRow row)
        {
            BusinessEntity.Model.Operator model = new BusinessEntity.Model.Operator();
            if (row != null)
            {
                if (row["OperateID_"] != null)
                {
                    model.OperateID_ = row["OperateID_"].ToString();
                }
                if (row["OperateCode"] != null)
                {
                    model.OperateCode = row["OperateCode"].ToString();
                }
                if (row["OperateName"] != null)
                {
                    model.OperateName = row["OperateName"].ToString();
                }
                if (row["Passwords"] != null)
                {
                    model.Passwords = row["Passwords"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
                }
                if (row["OperatorID_"] != null)
                {
                    model.OperatorID_ = row["OperatorID_"].ToString();
                }
                if (row["OperateTime"] != null && row["OperateTime"].ToString() != "")
                {
                    model.OperateTime = DateTime.Parse(row["OperateTime"].ToString());
                }
                if (row["OperatorName_Name"] != null)
                {
                    model.OperatorName_Name = row["OperatorName_Name"].ToString();
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
            strSql.Append("select a.*,  b.OperateName as OperatorName_Name");
            strSql.Append(" FROM T_Operator a left join T_Operator b on a.OperatorID_ = b.OperateID_");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return new DbHelperSQL().Query(strSql.ToString());
        }

        public List<Operator> GetList()
        {
            DataSet ds = GetDataSetList("");
            List<Operator> list = new List<Operator>();
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
            strSql.Append(" OperateID_,OperateCode,OperateName,Passwords,State,Note,OperatorID_,OperateTime ");
            strSql.Append(" FROM T_Operator ");
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
            strSql.Append("select count(1) FROM T_Operator ");
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
                strSql.Append("order by T.OperateName desc");
            }
            strSql.Append(")AS Row, T.*  from T_Operator T ");
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
            parameters[0].Value = "T_Operator";
            parameters[1].Value = "OperateName";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BusinessEntity.Model.Operator Verify(string name, string pwd)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,  b.OperateName as OperatorName_Name from (select * from T_Operator where OperateCode = @OperateCode and Passwords = @Passwords ) a ");
            strSql.Append("left join T_Operator b on a.OperatorID_ = b.OperateID_");
            SqlParameter[] parameters = {
					new SqlParameter("@OperateCode", SqlDbType.VarChar,36),
					new SqlParameter("@Passwords", SqlDbType.VarChar,40)			};
            parameters[0].Value = name;
            parameters[1].Value = pwd;

            BusinessEntity.Model.Operator model = new BusinessEntity.Model.Operator();
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
        #endregion  ExtensionMethod
    }
}

