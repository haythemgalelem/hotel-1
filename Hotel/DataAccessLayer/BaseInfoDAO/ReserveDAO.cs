using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using DataAccessLayer;
using BusinessEntity.Model;//Please add references
namespace BusinessEntity.DAL
{
	/// <summary>
	/// 数据访问类:Reserve
	/// </summary>
	public partial class ReserveDAO
	{
        public ReserveDAO()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ReserveID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Reserve");
			strSql.Append(" where ReserveID=@ReserveID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReserveID", SqlDbType.VarChar,36)			};
			parameters[0].Value = ReserveID;

			return new DbHelperSQL().Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(BusinessEntity.Model.Reserve model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Reserve(");
			strSql.Append("ReserveID,ReserveCode,Name,Tel,ArriveTime,KeepTime,Note,Status,RegTime)");
			strSql.Append(" values (");
			strSql.Append("@ReserveID,@ReserveCode,@Name,@Tel,@ArriveTime,@KeepTime,@Note,@Status,@RegTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@ReserveID", SqlDbType.VarChar,36),
					new SqlParameter("@ReserveCode", SqlDbType.VarChar,40),
					new SqlParameter("@Name", SqlDbType.VarChar,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@ArriveTime", SqlDbType.DateTime),
					new SqlParameter("@KeepTime", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@Status", SqlDbType.VarChar,40),
					new SqlParameter("@RegTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ReserveID;
			parameters[1].Value = model.ReserveCode;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Tel;
			parameters[4].Value = model.ArriveTime;
			parameters[5].Value = model.KeepTime;
			parameters[6].Value = model.Note;
			parameters[7].Value = model.Status;
			parameters[8].Value = model.RegTime;

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
		public bool Update(BusinessEntity.Model.Reserve model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Reserve set ");
			strSql.Append("ReserveCode=@ReserveCode,");
			strSql.Append("Name=@Name,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("ArriveTime=@ArriveTime,");
			strSql.Append("KeepTime=@KeepTime,");
			strSql.Append("Note=@Note,");
			strSql.Append("Status=@Status,");
			strSql.Append("RegTime=@RegTime");
			strSql.Append(" where ReserveID=@ReserveID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReserveCode", SqlDbType.VarChar,40),
					new SqlParameter("@Name", SqlDbType.VarChar,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@ArriveTime", SqlDbType.DateTime),
					new SqlParameter("@KeepTime", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@Status", SqlDbType.VarChar,40),
					new SqlParameter("@RegTime", SqlDbType.DateTime),
					new SqlParameter("@ReserveID", SqlDbType.VarChar,36)};
			parameters[0].Value = model.ReserveCode;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Tel;
			parameters[3].Value = model.ArriveTime;
			parameters[4].Value = model.KeepTime;
			parameters[5].Value = model.Note;
			parameters[6].Value = model.Status;
			parameters[7].Value = model.RegTime;
			parameters[8].Value = model.ReserveID;

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
		public bool Delete(string ReserveID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Reserve ");
			strSql.Append(" where ReserveID=@ReserveID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReserveID", SqlDbType.VarChar,36)			};
			parameters[0].Value = ReserveID;

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
		public bool DeleteList(string ReserveIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Reserve ");
			strSql.Append(" where ReserveID in ("+ReserveIDlist + ")  ");
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
		public BusinessEntity.Model.Reserve GetModel(string ReserveID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ReserveID,ReserveCode,Name,Tel,ArriveTime,KeepTime,Note,Status,RegTime from T_Reserve ");
			strSql.Append(" where ReserveID=@ReserveID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ReserveID", SqlDbType.VarChar,36)			};
			parameters[0].Value = ReserveID;

			BusinessEntity.Model.Reserve model=new BusinessEntity.Model.Reserve();
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
		public BusinessEntity.Model.Reserve DataRowToModel(DataRow row)
		{
			BusinessEntity.Model.Reserve model=new BusinessEntity.Model.Reserve();
			if (row != null)
			{
				if(row["ReserveID"]!=null)
				{
					model.ReserveID=row["ReserveID"].ToString();
				}
				if(row["ReserveCode"]!=null)
				{
					model.ReserveCode=row["ReserveCode"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["ArriveTime"]!=null && row["ArriveTime"].ToString()!="")
				{
					model.ArriveTime=DateTime.Parse(row["ArriveTime"].ToString());
				}
				if(row["KeepTime"]!=null && row["KeepTime"].ToString()!="")
				{
					model.KeepTime=DateTime.Parse(row["KeepTime"].ToString());
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
				if(row["RegTime"]!=null && row["RegTime"].ToString()!="")
				{
					model.RegTime=DateTime.Parse(row["RegTime"].ToString());
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
			strSql.Append("select ReserveID,ReserveCode,Name,Tel,ArriveTime,KeepTime,Note,Status,RegTime ");
			strSql.Append(" FROM T_Reserve ");
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
			strSql.Append(" ReserveID,ReserveCode,Name,Tel,ArriveTime,KeepTime,Note,Status,RegTime ");
			strSql.Append(" FROM T_Reserve ");
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
			strSql.Append("select count(1) FROM T_Reserve ");
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
				strSql.Append("order by T.ReserveID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Reserve T ");
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
			parameters[0].Value = "T_Reserve";
			parameters[1].Value = "ReserveID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return new DbHelperSQL().RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod

        #region  ExtensionMethod
        public List<Reserve> GetList()
        {
            DataSet ds = GetList("");
            List<Reserve> list = new List<Reserve>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }
            return list;
        }
        #endregion  ExtensionMethod

        public List<string> GetRoomIDsByReserveID(string ReserveID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Reserve2Room where ReserveID = @ReserveID");

            SqlParameter[] paras = {
                    new SqlParameter("@ReserveID", SqlDbType.VarChar, 36)
                                   };
            paras[0].Value = ReserveID;

            DataSet ds = new DbHelperSQL().Query(strSql.ToString(), paras);

            List<string> ids = new List<string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["RoomID"] != null && row["RoomID"].ToString() != "")
                {
                    ids.Add(row["RoomID"].ToString());
                }
            }

            return ids;
        }

        public void UpdateTran(Reserve model)
        {
            try 
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update T_Reserve set ");
                strSql.Append("ReserveCode=@ReserveCode,");
                strSql.Append("Name=@Name,");
                strSql.Append("Tel=@Tel,");
                strSql.Append("ArriveTime=@ArriveTime,");
                strSql.Append("KeepTime=@KeepTime,");
                strSql.Append("Note=@Note,");
                strSql.Append("Status=@Status,");
                strSql.Append("RegTime=@RegTime");
                strSql.Append(" where ReserveID=@ReserveID ");
                SqlParameter[] parameters = {
					    new SqlParameter("@ReserveCode", SqlDbType.VarChar,40),
					    new SqlParameter("@Name", SqlDbType.VarChar,10),
					    new SqlParameter("@Tel", SqlDbType.VarChar,20),
					    new SqlParameter("@ArriveTime", SqlDbType.DateTime),
					    new SqlParameter("@KeepTime", SqlDbType.DateTime),
					    new SqlParameter("@Note", SqlDbType.VarChar,1000),
					    new SqlParameter("@Status", SqlDbType.VarChar,40),
					    new SqlParameter("@RegTime", SqlDbType.DateTime),
					    new SqlParameter("@ReserveID", SqlDbType.VarChar,36)};
                parameters[0].Value = model.ReserveCode;
                parameters[1].Value = model.Name;
                parameters[2].Value = model.Tel;
                parameters[3].Value = model.ArriveTime;
                parameters[4].Value = model.KeepTime;
                parameters[5].Value = model.Note;
                parameters[6].Value = model.Status;
                parameters[7].Value = model.RegTime;
                parameters[8].Value = model.ReserveID;

                List<CommandInfo> cmds = new List<CommandInfo>();

                if (model.arr_Rooms != null && model.arr_Rooms.Count > 0)
                {
                        //先删除房间再添加房间
                        string delSql = "delete from T_Reserve2Room where ReserveID = @ReserveID";
                        SqlParameter[] delPara = {new SqlParameter("@ReserveID", model.ReserveID)};
                        cmds.Add(new CommandInfo(delSql, delPara));

                        //添加房间
                        foreach (Room r in model.arr_Rooms)
                        {
                            string sql = "insert into T_Reserve2Room values(@ID, @ReserveID, @RoomID)";
                            SqlParameter[] paras = {
                                  new SqlParameter("@ID", SqlDbType.VarChar, 36),
                                  new SqlParameter("@ReserveID", SqlDbType.VarChar, 36),
                                  new SqlParameter("@RoomID", SqlDbType.VarChar, 36)
                                               };
                            paras[0].Value = Guid.NewGuid().ToString();
                            paras[1].Value = model.ReserveID;
                            paras[2].Value = r.RoomID;

                            cmds.Add(new CommandInfo(sql, paras));
                        }
                    }

                cmds.Add(new CommandInfo(strSql.ToString(), parameters));

                new DbHelperSQL().ExecuteSqlTran(cmds);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public void AddTran(Reserve model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into T_Reserve(");
                strSql.Append("ReserveID,ReserveCode,Name,Tel,ArriveTime,KeepTime,Note,Status,RegTime)");
                strSql.Append(" values (");
                strSql.Append("@ReserveID,@ReserveCode,@Name,@Tel,@ArriveTime,@KeepTime,@Note,@Status,@RegTime)");
                SqlParameter[] parameters = {
					new SqlParameter("@ReserveID", SqlDbType.VarChar,36),
					new SqlParameter("@ReserveCode", SqlDbType.VarChar,40),
					new SqlParameter("@Name", SqlDbType.VarChar,10),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@ArriveTime", SqlDbType.DateTime),
					new SqlParameter("@KeepTime", SqlDbType.DateTime),
					new SqlParameter("@Note", SqlDbType.VarChar,1000),
					new SqlParameter("@Status", SqlDbType.VarChar,40),
					new SqlParameter("@RegTime", SqlDbType.DateTime)};
                parameters[0].Value = model.ReserveID;
                parameters[1].Value = model.ReserveCode;
                parameters[2].Value = model.Name;
                parameters[3].Value = model.Tel;
                parameters[4].Value = model.ArriveTime;
                parameters[5].Value = model.KeepTime;
                parameters[6].Value = model.Note;
                parameters[7].Value = model.Status;
                parameters[8].Value = model.RegTime;

                List<CommandInfo> cmds = new List<CommandInfo>();

                if (model.arr_Rooms != null && model.arr_Rooms.Count > 0)
                {
                    foreach (Room r in model.arr_Rooms)
                    {
                        string sql = "insert into T_Reserve2Room values(@ID, @ReserveID, @RoomID)";
                        
                        SqlParameter[] paras = {
                              new SqlParameter("@ID", SqlDbType.VarChar, 36),
                              new SqlParameter("@ReserveID", SqlDbType.VarChar, 36),
                              new SqlParameter("@RoomID", SqlDbType.VarChar, 36)
                                           };
                        paras[0].Value = Guid.NewGuid().ToString();
                        paras[1].Value = model.ReserveID;
                        paras[2].Value = r.RoomID;

                        cmds.Add(new CommandInfo(sql, paras));
                        cmds.Add(new RoomDAO().GetUpdateStatusSql(r, "预订"));
                    }
                }

                cmds.Add(new CommandInfo(strSql.ToString(), parameters));

                new DbHelperSQL().ExecuteSqlTran(cmds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

