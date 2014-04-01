using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class PermissionType
	{
		public PermissionType()
		{}
		#region Model
		private long _permission_type_id;
		private string _permission_type_value;
		private string _permission_type_name;
		private string _description;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long permission_type_id
		{
			set{ _permission_type_id=value;}
			get{return _permission_type_id;}
		}
		/// <summary>
		/// 权限类型值
		/// </summary>
		public string permission_type_value
		{
			set{ _permission_type_value=value;}
			get{return _permission_type_value;}
		}
		/// <summary>
		/// 权限类型名
		/// </summary>
		public string permission_type_name
		{
			set{ _permission_type_name=value;}
			get{return _permission_type_name;}
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

