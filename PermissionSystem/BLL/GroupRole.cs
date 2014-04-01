using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PermissionSystem.Model;
using PermissionSystem.DALFactory;
using PermissionSystem.IDAL;
namespace PermissionSystem.BLL
{
	public partial class GroupRole : IGroupRole
	{
		private readonly IGroupRole dal=DataAccess.CreateGroupRole();
		public GroupRole()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long group_role_id)
		{
			return dal.Exists(group_role_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.GroupRole model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PermissionSystem.Model.GroupRole model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long group_role_id)
		{
			
			return dal.Delete(group_role_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string group_role_idlist )
		{
			return dal.DeleteList(group_role_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PermissionSystem.Model.GroupRole GetModel(long group_role_id)
		{
			
			return dal.GetModel(group_role_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PermissionSystem.Model.GroupRole GetModelByCache(long group_role_id)
		{
			
			string CacheKey = "GroupRoleModel-" + group_role_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(group_role_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PermissionSystem.Model.GroupRole)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PermissionSystem.Model.GroupRole> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PermissionSystem.Model.GroupRole> DataTableToList(DataTable dt)
		{
			List<PermissionSystem.Model.GroupRole> modelList = new List<PermissionSystem.Model.GroupRole>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PermissionSystem.Model.GroupRole model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}


        public Model.GroupRole DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }
    }
}

