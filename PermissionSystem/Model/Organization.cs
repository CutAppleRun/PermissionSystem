using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class Organization
	{
		public Organization()
		{}
		#region Model
		private long _organization_id;
		private long _parent_organization_id;
		private string _organization_name;
		private DateTime _create_time;
		private string _description;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long organization_id
		{
			set{ _organization_id=value;}
			get{return _organization_id;}
		}
		/// <summary>
		/// 父组织
		/// </summary>
		public long parent_organization_id
		{
			set{ _parent_organization_id=value;}
			get{return _parent_organization_id;}
		}
		/// <summary>
		/// 组织名
		/// </summary>
		public string organization_name
		{
			set{ _organization_name=value;}
			get{return _organization_name;}
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

