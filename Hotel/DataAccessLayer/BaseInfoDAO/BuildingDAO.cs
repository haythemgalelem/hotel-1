using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Collections.Generic;
using BusinessEntity.Model;
using BusinessEntity.Other;
namespace BusinessEntity.DAL
{
	/// <summary>
	/// 数据访问类:Building
	/// </summary>
	public partial class BuildingDAO
	{
        public BuildingDAO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BusinessEntity.Model.Building model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Building(");
			strSql.Append("BuildingID,Name,Description,Note,Type,Layer,Father,IsDel)");
			strSql.Append(" values (");
			strSql.Append("@BuildingID,@Name,@Description,@Note,@Type,@Layer,@Father,@IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@BuildingID", SqlDbType.VarChar,36),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,100),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
					new SqlParameter("@Type", SqlDbType.VarChar,40),
					new SqlParameter("@Layer", SqlDbType.Int,4),
					new SqlParameter("@Father", SqlDbType.VarChar,36),
					new SqlParameter("@IsDel", SqlDbType.Int,4)};
			parameters[0].Value = model.BuildingID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.Note;
			parameters[4].Value = model.Type;
			parameters[5].Value = model.Layer;
			parameters[6].Value = model.Father;
			parameters[7].Value = model.IsDel;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(BusinessEntity.Model.Building model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Building set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Description=@Description,");
			strSql.Append("Note=@Note,");
			strSql.Append("Type=@Type,");
			strSql.Append("Layer=@Layer,");
			strSql.Append("Father=@Father,");
			strSql.Append("IsDel=@IsDel");
			strSql.Append(" where BuildingID=@BuildingID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.VarChar,100),
					new SqlParameter("@Note", SqlDbType.VarChar,100),
					new SqlParameter("@Type", SqlDbType.VarChar,40),
					new SqlParameter("@Layer", SqlDbType.Int,4),
					new SqlParameter("@Father", SqlDbType.VarChar,36),
					new SqlParameter("@IsDel", SqlDbType.Int,4),
					new SqlParameter("@BuildingID", SqlDbType.VarChar,36)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Description;
			parameters[2].Value = model.Note;
			parameters[3].Value = model.Type;
			parameters[4].Value = model.Layer;
			parameters[5].Value = model.Father;
			parameters[6].Value = model.IsDel;
			parameters[7].Value = model.BuildingID;

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
		public bool Delete(string BuildingID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Building ");
			strSql.Append(" where BuildingID=@BuildingID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BuildingID", SqlDbType.VarChar,36)			};
			parameters[0].Value = BuildingID;

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
		public bool DeleteList(string BuildingIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Building ");
			strSql.Append(" where BuildingID in ("+BuildingIDlist + ")  ");
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
		public BusinessEntity.Model.Building GetModel(string BuildingID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BuildingID,Name,Description,Note,Type,Layer,Father,IsDel from T_Building ");
			strSql.Append(" where BuildingID=@BuildingID ");
			SqlParameter[] parameters = {
					new SqlParameter("@BuildingID", SqlDbType.VarChar,36)			};
			parameters[0].Value = BuildingID;

			BusinessEntity.Model.Building model=new BusinessEntity.Model.Building();
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
		public BusinessEntity.Model.Building DataRowToModel(DataRow row)
		{
			BusinessEntity.Model.Building model=new BusinessEntity.Model.Building();
			if (row != null)
			{
				if(row["BuildingID"]!=null)
				{
					model.BuildingID=row["BuildingID"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["Layer"]!=null && row["Layer"].ToString()!="")
				{
					model.Layer=int.Parse(row["Layer"].ToString());
				}
				if(row["Father"]!=null)
				{
					model.Father=row["Father"].ToString();
				}
				if(row["IsDel"]!=null && row["IsDel"].ToString()!="")
				{
					model.IsDel=int.Parse(row["IsDel"].ToString());
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
			strSql.Append("select BuildingID,Name,Description,Note,Type,Layer,Father,IsDel ");
			strSql.Append(" FROM T_Building ");
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
			strSql.Append(" BuildingID,Name,Description,Note,Type,Layer,Father,IsDel ");
			strSql.Append(" FROM T_Building ");
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
			strSql.Append("select count(1) FROM T_Building ");
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
				strSql.Append("order by T.BuildingID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Building T ");
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
			parameters[0].Value = "T_Building";
			parameters[1].Value = "BuildingID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return new DbHelperSQL().RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod


		#region  ExtensionMethod
        

        public System.Collections.Generic.List<Model.Building> GetList()
        {
            DataSet ds = GetList("IsDel = 0");
            List<Building> list = new List<Building>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }

            return list;
        }

        public void Delete(List<Other.RoomTreeModel> builds, List<Other.RoomTreeModel> rooms)
        {
            List<CommandInfo> cmds = new List<CommandInfo>();
            cmds.Add(GetDelCmd(builds));
            cmds.Add(new RoomDAO().GetDelCmd(rooms));

            new DbHelperSQL().ExecuteSqlTran(cmds);
        }

        private CommandInfo GetDelCmd(List<Other.RoomTreeModel> builds)
        {
            StringBuilder buf = new StringBuilder();
            foreach (RoomTreeModel rtm in builds)
            {
                buf.Append("'" + rtm.NodeID + "'");
                buf.Append(",");
            }
            if (buf.Length > 0)
            {
                buf.Remove(buf.Length - 1, 1);
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Building set IsDel = 1");
            strSql.Append(" where BuildingID in (" + buf.ToString() + ")  ");

            return new CommandInfo(strSql.ToString(), null);
        }

		#endregion  ExtensionMethod

        
    }
}
