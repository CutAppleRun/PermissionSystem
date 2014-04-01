using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PermissionSystem.IDAL;
namespace PermissionSystem.SQLServerDAL
{
	public partial class Organization:IOrganization
	{
		public Organization()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long organization_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Organization");
			strSql.Append(" where organization_id=@organization_id");
			SqlParameter[] parameters = {
					new SqlParameter("@organization_id", SqlDbType.BigInt)
			};
			parameters[0].Value = organization_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.Organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Organization(");
			strSql.Append("parent_organization_id,organization_name,create_time,description)");
			strSql.Append(" values (");
			strSql.Append("@parent_organization_id,@organization_name,@create_time,@description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@parent_organization_id", SqlDbType.BigInt,8),
					new SqlParameter("@organization_name", SqlDbType.NVarChar,50),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@description", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.parent_organization_id;
			parameters[1].Value = model.organization_name;
			parameters[2].Value = model.create_time;
			parameters[3].Value = model.description;

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
		public bool Update(PermissionSystem.Model.Organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Organization set ");
			strSql.Append("parent_organization_id=@parent_organization_id,");
			strSql.Append("organization_name=@organization_name,");
			strSql.Append("create_time=@create_time,");
			strSql.Append("description=@description");
			strSql.Append(" where organization_id=@organization_id");
			SqlParameter[] parameters = {
					new SqlParameter("@parent_organization_id", SqlDbType.BigInt,8),
					new SqlParameter("@organization_name", SqlDbType.NVarChar,50),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@description", SqlDbType.NVarChar,200),
					new SqlParameter("@organization_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.parent_organization_id;
			parameters[1].Value = model.organization_name;
			parameters[2].Value = model.create_time;
			parameters[3].Value = model.description;
			parameters[4].Value = model.organization_id;

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
		public bool Delete(long organization_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Organization ");
			strSql.Append(" where organization_id=@organization_id");
			SqlParameter[] parameters = {
					new SqlParameter("@organization_id", SqlDbType.BigInt)
			};
			parameters[0].Value = organization_id;

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
		public bool DeleteList(string organization_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Organization ");
			strSql.Append(" where organization_id in ("+organization_idlist + ")  ");
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
		public PermissionSystem.Model.Organization GetModel(long organization_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 organization_id,parent_organization_id,organization_name,create_time,description from Organization ");
			strSql.Append(" where organization_id=@organization_id");
			SqlParameter[] parameters = {
					new SqlParameter("@organization_id", SqlDbType.BigInt)
			};
			parameters[0].Value = organization_id;

			PermissionSystem.Model.Organization model=new PermissionSystem.Model.Organization();
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
		public PermissionSystem.Model.Organization DataRowToModel(DataRow row)
		{
			PermissionSystem.Model.Organization model=new PermissionSystem.Model.Organization();
			if (row != null)
			{
				if(row["organization_id"]!=null && row["organization_id"].ToString()!="")
				{
					model.organization_id=long.Parse(row["organization_id"].ToString());
				}
				if(row["parent_organization_id"]!=null && row["parent_organization_id"].ToString()!="")
				{
					model.parent_organization_id=long.Parse(row["parent_organization_id"].ToString());
				}
				if(row["organization_name"]!=null)
				{
					model.organization_name=row["organization_name"].ToString();
				}
				if(row["create_time"]!=null && row["create_time"].ToString()!="")
				{
					model.create_time=DateTime.Parse(row["create_time"].ToString());
				}
				if(row["description"]!=null)
				{
					model.description=row["description"].ToString();
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
			strSql.Append("select organization_id,parent_organization_id,organization_name,create_time,description ");
			strSql.Append(" FROM Organization ");
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
			strSql.Append(" organization_id,parent_organization_id,organization_name,create_time,description ");
			strSql.Append(" FROM Organization ");
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
			strSql.Append("select count(1) FROM Organization ");
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
				strSql.Append("order by T.organization_id desc");
			}
			strSql.Append(")AS Row, T.*  from Organization T ");
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

