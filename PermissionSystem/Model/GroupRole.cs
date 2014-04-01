using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class GroupRole
	{
		public GroupRole()
		{}
		#region Model
		private long _group_role_id;
		private long _group_id;
		private long _role_id;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long group_role_id
		{
			set{ _group_role_id=value;}
			get{return _group_role_id;}
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

