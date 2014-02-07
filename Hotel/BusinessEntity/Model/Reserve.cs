using System;
using System.Collections.Generic;
namespace BusinessEntity.Model
{
	/// <summary>
	/// 预订单
	/// </summary>
	[Serializable]
	public partial class Reserve :EntityBase
	{
		public Reserve()
		{}
		#region Model
		private string _reserveid;
		private string _reservecode;
		private string _name;
		private string _tel;
		private DateTime? _arrivetime;
		private DateTime? _keeptime;
		private string _note;
		private string _status;
		private DateTime? _regtime;
		/// <summary>
		/// 
		/// </summary>
		public string ReserveID
		{
			set{ _reserveid=value;}
			get{return _reserveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReserveCode
		{
			set{ _reservecode=value;}
			get{return _reservecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ArriveTime
		{
			set{ _arrivetime=value;}
			get{return _arrivetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? KeepTime
		{
			set{ _keeptime=value;}
			get{return _keeptime;}
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
		/// 等待
   //  中止
   //入住
   //超时
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		#endregion Model


        public List<Room> arr_Rooms;
	}
}

