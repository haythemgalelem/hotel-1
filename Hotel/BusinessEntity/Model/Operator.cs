using System;
namespace BusinessEntity.Model
{
    /// <summary>
    /// c用户表
    /// </summary>
    [Serializable]
    public partial class Operator :EntityBase
    {
        public Operator()
        { }
        #region Model
        private string _operateid_;
        private string _operatecode;
        private string _operatename;
        private string _passwords;
        private int? _state;
        private string _note;
        private string _operatorid_;
        private DateTime? _operatetime;
        /// <summary>
        /// 
        /// </summary>
        public string OperateID_
        {
            set { _operateid_ = value; }
            get { return _operateid_; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OperateCode
        {
            set { _operatecode = value; }
            get { return _operatecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OperateName
        {
            set { _operatename = value; }
            get { return _operatename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Passwords
        {
            set { _passwords = value; }
            get { return _passwords; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OperatorID_
        {
            set { _operatorid_ = value; }
            get { return _operatorid_; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OperateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        #endregion Model

        public bool StateBool
        {

            get
            {
                return this._state != 0 ? true : false;
            }
            set
            {
                this._state = (value == true ? 1 : 0);
            }
        }
        public string OperatorName_Name
        {
            get;
            set;
        }

    }
}

