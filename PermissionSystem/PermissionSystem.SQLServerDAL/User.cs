using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PermissionSystem.IDAL;
namespace PermissionSystem.SQLServerDAL
{
	public partial class User:IUser
	{
		public User()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long user_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.BigInt)
			};
			parameters[0].Value = user_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User(");
			strSql.Append("organization_id,user_name,password,vsername,create_time)");
			strSql.Append(" values (");
			strSql.Append("@organization_id,@user_name,@password,@vsername,@create_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@organization_id", SqlDbType.BigInt,8),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.NVarChar,200),
					new SqlParameter("@vsername", SqlDbType.NVarChar,50),
					new SqlParameter("@create_time", SqlDbType.DateTime)};
			parameters[0].Value = model.organization_id;
			parameters[1].Value = model.user_name;
			parameters[2].Value = model.password;
			parameters[3].Value = model.vsername;
			parameters[4].Value = model.create_time;

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
		public bool Update(PermissionSystem.Model.User model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User set ");
			strSql.Append("organization_id=@organization_id,");
			strSql.Append("user_name=@user_name,");
			strSql.Append("password=@password,");
			strSql.Append("vsername=@vsername,");
			strSql.Append("create_time=@create_time");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@organization_id", SqlDbType.BigInt,8),
					new SqlParameter("@user_name", SqlDbType.NVarChar,50),
					new SqlParameter("@password", SqlDbType.NVarChar,200),
					new SqlParameter("@vsername", SqlDbType.NVarChar,50),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@user_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.organization_id;
			parameters[1].Value = model.user_name;
			parameters[2].Value = model.password;
			parameters[3].Value = model.vsername;
			parameters[4].Value = model.create_time;
			parameters[5].Value = model.user_id;

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
		public bool Delete(long user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User ");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.BigInt)
			};
			parameters[0].Value = user_id;

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
		public bool DeleteList(string user_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User ");
			strSql.Append(" where user_id in ("+user_idlist + ")  ");
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
		public PermissionSystem.Model.User GetModel(long user_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_id,organization_id,user_name,password,vsername,create_time from User ");
			strSql.Append(" where user_id=@user_id");
			SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.BigInt)
			};
			parameters[0].Value = user_id;

			PermissionSystem.Model.User model=new PermissionSystem.Model.User();
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
		public PermissionSystem.Model.User DataRowToModel(DataRow row)
		{
			PermissionSystem.Model.User model=new PermissionSystem.Model.User();
			if (row != null)
			{
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=long.Parse(row["user_id"].ToString());
				}
				if(row["organization_id"]!=null && row["organization_id"].ToString()!="")
				{
					model.organization_id=long.Parse(row["organization_id"].ToString());
				}
				if(row["user_name"]!=null)
				{
					model.user_name=row["user_name"].ToString();
				}
				if(row["password"]!=null)
				{
					model.password=row["password"].ToString();
				}
				if(row["vsername"]!=null)
				{
					model.vsername=row["vsername"].ToString();
				}
				if(row["create_time"]!=null && row["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(row["create_time"].ToString());
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
			strSql.Append("select user_id,organization_id,user_name,password,vsername,create_time ");
			strSql.Append(" FROM User ");
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
			strSql.Append(" user_id,organization_id,user_name,password,vsername,create_time ");
			strSql.Append(" FROM User ");
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
			strSql.Append("select count(1) FROM User ");
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
				strSql.Append("order by T.user_id desc");
			}
			strSql.Append(")AS Row, T.*  from User T ");
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

