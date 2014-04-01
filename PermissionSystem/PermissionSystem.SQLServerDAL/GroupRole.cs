using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PermissionSystem.IDAL;
namespace PermissionSystem.SQLServerDAL
{
	public partial class GroupRole:IGroupRole
	{
		public GroupRole()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long group_role_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from GroupRole");
			strSql.Append(" where group_role_id=@group_role_id");
			SqlParameter[] parameters = {
					new SqlParameter("@group_role_id", SqlDbType.BigInt)
			};
			parameters[0].Value = group_role_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.GroupRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into GroupRole(");
			strSql.Append("group_id,role_id)");
			strSql.Append(" values (");
			strSql.Append("@group_id,@role_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.BigInt,8),
					new SqlParameter("@role_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.group_id;
			parameters[1].Value = model.role_id;

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
		public bool Update(PermissionSystem.Model.GroupRole model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update GroupRole set ");
			strSql.Append("group_id=@group_id,");
			strSql.Append("role_id=@role_id");
			strSql.Append(" where group_role_id=@group_role_id");
			SqlParameter[] parameters = {
					new SqlParameter("@group_id", SqlDbType.BigInt,8),
					new SqlParameter("@role_id", SqlDbType.BigInt,8),
					new SqlParameter("@group_role_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.group_id;
			parameters[1].Value = model.role_id;
			parameters[2].Value = model.group_role_id;

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
		public bool Delete(long group_role_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupRole ");
			strSql.Append(" where group_role_id=@group_role_id");
			SqlParameter[] parameters = {
					new SqlParameter("@group_role_id", SqlDbType.BigInt)
			};
			parameters[0].Value = group_role_id;

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
		public bool DeleteList(string group_role_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from GroupRole ");
			strSql.Append(" where group_role_id in ("+group_role_idlist + ")  ");
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
		public PermissionSystem.Model.GroupRole GetModel(long group_role_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 group_role_id,group_id,role_id from GroupRole ");
			strSql.Append(" where group_role_id=@group_role_id");
			SqlParameter[] parameters = {
					new SqlParameter("@group_role_id", SqlDbType.BigInt)
			};
			parameters[0].Value = group_role_id;

			PermissionSystem.Model.GroupRole model=new PermissionSystem.Model.GroupRole();
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
		public PermissionSystem.Model.GroupRole DataRowToModel(DataRow row)
		{
			PermissionSystem.Model.GroupRole model=new PermissionSystem.Model.GroupRole();
			if (row != null)
			{
				if(row["group_role_id"]!=null && row["group_role_id"].ToString()!="")
				{
					model.group_role_id=long.Parse(row["group_role_id"].ToString());
				}
				if(row["group_id"]!=null && row["group_id"].ToString()!="")
				{
					model.group_id=long.Parse(row["group_id"].ToString());
				}
				if(row["role_id"]!=null && row["role_id"].ToString()!="")
				{
					model.role_id=long.Parse(row["role_id"].ToString());
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
			strSql.Append("select group_role_id,group_id,role_id ");
			strSql.Append(" FROM GroupRole ");
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
			strSql.Append(" group_role_id,group_id,role_id ");
			strSql.Append(" FROM GroupRole ");
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
			strSql.Append("select count(1) FROM GroupRole ");
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
				strSql.Append("order by T.group_role_id desc");
			}
			strSql.Append(")AS Row, T.*  from GroupRole T ");
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

