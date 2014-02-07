using System;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
namespace BusinessEntity
{
    /// <summary>
    /// 模块：LE0002
    /// 作用：该类是所有业务实体的基类。
    /// 作者：phq
    /// 日期：2011-11-03
    /// 说明：
    /// </summary>
    [Serializable]
    public abstract class EntityBase:IBase  
    {
        //private string _ID;

        //public string ID
        //{
        //    get { return _ID; }
        //    set { _ID = value; }
        //}
        private bool _IsLock = false;
        //private bool _IsDelete = false;
        private OPStatus _oStatus = OPStatus.Normal;
        private bool _Choose = false;

        ///// <summary>
        ///// 该类的查询条件
        ///// </summary>
        //public static List<Condition> _SerachCondition = new List<Condition>();

        /// <summary>
        /// (基类)全局唯一标识
        /// </summary>
        //[XmlAttribute("ID"), Browsable(false)]
        //public string ID
        //{
        //    get { return _ID; }
        //    set { _ID = value; }
        //}

        /// <summary>
        /// (基类)是否锁定
        /// </summary>
        [XmlAttribute("IsLock"), Browsable(false)]
        public bool IsLock
        {
            get { return _IsLock; }
            set { _IsLock = value; }
        }

        ///// <summary>
        ///// (基类)是否作废
        ///// </summary>
        //[XmlAttribute("IsDelete"),Browsable(false)]
        //public bool IsDelete
        //{
        //    get { return _IsDelete; }
        //    set { _IsDelete = value; }
        //}

        /// <summary>
        /// (基类)对象的状态
        /// </summary>
        [DisplayName("状态"), Category("1.一般信息"), Description("")]
        public OPStatus oStatus
        {
            get { return _oStatus; }
            set { _oStatus = value; }
        }

        /// <summary>
        /// 是否选中
        /// </summary>
        [XmlIgnore]
        public bool Choose
        {
            get { return _Choose; }
            set { _Choose = value; }
        }

        public EntityBase()
        {
        }

        /// <summary>
        /// (基类)根据属性名获取该属性的值
        /// </summary>
        /// <param name="PropertyName">属性名</param>
        /// <returns>返回该属性的值(字符串)</returns>
        public string GetPropertyValue(string p_PropertyName)
        {
            try
            {
                Type t = this.GetType();
                PropertyInfo[] pis = t.GetProperties();
                foreach (PropertyInfo pi in pis)
                {
                    if (pi.Name.ToUpper() == p_PropertyName.ToUpper())
                    {
                        return pi.GetValue(this, null).ToString();
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// (基类)给属性赋值
        /// </summary>
        /// <param name="PropertyName">属性名</param>
        /// <param name="p_PropertyName">
        /// <returns>返回该属性的值(字符串)</returns>
        public void SetPropertyValue(string p_PropertyName,string Value)
        {
            try
            {
                Type t = this.GetType();
                PropertyInfo[] pis = t.GetProperties();
                foreach (PropertyInfo pi in pis)
                {
                    if (pi.Name.ToUpper() == p_PropertyName.ToUpper())
                    {
                        pi.SetValue(this, Value, null);
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// (基类)将对象序列化成XML文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public void Serialize(string p_Path)
        {
            try
            {
                XmlSerializer xls = new XmlSerializer(this.GetType());
                FileStream fs = new FileStream(p_Path, FileMode.Create);
                xls.Serialize(fs, this);
                fs.Close();
                fs = null;
                xls = null;
            }
            catch
            {
                Exception e = new Exception("ERROR-010004 无法将对象写入文件");
                throw e;
            }
        }

        /// <summary>
        /// (基类)将XML文件反序列化成对象
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回对象</returns>
        public EntityBase Deserialize(string p_Path)
        {
            try
            {
                XmlSerializer xls = new XmlSerializer(this.GetType());
                FileStream fs = new FileStream(p_Path, FileMode.Open);
                EntityBase pb = (EntityBase)xls.Deserialize(fs);
                fs.Close();
                fs = null;
                xls = null;
                return pb;
            }
            catch
            {
                Exception e = new Exception("ERROR-010005 无法从文件中读取对象");
                throw e;
            }
        }

        /// <summary>
        /// (基类)生成深副本
        /// </summary>
        /// <returns>返回深副本</returns>
        public EntityBase Copy()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            return (EntityBase)formatter.Deserialize(memoryStream);
            
        }

       
    }
}
