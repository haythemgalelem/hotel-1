using System;
namespace BusinessEntity.Model
{
    /// <summary>
    /// 字典
    /// </summary>
    [Serializable]
    public  class DataDictionary : EntityBase
    {
        public DataDictionary()
        { }
        #region Model
        private Guid _datadictionaryid;
        private string _datadictionarycode;
        private string _datadictionaryname;
        private string _datadictionarydescription;
        private string _datadictionarytype;
        private int? _array;
        private bool _state;
        private string _note;
        private int? _operateid;
        private DateTime? _operatetime;
        /// <summary>
        /// 编号
        /// </summary>
        public Guid DataDictionaryID
        {
            set { _datadictionaryid = value; }
            get { return _datadictionaryid; }
        }
        /// <summary>
        /// 编码
        /// </summary>
        public string DataDictionaryCode
        {
            set { _datadictionarycode = value; }
            get { return _datadictionarycode; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string DataDictionaryName
        {
            set { _datadictionaryname = value; }
            get { return _datadictionaryname; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string DataDictionaryDescription
        {
            set { _datadictionarydescription = value; }
            get { return _datadictionarydescription; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string DataDictionaryType
        {
            set { _datadictionarytype = value; }
            get { return _datadictionarytype; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Array
        {
            set { _array = value; }
            get { return _array; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public bool State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 操作员ID
        /// </summary>
        public int? OperateID
        {
            set { _operateid = value; }
            get { return _operateid; }
        }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime? OperateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        #endregion Model

    }
}

