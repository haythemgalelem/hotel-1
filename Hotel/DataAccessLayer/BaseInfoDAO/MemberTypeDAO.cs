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
    /// 数据访问类:MemberType
    /// </summary>
    public partial class MemberTypeDAO
    {
        public MemberTypeDAO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BusinessEntity.Model.MemberType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_MemberType(");
            strSql.Append("MemberTypeID,TypeName,BaseDiscount,ScoreIncrease,Note)");
            strSql.Append(" values (");
            strSql.Append("@MemberTypeID,@TypeName,@BaseDiscount,@ScoreIncrease,@Note)");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberTypeID", SqlDbType.VarChar,36),
					new SqlParameter("@TypeName", SqlDbType.VarChar,40),
					new SqlParameter("@BaseDiscount", SqlDbType.Decimal,10),
					new SqlParameter("@ScoreIncrease", SqlDbType.VarChar,40),
					new SqlParameter("@Note", SqlDbType.VarChar,1000)};
            parameters[0].Value = model.MemberTypeID;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.BaseDiscount;
            parameters[3].Value = model.ScoreIncrease;
            parameters[4].Value = model.Note;

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
        public bool Update(BusinessEntity.Model.MemberType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_MemberType set ");
            strSql.Append("TypeName=@TypeName,");
            strSql.Append("BaseDiscount=@BaseDiscount,");
            strSql.Append("ScoreIncrease=@ScoreIncrease,");
            strSql.Append("Note=@Note");
            strSql.Append(" where MemberTypeID=@MemberTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.VarChar,40),
					new SqlParameter("@BaseDiscount", SqlDbType.Decimal,5),
					new SqlParameter("@ScoreIncrease", SqlDbType.VarChar,40),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@MemberTypeID", SqlDbType.VarChar,36)};
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.BaseDiscount;
            parameters[2].Value = model.ScoreIncrease;
            parameters[3].Value = model.Note;
            parameters[4].Value = model.MemberTypeID;

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
        public bool Delete(string MemberTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_MemberType ");
            strSql.Append(" where MemberTypeID=@MemberTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberTypeID", SqlDbType.VarChar,36)			};
            parameters[0].Value = MemberTypeID;

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
        public bool DeleteList(string MemberTypeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_MemberType ");
            strSql.Append(" where MemberTypeID in (" + MemberTypeIDlist + ")  ");
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
        public BusinessEntity.Model.MemberType GetModel(string MemberTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MemberTypeID,TypeName,BaseDiscount,ScoreIncrease,Note from T_MemberType ");
            strSql.Append(" where MemberTypeID=@MemberTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MemberTypeID", SqlDbType.VarChar,36)			};
            parameters[0].Value = MemberTypeID;

            BusinessEntity.Model.MemberType model = new BusinessEntity.Model.MemberType();
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
        public BusinessEntity.Model.MemberType DataRowToModel(DataRow row)
        {
            BusinessEntity.Model.MemberType model = new BusinessEntity.Model.MemberType();
            if (row != null)
            {
                if (row["MemberTypeID"] != null)
                {
                    model.MemberTypeID = row["MemberTypeID"].ToString();
                }
                if (row["TypeName"] != null)
                {
                    model.TypeName = row["TypeName"].ToString();
                }
                if (row["BaseDiscount"] != null && row["BaseDiscount"].ToString() != "")
                {
                    model.BaseDiscount = decimal.Parse(row["BaseDiscount"].ToString());
                }
                if (row["ScoreIncrease"] != null)
                {
                    model.ScoreIncrease = row["ScoreIncrease"].ToString();
                }
                if (row["Note"] != null)
                {
                    model.Note = row["Note"].ToString();
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
            strSql.Append("select MemberTypeID,TypeName,BaseDiscount,ScoreIncrease,Note ");
            strSql.Append(" FROM T_MemberType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return new DbHelperSQL().Query(strSql.ToString());
        }

        public List<MemberType> GetList()
        {
            DataSet ds = GetList("");
            List<MemberType> list = new List<MemberType>();

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
            strSql.Append(" MemberTypeID,TypeName,BaseDiscount,ScoreIncrease,Note ");
            strSql.Append(" FROM T_MemberType ");
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
            strSql.Append("select count(1) FROM T_MemberType ");
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
                strSql.Append("order by T.MemberTypeID desc");
            }
            strSql.Append(")AS Row, T.*  from T_MemberType T ");
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
            parameters[0].Value = "T_MemberType";
            parameters[1].Value = "MemberTypeID";
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

