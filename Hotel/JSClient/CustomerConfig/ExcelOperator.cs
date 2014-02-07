using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OleDb; 
namespace Client
{
    /// <summary>
    /// 模块号：CC0003(用户配置)
    /// 作用：用户配置客户端应用配置类
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    public static class ExcelOperator
    {

        /// <summary>
        /// 从Excel导入
        /// </summary>
        /// <param name="strExcelFileName"></param>
        /// <param name="strSheetName"></param>
        /// <returns></returns>
        public static DataSet ExcelToDataTable(string strExcelFileName, string strSheetName)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties=Excel 8.0;";
            
            //string strExcel = string.Format("SELECT * FROM [Sheet1$]");
            string strExcel = string.Format("SELECT * FROM " + strSheetName);
            DataSet ds = new DataSet();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                adapter.Fill(ds);
                conn.Close();
            }
            return ds;
        }
        
    }
}
