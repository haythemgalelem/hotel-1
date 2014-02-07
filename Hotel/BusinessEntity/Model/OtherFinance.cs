using System;
namespace BusinessEntity.Model
{
	/// <summary>
	/// 其他帐目
	/// </summary>
	[Serializable]
	public partial class OtherFinance
	{
		public OtherFinance()
		{}
		#region Model
		private string _otherfinanceid;
		private string _otherfinancecode;
		private string _purpost;
		private int? _inorout;
		private decimal? _money;
		private string _description;
		private string _note;
		private string _status;
		private string _operator;
		private DateTime? _operatetime;
		/// <summary>
		/// 
		/// </summary>
		public string OtherFinanceID
		{
			set{ _otherfinanceid=value;}
			get{return _otherfinanceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherFinanceCode
		{
			set{ _otherfinancecode=value;}
			get{return _otherfinancecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Purpost
		{
			set{ _purpost=value;}
			get{return _purpost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? InOrOut
		{
			set{ _inorout=value;}
			get{return _inorout;}
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

