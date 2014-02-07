using System;
namespace BusinessEntity.Model
{
	/// <summary>
	/// 房间信息
	/// </summary>
	[Serializable]
	public partial class Room : EntityBase
	{
		public Room()
		{}
		#region Model
		private string _roomid;
		private string _roomtype;
		private string _buildingid;
		private string _floorid;
		private string _roomno;
		private string _phone;
		private int? _isownuse;
		private string _status;
		private int? _bednum;
		private string _description;
		private string _note;
		private int? _isdel;
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
		public string RoomType
		{
			set{ _roomtype=value;}
			get{return _roomtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BuildingID
		{
			set{ _buildingid=value;}
			get{return _buildingid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FloorID
		{
			set{ _floorid=value;}
			get{return _floorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoomNo
		{
			set{ _roomno=value;}
			get{return _roomno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsOwnUse
		{
			set{ _isownuse=value;}
			get{return _isownuse;}
		}
		/// <summary>
		/// 空房
   //脏房
   //住客
   //自用
   //维修
   //保留
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BedNum
		{
			set{ _bednum=value;}
			get{return _bednum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
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
		/// 
		/// </summary>
		public int? IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}

        public bool IsOwnUseChk
        {
            set
            {
                this.IsOwnUse = value == true ? 1 : 0;
            }
            get
            {
                return this.IsOwnUse == 1 ? true : false;
            }
        }

        public RoomType RoomTypeModel { get; set; }

        public string BuildingName { get; set; }
        public string LayerName { get; set; }
        public string RoomTypeName { get; set; }
		#endregion Model

	}
}

