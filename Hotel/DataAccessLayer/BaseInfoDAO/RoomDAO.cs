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
	/// 数据访问类:Room
	/// </summary>
	public partial class RoomDAO
	{
        public RoomDAO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BusinessEntity.Model.Room model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Room(");
			strSql.Append("RoomID,RoomType,BuildingID,FloorID,RoomNo,Phone,IsOwnUse,Status,BedNum,Description,Note,IsDel)");
			strSql.Append(" values (");
			strSql.Append("@RoomID,@RoomType,@BuildingID,@FloorID,@RoomNo,@Phone,@IsOwnUse,@Status,@BedNum,@Description,@Note,@IsDel)");
			SqlParameter[] parameters = {
					new SqlParameter("@RoomID", SqlDbType.VarChar,36),
					new SqlParameter("@RoomType", SqlDbType.VarChar,36),
					new SqlParameter("@BuildingID", SqlDbType.VarChar,36),
					new SqlParameter("@FloorID", SqlDbType.VarChar,36),
					new SqlParameter("@RoomNo", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@IsOwnUse", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.VarChar,40),
					new SqlParameter("@BedNum", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,1000),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@IsDel", SqlDbType.Int,4)};
			parameters[0].Value = model.RoomID;
			parameters[1].Value = model.RoomType;
			parameters[2].Value = model.BuildingID;
			parameters[3].Value = model.FloorID;
			parameters[4].Value = model.RoomNo;
			parameters[5].Value = model.Phone;
			parameters[6].Value = model.IsOwnUse;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.BedNum;
			parameters[9].Value = model.Description;
			parameters[10].Value = model.Note;
			parameters[11].Value = model.IsDel;

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
		public bool Update(BusinessEntity.Model.Room model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Room set ");
			strSql.Append("RoomType=@RoomType,");
			strSql.Append("BuildingID=@BuildingID,");
			strSql.Append("FloorID=@FloorID,");
			strSql.Append("RoomNo=@RoomNo,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("IsOwnUse=@IsOwnUse,");
			strSql.Append("Status=@Status,");
			strSql.Append("BedNum=@BedNum,");
			strSql.Append("Description=@Description,");
			strSql.Append("Note=@Note,");
			strSql.Append("IsDel=@IsDel");
			strSql.Append(" where RoomID=@RoomID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoomType", SqlDbType.VarChar,36),
					new SqlParameter("@BuildingID", SqlDbType.VarChar,36),
					new SqlParameter("@FloorID", SqlDbType.VarChar,36),
					new SqlParameter("@RoomNo", SqlDbType.VarChar,50),
					new SqlParameter("@Phone", SqlDbType.VarChar,20),
					new SqlParameter("@IsOwnUse", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.VarChar,40),
					new SqlParameter("@BedNum", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.VarChar,1000),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@IsDel", SqlDbType.Int,4),
					new SqlParameter("@RoomID", SqlDbType.VarChar,36)};
			parameters[0].Value = model.RoomType;
			parameters[1].Value = model.BuildingID;
			parameters[2].Value = model.FloorID;
			parameters[3].Value = model.RoomNo;
			parameters[4].Value = model.Phone;
			parameters[5].Value = model.IsOwnUse;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.BedNum;
			parameters[8].Value = model.Description;
			parameters[9].Value = model.Note;
			parameters[10].Value = model.IsDel;
			parameters[11].Value = model.RoomID;

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
		public bool Delete(string RoomID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Room ");
			strSql.Append(" where RoomID=@RoomID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoomID", SqlDbType.VarChar,36)			};
			parameters[0].Value = RoomID;

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
		public bool DeleteList(string RoomIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Room ");
			strSql.Append(" where RoomID in ("+RoomIDlist + ")  ");
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
		public BusinessEntity.Model.Room GetModel(string RoomID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RoomID,RoomType,BuildingID,FloorID,RoomNo,Phone,IsOwnUse,Status,BedNum,Description,Note,IsDel from T_Room ");
			strSql.Append(" where RoomID=@RoomID ");
			SqlParameter[] parameters = {
					new SqlParameter("@RoomID", SqlDbType.VarChar,36)			};
			parameters[0].Value = RoomID;

			BusinessEntity.Model.Room model=new BusinessEntity.Model.Room();
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
		public BusinessEntity.Model.Room DataRowToModel(DataRow row)
		{
			BusinessEntity.Model.Room model=new BusinessEntity.Model.Room();
			if (row != null)
			{
				if(row["RoomID"]!=null)
				{
					model.RoomID=row["RoomID"].ToString();
				}
				if(row["RoomType"]!=null)
				{
					model.RoomType=row["RoomType"].ToString();
				}
				if(row["BuildingID"]!=null)
				{
					model.BuildingID=row["BuildingID"].ToString();
				}
				if(row["FloorID"]!=null)
				{
					model.FloorID=row["FloorID"].ToString();
				}
				if(row["RoomNo"]!=null)
				{
					model.RoomNo=row["RoomNo"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["IsOwnUse"]!=null && row["IsOwnUse"].ToString()!="")
				{
					model.IsOwnUse=int.Parse(row["IsOwnUse"].ToString());
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["BedNum"]!=null && row["BedNum"].ToString()!="")
				{
					model.BedNum=int.Parse(row["BedNum"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["IsDel"]!=null && row["IsDel"].ToString()!="")
				{
					model.IsDel=int.Parse(row["IsDel"].ToString());
				}
                if (row["RoomTypeName"] != null && row["RoomTypeName"].ToString() != "")
                {
                    model.RoomTypeName = row["RoomTypeName"].ToString();
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
            strSql.Append("select a.*, b.Name RoomTypeName");
			strSql.Append(" FROM T_Room a left join T_RoomType b on a.RoomType = b.ID");
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
			strSql.Append(" RoomID,RoomType,BuildingID,FloorID,RoomNo,Phone,IsOwnUse,Status,BedNum,Description,Note,IsDel ");
			strSql.Append(" FROM T_Room ");
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
			strSql.Append("select count(1) FROM T_Room ");
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
				strSql.Append("order by T.RoomID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Room T ");
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
			parameters[0].Value = "T_Room";
			parameters[1].Value = "RoomID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return new DbHelperSQL().RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod

        #region  ExtensionMethod

        public List<Room> GetList()
        {
            DataSet ds = GetList("IsDel = 0");
            List<Room> list = new List<Room>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }
            return list;
        }

        #endregion  ExtensionMethod

        internal CommandInfo GetDelCmd(List<Other.RoomTreeModel> rooms)
        {
            StringBuilder buf = new StringBuilder();
            foreach (RoomTreeModel rtm in rooms)
            {
                buf.Append("'" + rtm.NodeID + "'");
                buf.Append(",");
            }
            if (buf.Length > 0)
            {
                buf.Remove(buf.Length - 1, 1);
            }

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Room set IsDel = 1");
            strSql.Append(" where RoomID in (" + buf.ToString() + ")  ");

            return new CommandInfo(strSql.ToString(), null);
        }

        public List<Room> GetListByIDs(List<string> ids)
        {
            StringBuilder buf = new StringBuilder();
            foreach (string i in ids)
            {
                buf.Append("'" + i + "',");
            }
            buf.Remove(buf.Length - 1, 1);

            DataSet ds = GetList("IsDel = 0 and RoomID in (" + buf.ToString() + ")");
            List<Room> list = new List<Room>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }
            return list;
        }

        public CommandInfo GetUpdateStatusSql(Room model, string status)
        {
            string sql = "update T_Room set Status = @Status where RoomID = @RoomID";
            SqlParameter[] paras = { new SqlParameter("@Status", status),
                                     new SqlParameter("@RoomID", model.RoomID)
                                   };

            return new CommandInfo(sql, paras);
        }

        public CommandInfo GetUpdateStatusSql(string roomID, string status)
        {
            string sql = "update T_Room set Status = @Status where RoomID = @RoomID";
            SqlParameter[] paras = { new SqlParameter("@Status", status),
                                     new SqlParameter("@RoomID", roomID)
                                   };

            return new CommandInfo(sql, paras);
        }
    }
}

