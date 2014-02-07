using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntity.Model;
using JSService;

namespace BusinessOperator
{
    /// <summary>
    /// 字典操作类
    /// </summary>
    public class DataDictionaryOperator
    {
        /// <summary>
        /// 获取数据字典model
        /// </summary>
        /// <param name="dataDictionaryID"></param>
        /// <returns></returns>
        public DataDictionary GetDataDictionaryModel(Guid dataDictionaryID)
        {
            return new BusinessInfoService().GetDataDictionaryModel(dataDictionaryID);
        }
        /// <summary>
        ///  获取数据字典list
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<DataDictionary> GetDataDictionaryList(string type)
        {
            return new BusinessInfoService().GetDataDictionaryList(type);
        }
        /// <summary>
        /// 数据字典操作
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="operateType">add,update,delete</param>
        /// <returns></returns>
        public object DataDictionary_Operate(DataDictionary dict, string operateType)
        {
            return new BusinessInfoService().DataDictionary_Operate(dict, operateType);
        } 
    }
}
