using System;
using System.Collections.Generic;
namespace BusinessEntity.Model
{
    /// <summary>
    /// 入住单
    /// </summary>
    [Serializable]
    public partial class Checkin
    {
        public Checkin()
        { }
        #region Model
        private string _checkinid;
        private string _checkincode;
        private string _customerid;
        private string _note;
        private string _customertype;
        private string _memberid;
        /// <summary>
        /// 
        /// </summary>
        public string CheckinID
        {
            set { _checkinid = value; }
            get { return _checkinid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CheckinCode
        {
            set { _checkincode = value; }
            get { return _checkincode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerID
        {
            set { _customerid = value; }
            get { return _customerid; }
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
        public string CustomerType
        {
            set { _customertype = value; }
            get { return _customertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MemberID
        {
            set { _memberid = value; }
            get { return _memberid; }
        }
        #endregion Model

        public List<Checkin2Room> arr_Rooms { get; set; }
        public Customer Customer = new Customer();
        public CheckinFinance Finance = new CheckinFinance();

        public string FinanceStatus { get; set; }

        public string Money { get; set; }

        public string CustomerName { get; set; }
    }
}

