using System;
namespace BusinessEntity.Model
{
    /// <summary>
    /// 挂失
    /// </summary>
    [Serializable]
    public partial class Lost : EntityBase
    {
        public Lost()
        { }
        #region Model
        private string _lostid;
        private string _memberid;
        private string _reason;
        private string _note;
        private DateTime? _losttime;
        private string _status;
        private string _operator;
        private DateTime? _operatetime;
        /// <summary>
        /// 
        /// </summary>
        public string LostID
        {
            set { _lostid = value; }
            get { return _lostid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MemberID
        {
            set { _memberid = value; }
            get { return _memberid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Reason
        {
            set { _reason = value; }
            get { return _reason; }
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
        public DateTime? LostTime
        {
            set { _losttime = value; }
            get { return _losttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
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


        public string OperatorName { get; set; }

        public string MemberCardID { get; set; }

        public string MemberName { get; set; }
    }
}

