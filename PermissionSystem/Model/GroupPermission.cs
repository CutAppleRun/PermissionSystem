using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class GroupPermission
	{
		public GroupPermission()
		{}
		#region Model
		private long _group_permission_id;
		private long _group_id;
		private long _permission_id;
		private long _permission_type_id;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long group_permission_id
		{
			set{ _group_permission_id=value;}
			get{return _group_permission_id;}
		}
		/// <summary>
		/// 组
		/// </summary>
		public long group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
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

