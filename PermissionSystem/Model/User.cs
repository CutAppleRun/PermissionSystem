using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class User
	{
		public User()
		{}
		#region Model
		private long _user_id;
		private long _organization_id;
		private string _user_name;
		private string _password;
		private string _vsername;
		private DateTime _create_time;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long user_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 组织
		/// </summary>
		public long organization_id
		{
			set{ _organization_id=value;}
			get{return _organization_id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string vsername
		{
			set{ _vsername=value;}
			get{return _vsername;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime create_time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		#endregion Model
	}
}

