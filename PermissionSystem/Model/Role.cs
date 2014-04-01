using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class Role
	{
		public Role()
		{}
		#region Model
		private long _role_id;
		private long _parent_role_id;
		private string _role_name;
		private DateTime _create_time;
		private string _description;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 父角色
		/// </summary>
		public long parent_role_id
		{
			set{ _parent_role_id=value;}
			get{return _parent_role_id;}
		}
		/// <summary>
		/// 角色名
		/// </summary>
		public string role_name
		{
			set{ _role_name=value;}
			get{return _role_name;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime create_time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model
	}
}

