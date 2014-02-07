﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Common.SearchCommon
{
    public class Manager
    {
        /// <summary>
        /// 解析查询条件中使用的变量
        /// </summary>
        /// <param name="p_Variable"></param>
        /// <returns></returns>
        public static object AnalysisVariable(object p_Variable)
        {
            switch (p_Variable.ToString())
            {
                case "[#DateTime.Now#]":
                    return DateTime.Now;
            }
            return null;
        }

        /// <summary>
        /// 将条件列表转换成表达式
        /// </summary>
        /// <param name="ConditionList">条件列表</param>
        /// <returns></returns>
        public static string GetQueryExpress(List<Condition> ConditionList)
        {
            string QuerExpress = "";
            foreach (Condition c in ConditionList)
            {
                    QuerExpress += " " + c.FieldName + " ";
                    QuerExpress += " " + c.Operator + " ";
                    QuerExpress += " " + CheckValue(c.Value, c.ValueType, c.Operator) + "";
                    QuerExpress += " and";
            }
            if (ConditionList.Count > 0)
            {
                QuerExpress = QuerExpress.Substring(0, QuerExpress.Length - 4);
            }
            return QuerExpress;
        }

        /// <summary>
        /// 将值转换成合适的值字符串
        /// 1.Number:  无需转换
        /// 2.String:  '值'
        /// 3.Date:    TO_DATE('值','YYYY-MM-DD')
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="ValueType"></param>
        /// <returns></returns>
        private static string CheckValue(object Value, SearchValueType Type, string Op)
        {
            string Result = "";
            switch (Type)
            {
                case SearchValueType.Number:
                    Result = Value.ToString();
                    break;
                case SearchValueType.String:
                    if (Op == "Like")
                    {
                        Result = "'%" + Value.ToString() + "%'";
                    }
                    else
                    {
                        Result = "'" + Value.ToString() + "'";
                    }
                    break;
                case SearchValueType.Date:
                   // Result = "TO_DATE('" + Value.ToString() + "','YYYY-MM-DD HH24:MI:SS')";//适用于oracle数据库
                    Result = "CAST('" + Value.ToString() + "' as datetime)";
                    break;
            }
            return Result;
        }
    }
}
