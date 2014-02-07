using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntity;
using DataAccessLayer;
using BusinessEntity.Model;


namespace JSService
{
    public partial class BusinessInfoService
    {
        #region------------------------------ 基础信息 ----------------------------------------------

        #region --数据字典---------------
        /// <summary>
        /// 获取数据字典model
        /// </summary>
        /// <param name="dataDictionaryID"></param>
        /// <returns></returns>
        public DataDictionary GetDataDictionaryModel(Guid dataDictionaryID)
        {
            return new DataDictionaryDAO().GetDataDictionaryModel(dataDictionaryID);
        }
        /// <summary>
        ///  获取数据字典list
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<DataDictionary> GetDataDictionaryList(string type)
        {
            return new DataDictionaryDAO().GetDataDictionaryList(type);
        }
        /// <summary>
        /// 数据字典操作
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="operateType">add,update,delete</param>
        /// <returns></returns>
        public object DataDictionary_Operate(DataDictionary dict, string operateType)
        {
            return new DataDictionaryDAO().DataDictionary_Operate(dict, operateType);
        }
        #endregion
    
        #endregion
    }
}