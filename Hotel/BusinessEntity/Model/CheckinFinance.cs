using System;
namespace BusinessEntity.Model
{
	/// <summary>
	/// 租房财务
	/// </summary>
	[Serializable]
	public partial class CheckinFinance
	{
		public CheckinFinance()
		{}
		#region Model
		private string _checkinfinanceid;
		private string _checkinfinancecode;
		private string _checkinid;
		private string _status;
		private decimal? _money;
		private int? _isoutbill;
		private string _operator;
		private DateTime? _operatetime;
		/// <summary>
		/// 
		/// </summary>
		public string CheckinFinanceID
		{
			set{ _checkinfinanceid=value;}
			get{return _checkinfinanceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckinFinanceCode
		{
			set{ _checkinfinancecode=value;}
			get{return _checkinfinancecode;}
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
		/// 已结
   //未结
   //逃款（部分逃款和全逃）只做全逃
   //免单
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsOutBill
		{
			set{ _isoutbill=value;}
			get{return _isoutbill;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Operator
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OperateTime
		{
			set{ _operatetime=value;}
			get{return _operatetime;}
		}
		#endregion Model

	}
}

