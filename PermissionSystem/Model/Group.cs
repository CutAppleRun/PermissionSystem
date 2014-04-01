using System;
namespace PermissionSystem.Model
{
	[Serializable]
	public partial class Group
	{
		public Group()
		{}
		#region Model
		private long _group_id;
		private string _group_name;
		private long _parent_group_id;
		private DateTime _create_time;
		private string _description;
		/// <summary>
		/// 记录ID
		/// </summary>
		public long group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		/// <summary>
		/// 组名
		/// </summary>
		public string group_name
		{
			set{ _group_name=value;}
			get{return _group_name;}
		}
		/// <summary>
		/// 父组
		/// </summary>
		public long parent_group_id
		{
			set{ _parent_group_id=value;}
			get{return _parent_group_id;}
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

