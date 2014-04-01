using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class RolePermission
	{
		public RolePermission()
		{}
		#region Model
		private long _role_permission_id;
		private long _role_id;
		private long _permission_id;
		private long _permission_type_id;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long role_permission_id
		{
			set{ _role_permission_id=value;}
			get{return _role_permission_id;}
		}
		/// <summary>
		/// 角色
		/// </summary>
		public long role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
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

