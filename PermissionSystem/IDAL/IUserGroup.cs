﻿using System;
using System.Data;
namespace PermissionSystem.IDAL
{
	public interface IUserGroup
	{
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(long user_group_id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		long Add(PermissionSystem.Model.UserGroup model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(PermissionSystem.Model.UserGroup model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(long user_group_id);
		bool DeleteList(string user_group_idlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		PermissionSystem.Model.UserGroup GetModel(long user_group_id);
		PermissionSystem.Model.UserGroup DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
	} 
}
