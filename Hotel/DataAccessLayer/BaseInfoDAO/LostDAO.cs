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
	/// 数据访问类:Lost
	/// </summary>
	public partial class LostDAO
	{
        public LostDAO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BusinessEntity.Model.Lost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Lost(");
			strSql.Append("LostID,MemberID,Reason,Note,LostTime,Status,Operator,OperateTime)");
			strSql.Append(" values (");
			strSql.Append("@LostID,@MemberID,@Reason,@Note,@LostTime,@Status,@Operator,@OperateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@LostID", SqlDbType.VarChar,36),
					new SqlParameter("@MemberID", SqlDbType.VarChar,36),
					new SqlParameter("@Reason", SqlDbType.VarChar,100),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@LostTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.VarChar,40),
					new SqlParameter("@Operator", SqlDbType.VarChar,36),
					new SqlParameter("@OperateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.LostID;
			parameters[1].Value = model.MemberID;
			parameters[2].Value = model.Reason;
			parameters[3].Value = model.Note;
			parameters[4].Value = model.LostTime;
			parameters[5].Value = model.Status;
			parameters[6].Value = model.Operator;
			parameters[7].Value = model.OperateTime;

            List<CommandInfo> cmds = new List<CommandInfo>();
            cmds.Add(new MemberDAO().UpdateStatus(model.MemberID, "挂失"));
            cmds.Add(new CommandInfo(strSql.ToString(), parameters));

			int rows=new DbHelperSQL().ExecuteSqlTran(cmds);
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
		public bool Update(BusinessEntity.Model.Lost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Lost set ");
			strSql.Append("MemberID=@MemberID,");
			strSql.Append("Reason=@Reason,");
			strSql.Append("Note=@Note,");
			strSql.Append("LostTime=@LostTime,");
			strSql.Append("Status=@Status,");
			strSql.Append("Operator=@Operator,");
			strSql.Append("OperateTime=@OperateTime");
			strSql.Append(" where LostID=@LostID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MemberID", SqlDbType.VarChar,36),
					new SqlParameter("@Reason", SqlDbType.VarChar,100),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@LostTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.VarChar,40),
					new SqlParameter("@Operator", SqlDbType.VarChar,36),
					new SqlParameter("@OperateTime", SqlDbType.DateTime),
					new SqlParameter("@LostID", SqlDbType.VarChar,36)};
			parameters[0].Value = model.MemberID;
			parameters[1].Value = model.Reason;
			parameters[2].Value = model.Note;
			parameters[3].Value = model.LostTime;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.Operator;
			parameters[6].Value = model.OperateTime;
			parameters[7].Value = model.LostID;

			int rows=new DbHelperSQL().ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string LostID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Lost ");
			strSql.Append(" where LostID=@LostID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LostID", SqlDbType.VarChar,36)			};
			parameters[0].Value = LostID;

			int rows=new DbHelperSQL().ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string LostIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Lost ");
			strSql.Append(" where LostID in ("+LostIDlist + ")  ");
			int rows=new DbHelperSQL().ExecuteSql(strSql.ToString());
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
		public BusinessEntity.Model.Lost GetModel(string LostID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LostID,MemberID,Reason,Note,LostTime,Status,Operator,OperateTime from T_Lost ");
			strSql.Append(" where LostID=@LostID ");
			SqlParameter[] parameters = {
					new SqlParameter("@LostID", SqlDbType.VarChar,36)			};
			parameters[0].Value = LostID;

			BusinessEntity.Model.Lost model=new BusinessEntity.Model.Lost();
			DataSet ds=new DbHelperSQL().Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public BusinessEntity.Model.Lost DataRowToModel(DataRow row)
		{
			BusinessEntity.Model.Lost model=new BusinessEntity.Model.Lost();
			if (row != null)
			{
				if(row["LostID"]!=null)
				{
					model.LostID=row["LostID"].ToString();
				}
				if(row["MemberID"]!=null)
				{
					model.MemberID=row["MemberID"].ToString();
				}
				if(row["Reason"]!=null)
				{
					model.Reason=row["Reason"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["LostTime"]!=null && row["LostTime"].ToString()!="")
				{
					model.LostTime=DateTime.Parse(row["LostTime"].ToString());
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["Operator"]!=null)
				{
					model.Operator=row["Operator"].ToString();
				}
				if(row["OperateTime"]!=null && row["OperateTime"].ToString()!="")
				{
					model.OperateTime=DateTime.Parse(row["OperateTime"].ToString());
				}
                if (row["OperatorName"] != null && row["OperatorName"].ToString() != "")
                {
                    model.OperatorName = row["OperatorName"].ToString();
                }
                if (row["MemberCardID"] != null && row["MemberCardID"].ToString() != "")
                {
                    model.MemberCardID = row["MemberCardID"].ToString();
                }

                if (row["MemberName"] != null && row["MemberName"].ToString() != "")
                {
                    model.MemberName = row["MemberName"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select a.*, b.OperateName as OperatorName, c.MemberCardID, c.MemberName");
            strSql.Append(" FROM T_Lost a left join T_Operator b on a.Operator = b.OperateID_");
            strSql.Append(" left join T_Member c on a.MemberID = c.MemberID");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return new DbHelperSQL().Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" LostID,MemberID,Reason,Note,LostTime,Status,Operator,OperateTime ");
			strSql.Append(" FROM T_Lost ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return new DbHelperSQL().Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_Lost ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.LostID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Lost T ");
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
			parameters[0].Value = "T_Lost";
			parameters[1].Value = "LostID";
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

        public System.Collections.Generic.List<Model.Lost> GetList()
        {
            DataSet ds = GetList("");
            List<Lost> list = new List<Lost>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }

            return list;
        }
    }
}

