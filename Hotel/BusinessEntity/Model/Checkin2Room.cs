using System;
namespace BusinessEntity.Model
{
	/// <summary>
	/// 入住单房间
	/// </summary>
	[Serializable]
	public partial class Checkin2Room : EntityBase
	{
		public Checkin2Room()
		{}
		#region Model
		private string _checkin2roomid;
		private string _checkinid;
		private string _roomid;
		private string _note;
		private string _checkintype;
		private decimal? _originalprice;
		private decimal? _totalprice;
		private int? _discount;
		private decimal? _discountprice;
		private int? _timecount;
		private DateTime? _checkouttime;
		private int? _ischeckout;
		private DateTime? _realcheckouttime;
		/// <summary>
		/// 
		/// </summary>
		public string Checkin2RoomID
		{
			set{ _checkin2roomid=value;}
			get{return _checkin2roomid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckinID
		{
			set{ _checkinid=value;}
			get{return _checkinid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoomID
		{
			set{ _roomid=value;}
			get{return _roomid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}
		/// <summary>
		/// 记天
        /// 钟点房
		/// </summary>
		public string CheckinType
		{
			set{ _checkintype=value;}
			get{return _checkintype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OriginalPrice
		{
			set{ _originalprice=value;}
			get{return _originalprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalPrice
		{
			set{ _totalprice=value;}
			get{return _totalprice;}
		}
		/// <summary>
		/// 取出%号后的数值
   
		/// </summary>
		public int? Discount
		{
			set{ _discount=value;}
			get{return _discount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DiscountPrice
		{
			set{ _discountprice=value;}
			get{return _discountprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TimeCount
		{
			set{ _timecount=value;}
			get{return _timecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CheckoutTime
		{
			set{ _checkouttime=value;}
			get{return _checkouttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsCheckOut
		{
			set{ _ischeckout=value;}
			get{return _ischeckout;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RealCheckoutTime
		{
			set{ _realcheckouttime=value;}
			get{return _realcheckouttime;}
		}


		#endregion Model

        public string RoomTypeName { get; set; }
        public string RoomCode { get; set; }

        //方便删除
        public bool WillDel = false;
	}
}

