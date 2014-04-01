using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PermissionSystem.IDAL;
namespace PermissionSystem.SQLServerDAL
{
	public partial class PermissionType:IPermissionType
	{
		public PermissionType()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long permission_type_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from PermissionType");
			strSql.Append(" where permission_type_id=@permission_type_id");
			SqlParameter[] parameters = {
					new SqlParameter("@permission_type_id", SqlDbType.BigInt)
			};
			parameters[0].Value = permission_type_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.PermissionType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PermissionType(");
			strSql.Append("permission_type_value,permission_type_name,description)");
			strSql.Append(" values (");
			strSql.Append("@permission_type_value,@permission_type_name,@description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@permission_type_value", SqlDbType.NVarChar,50),
					new SqlParameter("@permission_type_name", SqlDbType.NVarChar,50),
					new SqlParameter("@description", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.permission_type_value;
			parameters[1].Value = model.permission_type_name;
			parameters[2].Value = model.description;

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
		public bool Update(PermissionSystem.Model.PermissionType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PermissionType set ");
			strSql.Append("permission_type_value=@permission_type_value,");
			strSql.Append("permission_type_name=@permission_type_name,");
			strSql.Append("description=@description");
			strSql.Append(" where permission_type_id=@permission_type_id");
			SqlParameter[] parameters = {
					new SqlParameter("@permission_type_value", SqlDbType.NVarChar,50),
					new SqlParameter("@permission_type_name", SqlDbType.NVarChar,50),
					new SqlParameter("@description", SqlDbType.NVarChar,200),
					new SqlParameter("@permission_type_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.permission_type_value;
			parameters[1].Value = model.permission_type_name;
			parameters[2].Value = model.description;
			parameters[3].Value = model.permission_type_id;

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
		public bool Delete(long permission_type_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PermissionType ");
			strSql.Append(" where permission_type_id=@permission_type_id");
			SqlParameter[] parameters = {
					new SqlParameter("@permission_type_id", SqlDbType.BigInt)
			};
			parameters[0].Value = permission_type_id;

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
		public bool DeleteList(string permission_type_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PermissionType ");
			strSql.Append(" where permission_type_id in ("+permission_type_idlist + ")  ");
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
		public PermissionSystem.Model.PermissionType GetModel(long permission_type_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 permission_type_id,permission_type_value,permission_type_name,description from PermissionType ");
			strSql.Append(" where permission_type_id=@permission_type_id");
			SqlParameter[] parameters = {
					new SqlParameter("@permission_type_id", SqlDbType.BigInt)
			};
			parameters[0].Value = permission_type_id;

			PermissionSystem.Model.PermissionType model=new PermissionSystem.Model.PermissionType();
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
		public PermissionSystem.Model.PermissionType DataRowToModel(DataRow row)
		{
			PermissionSystem.Model.PermissionType model=new PermissionSystem.Model.PermissionType();
			if (row != null)
			{
				if(row["permission_type_id"]!=null && row["permission_type_id"].ToString()!="")
				{
					model.permission_type_id=long.Parse(row["permission_type_id"].ToString());
				}
				if(row["permission_type_value"]!=null)
				{
					model.permission_type_value=row["permission_type_value"].ToString();
				}
				if(row["permission_type_name"]!=null)
				{
					model.permission_type_name=row["permission_type_name"].ToString();
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
			strSql.Append("select permission_type_id,permission_type_value,permission_type_name,description ");
			strSql.Append(" FROM PermissionType ");
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
			strSql.Append(" permission_type_id,permission_type_value,permission_type_name,description ");
			strSql.Append(" FROM PermissionType ");
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
			strSql.Append("select count(1) FROM PermissionType ");
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
				strSql.Append("order by T.permission_type_id desc");
			}
			strSql.Append(")AS Row, T.*  from PermissionType T ");
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

