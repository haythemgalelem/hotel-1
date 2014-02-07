using System;
namespace BusinessEntity.Model
{
    /// <summary>
    /// 租房财务中的其他帐目
    /// </summary>
    [Serializable]
    public partial class CheckinFinance2OtherFinance
    {
        public CheckinFinance2OtherFinance()
        { }
        #region Model
        private string _checkinfinance2otherfinanceid;
        private string _checkinfinanceid;
        private string _otherfinance;
        private string _note;
        /// <summary>
        /// 
        /// </summary>
        public string CheckinFinance2OtherFinanceID
        {
            set { _checkinfinance2otherfinanceid = value; }
            get { return _checkinfinance2otherfinanceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CheckinFinanceID
        {
            set { _checkinfinanceid = value; }
            get { return _checkinfinanceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OtherFinance
        {
            set { _otherfinance = value; }
            get { return _otherfinance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        #endregion Model

    }
}

