using System;
namespace BusinessEntity.Model
{
    /// <summary>
    /// 会员类型
    /// </summary>
    [Serializable]
    public partial class MemberType : EntityBase
    {
        public MemberType()
        { }
        #region Model
        private string _membertypeid;
        private string _typename;
        private decimal? _basediscount;
        private string _scoreincrease;
        private string _note;
        /// <summary>
        /// 
        /// </summary>
        public string MemberTypeID
        {
            set { _membertypeid = value; }
            get { return _membertypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BaseDiscount
        {
            set { _basediscount = value; }
            get { return _basediscount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ScoreIncrease
        {
            set { _scoreincrease = value; }
            get { return _scoreincrease; }
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

        public override string ToString()
        {
            return TypeName;
        }
    }
}

