using System;
namespace BusinessEntity.Model
{
    /// <summary>
    /// 客户表
    /// </summary>
    [Serializable]
    public partial class Customer
    {
        public Customer()
        { }
        #region Model
        private string _customerid;
        private string _name;
        private string _cartype;
        private string _carnum;
        private DateTime? _birthday;
        private string _sex;
        private string _fromarea;
        private string _shengshi;
        private string _address;
        private string _customertype;
        private string _from;
        private string _importantinfo;
        private string _note;
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
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CarType
        {
            set { _cartype = value; }
            get { return _cartype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CarNum
        {
            set { _carnum = value; }
            get { return _carnum; }
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
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FromArea
        {
            set { _fromarea = value; }
            get { return _fromarea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShengShi
        {
            set { _shengshi = value; }
            get { return _shengshi; }
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
        public string CustomerType
        {
            set { _customertype = value; }
            get { return _customertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string From
        {
            set { _from = value; }
            get { return _from; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImportantInfo
        {
            set { _importantinfo = value; }
            get { return _importantinfo; }
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

