using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PermissionSystem.IDAL;
namespace PermissionSystem.SQLServerDAL
{
	public partial class UserGroup:IUserGroup
	{
		public UserGroup()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long user_group_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserGroup");
			strSql.Append(" where user_group_id=@user_group_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_group_id", SqlDbType.BigInt)
			};
			parameters[0].Value = user_group_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.UserGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserGroup(");
			strSql.Append("user_id,group_id)");
			strSql.Append(" values (");
			strSql.Append("@user_id,@group_id)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.BigInt,8),
					new SqlParameter("@group_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.group_id;

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
		public bool Update(PermissionSystem.Model.UserGroup model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserGroup set ");
			strSql.Append("user_id=@user_id,");
			strSql.Append("group_id=@group_id");
			strSql.Append(" where user_group_id=@user_group_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.BigInt,8),
					new SqlParameter("@group_id", SqlDbType.BigInt,8),
					new SqlParameter("@user_group_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.user_id;
			parameters[1].Value = model.group_id;
			parameters[2].Value = model.user_group_id;

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
		public bool Delete(long user_group_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserGroup ");
			strSql.Append(" where user_group_id=@user_group_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_group_id", SqlDbType.BigInt)
			};
			parameters[0].Value = user_group_id;

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
		public bool DeleteList(string user_group_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserGroup ");
			strSql.Append(" where user_group_id in ("+user_group_idlist + ")  ");
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
		public PermissionSystem.Model.UserGroup GetModel(long user_group_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_group_id,user_id,group_id from UserGroup ");
			strSql.Append(" where user_group_id=@user_group_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_group_id", SqlDbType.BigInt)
			};
			parameters[0].Value = user_group_id;

			PermissionSystem.Model.UserGroup model=new PermissionSystem.Model.UserGroup();
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
		public PermissionSystem.Model.UserGroup DataRowToModel(DataRow row)
		{
			PermissionSystem.Model.UserGroup model=new PermissionSystem.Model.UserGroup();
			if (row != null)
			{
				if(row["user_group_id"]!=null && row["user_group_id"].ToString()!="")
				{
					model.user_group_id=long.Parse(row["user_group_id"].ToString());
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=long.Parse(row["user_id"].ToString());
				}
				if(row["group_id"]!=null && row["group_id"].ToString()!="")
				{
					model.group_id=long.Parse(row["group_id"].ToString());
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
			strSql.Append("select user_group_id,user_id,group_id ");
			strSql.Append(" FROM UserGroup ");
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
			strSql.Append(" user_group_id,user_id,group_id ");
			strSql.Append(" FROM UserGroup ");
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
			strSql.Append("select count(1) FROM UserGroup ");
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
				strSql.Append("order by T.user_group_id desc");
			}
			strSql.Append(")AS Row, T.*  from UserGroup T ");
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

