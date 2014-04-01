using System;
using System.ComponentModel;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class Permission
	{
		public Permission()
		{}
		#region Model
		private long _permission_id;
		private long _partent_permission_id;
		private string _permission_name;
		private string _description;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long permission_id
		{
			set{ _permission_id=value;}
			get{return _permission_id;}
		}
		/// <summary>
		/// 父权限
		/// </summary>
		public long partent_permission_id
		{
			set{ _partent_permission_id=value;}
			get{return _partent_permission_id;}
		}
		/// <summary>
		/// 权限名称
		/// </summary>
		public string permission_name
		{
			set{ _permission_name=value;}
			get{return _permission_name;}
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

