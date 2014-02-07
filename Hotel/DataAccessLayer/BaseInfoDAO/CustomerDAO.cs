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
    /// 数据访问类:Customer
    /// </summary>
    public partial class CustomerDAO
    {
        public CustomerDAO()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BusinessEntity.Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Customer(");
            strSql.Append("CustomerID,Name,CarType,CarNum,BirthDay,Sex,FromArea,ShengShi,Address,CustomerType,From,ImportantInfo,Note)");
            strSql.Append(" values (");
            strSql.Append("@CustomerID,@Name,@CarType,@CarNum,@BirthDay,@Sex,@FromArea,@ShengShi,@Address,@CustomerType,@From,@ImportantInfo,@Note)");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@CarType", SqlDbType.VarChar,50),
					new SqlParameter("@CarNum", SqlDbType.VarChar,100),
					new SqlParameter("@BirthDay", SqlDbType.DateTime),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@FromArea", SqlDbType.VarChar,36),
					new SqlParameter("@ShengShi", SqlDbType.VarChar,100),
					new SqlParameter("@Address", SqlDbType.VarChar,150),
					new SqlParameter("@CustomerType", SqlDbType.VarChar,36),
					new SqlParameter("@From", SqlDbType.VarChar,36),
					new SqlParameter("@ImportantInfo", SqlDbType.VarChar,100),
					new SqlParameter("@Note", SqlDbType.VarChar,200)};
            parameters[0].Value = model.CustomerID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.CarType;
            parameters[3].Value = model.CarNum;
            parameters[4].Value = model.BirthDay;
            parameters[5].Value = model.Sex;
            parameters[6].Value = model.FromArea;
            parameters[7].Value = model.ShengShi;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.CustomerType;
            parameters[10].Value = model.From;
            parameters[11].Value = model.ImportantInfo;
            parameters[12].Value = model.Note;

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
        public bool Update(BusinessEntity.Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Customer set ");
            strSql.Append("Name=@Name,");
            strSql.Append("CarType=@CarType,");
            strSql.Append("CarNum=@CarNum,");
            strSql.Append("BirthDay=@BirthDay,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("FromArea=@FromArea,");
            strSql.Append("ShengShi=@ShengShi,");
            strSql.Append("Address=@Address,");
            strSql.Append("CustomerType=@CustomerType,");
            strSql.Append("From=@From,");
            strSql.Append("ImportantInfo=@ImportantInfo,");
            strSql.Append("Note=@Note");
            strSql.Append(" where CustomerID=@CustomerID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@CarType", SqlDbType.VarChar,50),
					new SqlParameter("@CarNum", SqlDbType.VarChar,100),
					new SqlParameter("@BirthDay", SqlDbType.DateTime),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@FromArea", SqlDbType.VarChar,36),
					new SqlParameter("@ShengShi", SqlDbType.VarChar,100),
					new SqlParameter("@Address", SqlDbType.VarChar,150),
					new SqlParameter("@CustomerType", SqlDbType.VarChar,36),
					new SqlParameter("@From", SqlDbType.VarChar,36),
					new SqlParameter("@ImportantInfo", SqlDbType.VarChar,100),
					new SqlParameter("@Note", SqlDbType.VarChar,200),
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.CarType;
            parameters[2].Value = model.CarNum;
            parameters[3].Value = model.BirthDay;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.FromArea;
            parameters[6].Value = model.ShengShi;
            parameters[7].Value = model.Address;
            parameters[8].Value = model.CustomerType;
            parameters[9].Value = model.From;
            parameters[10].Value = model.ImportantInfo;
            parameters[11].Value = model.Note;
            parameters[12].Value = model.CustomerID;

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
        public bool Delete(string CustomerID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Customer ");
            strSql.Append(" where CustomerID=@CustomerID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36)			};
            parameters[0].Value = CustomerID;

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
        public bool DeleteList(string CustomerIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Customer ");
            strSql.Append(" where CustomerID in (" + CustomerIDlist + ")  ");
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
        public BusinessEntity.Model.Customer GetModel(string CustomerID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CustomerID,Name,CarType,CarNum,BirthDay,Sex,FromArea,ShengShi,Address,CustomerType,[From],ImportantInfo,Note from T_Customer ");
            strSql.Append(" where CustomerID=@CustomerID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36)			};
            parameters[0].Value = CustomerID;

            BusinessEntity.Model.Customer model = new BusinessEntity.Model.Customer();
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
        public BusinessEntity.Model.Customer DataRowToModel(DataRow row)
        {
            BusinessEntity.Model.Customer model = new BusinessEntity.Model.Customer();
            if (row != null)
            {
                if (row["CustomerID"] != null)
                {
                    model.CustomerID = row["CustomerID"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["CarType"] != null)
                {
                    model.CarType = row["CarType"].ToString();
                }
                if (row["CarNum"] != null)
                {
                    model.CarNum = row["CarNum"].ToString();
                }
                if (row["BirthDay"] != null && row["BirthDay"].ToString() != "")
                {
                    model.BirthDay = DateTime.Parse(row["BirthDay"].ToString());
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["FromArea"] != null)
                {
                    model.FromArea = row["FromArea"].ToString();
                }
                if (row["ShengShi"] != null)
                {
                    model.ShengShi = row["ShengShi"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["CustomerType"] != null)
                {
                    model.CustomerType = row["CustomerType"].ToString();
                }
                if (row["From"] != null)
                {
                    model.From = row["From"].ToString();
                }
                if (row["ImportantInfo"] != null)
                {
                    model.ImportantInfo = row["ImportantInfo"].ToString();
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
        public DataSet GetDataSetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CustomerID,Name,CarType,CarNum,BirthDay,Sex,FromArea,ShengShi,Address,CustomerType,[From],ImportantInfo,Note ");
            strSql.Append(" FROM T_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return new DbHelperSQL().Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetDataSetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" CustomerID,Name,CarType,CarNum,BirthDay,Sex,FromArea,ShengShi,Address,CustomerType,[From],ImportantInfo,Note ");
            strSql.Append(" FROM T_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return new DbHelperSQL().Query(strSql.ToString());
        }

        public List<Customer> GetList()
        {
            DataSet ds = GetDataSetList("");
            List<Customer> list = new List<Customer>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(DataRowToModel(row));
            }
            return list;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_Customer ");
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
                strSql.Append("order by T.CustomerID desc");
            }
            strSql.Append(")AS Row, T.*  from T_Customer T ");
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
            parameters[0].Value = "T_Customer";
            parameters[1].Value = "CustomerID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        internal CommandInfo GetAddSql(Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Customer(");
            strSql.Append("CustomerID,Name,CarType,CarNum,BirthDay,Sex,FromArea,ShengShi,Address,CustomerType,[From],ImportantInfo,Note)");
            strSql.Append(" values (");
            strSql.Append("@CustomerID,@Name,@CarType,@CarNum,@BirthDay,@Sex,@FromArea,@ShengShi,@Address,@CustomerType,@From,@ImportantInfo,@Note)");
            SqlParameter[] parameters = {
					new SqlParameter("@CustomerID", SqlDbType.VarChar,36),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@CarType", SqlDbType.VarChar,50),
					new SqlParameter("@CarNum", SqlDbType.VarChar,100),
					new SqlParameter("@BirthDay", SqlDbType.DateTime),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@FromArea", SqlDbType.VarChar,36),
					new SqlParameter("@ShengShi", SqlDbType.VarChar,100),
					new SqlParameter("@Address", SqlDbType.VarChar,150),
					new SqlParameter("@CustomerType", SqlDbType.VarChar,36),
					new SqlParameter("@From", SqlDbType.VarChar,36),
					new SqlParameter("@ImportantInfo", SqlDbType.VarChar,100),
					new SqlParameter("@Note", SqlDbType.VarChar,200)};
            parameters[0].Value = model.CustomerID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.CarType;
            parameters[3].Value = model.CarNum;
            parameters[4].Value = model.BirthDay;
            parameters[5].Value = model.Sex;
            parameters[6].Value = model.FromArea;
            parameters[7].Value = model.ShengShi;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.CustomerType;
            parameters[10].Value = model.From;
            parameters[11].Value = model.ImportantInfo;
            parameters[12].Value = model.Note;

            return new CommandInfo(strSql.ToString(), parameters);
        }
    }
}

