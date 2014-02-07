using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

namespace BusinessEntity
{
    /// <summary>
    /// 模块：LE0004(业务逻辑枚举集合)
    /// 作用：该集合包含了所有业务逻辑中涉及的枚举类型
    /// 作者：phq
    /// 日期：2011-11-03
    /// </summary>
    public enum OPStatus
    {
        [XmlEnum(Name = "Add")]
        Add,
        [XmlEnum(Name = "Modify")]
        Modify,
        [XmlEnum(Name = "Delete")]
        Delete,
        [XmlEnum(Name = "Normal")]
        Normal
    }
 


    public enum Gender
    {
        [XmlEnum(Name = "Male")]
        男,
        [XmlEnum(Name = "Female")]
        女
    }

    public enum Marriage
    {
        [XmlEnum(Name = "Single")]
        未婚,
        [XmlEnum(Name = "Married")]
        已婚,
        [XmlEnum(Name = "divorced")]
        离异
    }

    public enum Literacy
    {
        [XmlEnum(Name = "OrdinaryHighMiddleSchool")]
        高中,
        [XmlEnum(Name = "Single")]
        大学,
        [XmlEnum(Name = "Bachelor")]
        学士,
        [XmlEnum(Name = "Master")]
        硕士,
        [XmlEnum(Name = "Docter")]
        博士
    }

}
