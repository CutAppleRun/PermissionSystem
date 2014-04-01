using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class UserRole
	{
		public UserRole()
		{}
		#region Model
		private long _user_role_id;
		private long _user_id;
		private long _role_id;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long user_role_id
		{
			set{ _user_role_id=value;}
			get{return _user_role_id;}
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
		/// 角色
		/// </summary>
		public long role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		#endregion Model
	}
}

