using System;
namespace BusinessEntity.Model
{
    /// <summary>
    /// 会员表
    /// </summary>
    [Serializable]
    public partial class Member : EntityBase
    {
        public Member()
        { }
        #region Model
        private string _memberid;
        private string _membercardid;
        private string _membername;
        private string _cardtype;
        private string _idcard;
        private string _sex;
        private DateTime? _birthday;
        private string _hometel;
        private string _mobiletel;
        private string _address;
        private int? _available;
        private string _pwd;
        private string _status;
        private DateTime? _regtime;
        private int? _score;
        private int? _times;
        private decimal? _discount;
        private decimal? _balance;
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
        public string MemberCardID
        {
            set { _membercardid = value; }
            get { return _membercardid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MemberName
        {
            set { _membername = value; }
            get { return _membername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardType
        {
            set { _cardtype = value; }
            get { return _cardtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDCard
        {
            set { _idcard = value; }
            get { return _idcard; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BirthDay
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HomeTel
        {
            set { _hometel = value; }
            get { return _hometel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobileTel
        {
            set { _mobiletel = value; }
            get { return _mobiletel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Available
        {
            set { _available = value; }
            get { return _available; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
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
        public DateTime? RegTime
        {
            set { _regtime = value; }
            get { return _regtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Score
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Times
        {
            set { _times = value; }
            get { return _times; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Balance
        {
            set { _balance = value; }
            get { return _balance; }
        }
        #endregion Model

        public string CardTypeName
        {
            get;
            set;
        }

        public bool AvailableChk
        {
            get
            {
                return Available == 1 ? true : false;
            }
            set
            {
                this.Available = value == true ? 1 : 0;
            }
        }
    }
}

