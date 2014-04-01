using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using PermissionSystem.Model;
using PermissionSystem.DALFactory;
using PermissionSystem.IDAL;
namespace PermissionSystem.BLL
{
	public partial class OperatorLog : IOperatorLog
	{
		private readonly IOperatorLog dal=DataAccess.CreateOperatorLog();
		public OperatorLog()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long operator_log_id)
		{
			return dal.Exists(operator_log_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.OperatorLog model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PermissionSystem.Model.OperatorLog model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long operator_log_id)
		{
			
			return dal.Delete(operator_log_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string operator_log_idlist )
		{
			return dal.DeleteList(operator_log_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PermissionSystem.Model.OperatorLog GetModel(long operator_log_id)
		{
			
			return dal.GetModel(operator_log_id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public PermissionSystem.Model.OperatorLog GetModelByCache(long operator_log_id)
		{
			
			string CacheKey = "OperatorLogModel-" + operator_log_id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(operator_log_id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (PermissionSystem.Model.OperatorLog)objModel;
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
		public List<PermissionSystem.Model.OperatorLog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<PermissionSystem.Model.OperatorLog> DataTableToList(DataTable dt)
		{
			List<PermissionSystem.Model.OperatorLog> modelList = new List<PermissionSystem.Model.OperatorLog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				PermissionSystem.Model.OperatorLog model;
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


        public Model.OperatorLog DataRowToModel(DataRow row)
        {
            return dal.DataRowToModel(row);
        }
    }
}

