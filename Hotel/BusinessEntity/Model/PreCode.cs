using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntity.Model
{
    /// <summary>
    /// T_PreCode:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class PreCod : EntityBase
    {
        public PreCod()
        { }
        #region Model
        private Guid _preid;
        private string _pretype;
        private string _precode;
        private int? _array;
        private int? _presum;
        private Guid _userid;
        private DateTime? _usertime;
        /// <summary>
        /// 
        /// </summary>
        public Guid PreID
        {
            set { _preid = value; }
            get { return _preid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PreType
        {
            set { _pretype = value; }
            get { return _pretype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PreCode
        {
            set { _precode = value; }
            get { return _precode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Array
        {
            set { _array = value; }
            get { return _array; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PreSum
        {
            set { _presum = value; }
            get { return _presum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UserTime
        {
            set { _usertime = value; }
            get { return _usertime; }
        }
        #endregion Model

    }
}
