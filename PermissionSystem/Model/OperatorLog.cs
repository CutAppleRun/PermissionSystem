using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class OperatorLog
	{
		public OperatorLog()
		{}
		#region Model
		private long _operator_log_id;
		private string _operator_type;
		private string _operator_content;
		private long _user_id;
		private DateTime _operator_time;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long operator_log_id
		{
			set{ _operator_log_id=value;}
			get{return _operator_log_id;}
		}
		/// <summary>
		/// 操作类型
		/// </summary>
		public string operator_type
		{
			set{ _operator_type=value;}
			get{return _operator_type;}
		}
		/// <summary>
		/// 操作内容
		/// </summary>
		public string operator_content
		{
			set{ _operator_content=value;}
			get{return _operator_content;}
		}
		/// <summary>
		/// 用户
		/// </summary>
		public long user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime operator_time
		{
			set{ _operator_time=value;}
			get{return _operator_time;}
		}
		#endregion Model
	}
}

