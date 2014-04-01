using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class UserPermission
	{
		public UserPermission()
		{}
		#region Model
		private long _user_permission_id;
		private long _user_id;
		private long _permission_id;
		private long _permission_type_id;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long user_permission_id
		{
			set{ _user_permission_id=value;}
			get{return _user_permission_id;}
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
		/// 权限
		/// </summary>
		public long permission_id
		{
			set{ _permission_id=value;}
			get{return _permission_id;}
		}
		/// <summary>
		/// 权限类型
		/// </summary>
		public long permission_type_id
		{
			set{ _permission_type_id=value;}
			get{return _permission_type_id;}
		}
		#endregion Model
	}
}

