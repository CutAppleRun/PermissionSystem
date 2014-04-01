using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PermissionSystem.IDAL;
namespace PermissionSystem.SQLServerDAL
{
	public partial class GroupPermission:IGroupPermission
	{
		public GroupPermission()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long group_permission_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GroupPermission");
			strSql.Append(" where group_permission_id=@group_permission_id");
			SqlParameter[] parameters = {
					new SqlParameter("@group_permission_id", SqlDbType.BigInt)
			};
			parameters[0].Value = group_permission_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.GroupPermission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GroupPermission(");
			strSql.Append("group_id,permission_id,permission_type_id)");
			strSql.Append(" values (");
			strSql.Append("@group_id,@permission_id,@permission_type_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.BigInt,8),
					new SqlParameter("@permission_id", SqlDbType.BigInt,8),
					new SqlParameter("@permission_type_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.group_id;
			parameters[1].Value = model.permission_id;
			parameters[2].Value = model.permission_type_id;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PermissionSystem.Model.GroupPermission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GroupPermission set ");
			strSql.Append("group_id=@group_id,");
			strSql.Append("permission_id=@permission_id,");
			strSql.Append("permission_type_id=@permission_type_id");
			strSql.Append(" where group_permission_id=@group_permission_id");
			SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.BigInt,8),
					new SqlParameter("@permission_id", SqlDbType.BigInt,8),
					new SqlParameter("@permission_type_id", SqlDbType.BigInt,8),
					new SqlParameter("@group_permission_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.group_id;
			parameters[1].Value = model.permission_id;
			parameters[2].Value = model.permission_type_id;
			parameters[3].Value = model.group_permission_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long group_permission_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupPermission ");
			strSql.Append(" where group_permission_id=@group_permission_id");
			SqlParameter[] parameters = {
					new SqlParameter("@group_permission_id", SqlDbType.BigInt)
			};
			parameters[0].Value = group_permission_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string group_permission_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupPermission ");
			strSql.Append(" where group_permission_id in ("+group_permission_idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PermissionSystem.Model.GroupPermission GetModel(long group_permission_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 group_permission_id,group_id,permission_id,permission_type_id from GroupPermission ");
			strSql.Append(" where group_permission_id=@group_permission_id");
			SqlParameter[] parameters = {
					new SqlParameter("@group_permission_id", SqlDbType.BigInt)
			};
			parameters[0].Value = group_permission_id;

			PermissionSystem.Model.GroupPermission model=new PermissionSystem.Model.GroupPermission();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public PermissionSystem.Model.GroupPermission DataRowToModel(DataRow row)
		{
			PermissionSystem.Model.GroupPermission model=new PermissionSystem.Model.GroupPermission();
			if (row != null)
			{
				if(row["group_permission_id"]!=null && row["group_permission_id"].ToString()!="")
				{
					model.group_permission_id=long.Parse(row["group_permission_id"].ToString());
				}
				if(row["group_id"]!=null && row["group_id"].ToString()!="")
				{
					model.group_id=long.Parse(row["group_id"].ToString());
				}
				if(row["permission_id"]!=null && row["permission_id"].ToString()!="")
				{
					model.permission_id=long.Parse(row["permission_id"].ToString());
				}
				if(row["permission_type_id"]!=null && row["permission_type_id"].ToString()!="")
				{
					model.permission_type_id=long.Parse(row["permission_type_id"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select group_permission_id,group_id,permission_id,permission_type_id ");
			strSql.Append(" FROM GroupPermission ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" group_permission_id,group_id,permission_id,permission_type_id ");
			strSql.Append(" FROM GroupPermission ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM GroupPermission ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.group_permission_id desc");
			}
			strSql.Append(")AS Row, T.*  from GroupPermission T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
	}
}

