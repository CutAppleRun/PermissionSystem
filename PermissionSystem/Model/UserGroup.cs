using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class UserGroup
	{
		public UserGroup()
		{}
		#region Model
		private long _user_group_id;
		private long _user_id;
		private long _group_id;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long user_group_id
		{
			set{ _user_group_id=value;}
			get{return _user_group_id;}
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
		/// 组
		/// </summary>
		public long group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		#endregion Model
	}
}

