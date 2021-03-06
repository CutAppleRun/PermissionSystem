using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PermissionSystem.IDAL;
namespace PermissionSystem.SQLServerDAL
{
	public partial class Permission:IPermission
	{
		public Permission()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long permission_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Permission");
			strSql.Append(" where permission_id=@permission_id and IsUse=1");
			SqlParameter[] parameters = {
					new SqlParameter("@permission_id", SqlDbType.BigInt)
			};
			parameters[0].Value = permission_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.Permission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Permission(");
			strSql.Append("partent_permission_id,permission_name,description)");
			strSql.Append(" values (");
			strSql.Append("@partent_permission_id,@permission_name,@description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@partent_permission_id", SqlDbType.BigInt,8),
					new SqlParameter("@permission_name", SqlDbType.NVarChar,50),
					new SqlParameter("@description", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.partent_permission_id;
			parameters[1].Value = model.permission_name;
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
		public bool Update(PermissionSystem.Model.Permission model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Permission set ");
			strSql.Append("partent_permission_id=@partent_permission_id,");
			strSql.Append("permission_name=@permission_name,");
			strSql.Append("description=@description");
			strSql.Append(" where permission_id=@permission_id");
			SqlParameter[] parameters = {
					new SqlParameter("@partent_permission_id", SqlDbType.BigInt,8),
					new SqlParameter("@permission_name", SqlDbType.NVarChar,50),
					new SqlParameter("@description", SqlDbType.NVarChar,200),
					new SqlParameter("@permission_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.partent_permission_id;
			parameters[1].Value = model.permission_name;
			parameters[2].Value = model.description;
			parameters[3].Value = model.permission_id;

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
		/// 删除一条数据: 使用软删除
		/// </summary>
		public bool Delete(long permission_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Permission set IsUse = 0");
			strSql.Append(" where permission_id=@permission_id");
			SqlParameter[] parameters = {
					new SqlParameter("@permission_id", SqlDbType.BigInt)
			};
			parameters[0].Value = permission_id;

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
        /// 批量删除数据:使用软删除
		/// </summary>
		public bool DeleteList(string permission_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Permission set IsUse = 0 ");
			strSql.Append(" where permission_id in ("+permission_idlist + ")  ");
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
		public PermissionSystem.Model.Permission GetModel(long permission_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 permission_id,partent_permission_id,permission_name,description from Permission ");
			strSql.Append(" where permission_id=@permission_id and IsUse=1");
			SqlParameter[] parameters = {
					new SqlParameter("@permission_id", SqlDbType.BigInt)
			};
			parameters[0].Value = permission_id;

			PermissionSystem.Model.Permission model=new PermissionSystem.Model.Permission();
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
		public PermissionSystem.Model.Permission DataRowToModel(DataRow row)
		{
			PermissionSystem.Model.Permission model=new PermissionSystem.Model.Permission();
			if (row != null)
			{
				if(row["permission_id"]!=null && row["permission_id"].ToString()!="")
				{
					model.permission_id=long.Parse(row["permission_id"].ToString());
				}
				if(row["partent_permission_id"]!=null && row["partent_permission_id"].ToString()!="")
				{
					model.partent_permission_id=long.Parse(row["partent_permission_id"].ToString());
				}
				if(row["permission_name"]!=null)
				{
					model.permission_name=row["permission_name"].ToString();
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
			strSql.Append("select permission_id,partent_permission_id,permission_name,description ");
			strSql.Append(" FROM Permission where IsUse=1");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" and "+strWhere);
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
			strSql.Append(" permission_id,partent_permission_id,permission_name,description ");
			strSql.Append(" FROM Permission where IsUse=1");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" and "+strWhere);
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
			strSql.Append("select count(1) FROM Permission where IsUse = 1");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" and "+strWhere);
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
            throw new NotImplementedException("未实现");

			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.permission_id desc");
			}
			strSql.Append(")AS Row, T.*  from Permission T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}


        public bool UnRemove(long id)
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append("update Permission set IsUse = 1 ");
            strSql.Append(" where permission_id=@permission_id");
            SqlParameter[ ] parameters = {
					new SqlParameter("@permission_id", SqlDbType.BigInt)
			};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString( ), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet GetFreePrivileges( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.Append("SELECT * FROM PrivilegeSystem_01.dbo.Permission ");
            strSql.Append("WHERE partent_permission_id NOT IN ");
            strSql.Append("( SELECT permission_id FROM PrivilegeSystem_01.dbo.Permission WHERE IsUse = 1 ) ");
            strSql.Append("AND partent_permission_id <> 0 AND IsUse = 1");
            return DbHelperSQL.Query(strSql.ToString( ));
        }
    }
}

