using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using PermissionSystem.IDAL;
namespace PermissionSystem.SQLServerDAL
{
	public partial class OperatorLog:IOperatorLog
	{
		public OperatorLog()
		{}
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long operator_log_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from OperatorLog");
			strSql.Append(" where operator_log_id=@operator_log_id");
			SqlParameter[] parameters = {
					new SqlParameter("@operator_log_id", SqlDbType.BigInt)
			};
			parameters[0].Value = operator_log_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(PermissionSystem.Model.OperatorLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OperatorLog(");
			strSql.Append("operator_type,operator_content,user_id,operator_time)");
			strSql.Append(" values (");
			strSql.Append("@operator_type,@operator_content,@user_id,@operator_time)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@operator_type", SqlDbType.NVarChar,50),
					new SqlParameter("@operator_content", SqlDbType.NVarChar,200),
					new SqlParameter("@user_id", SqlDbType.BigInt,8),
					new SqlParameter("@operator_time", SqlDbType.DateTime)};
			parameters[0].Value = model.operator_type;
			parameters[1].Value = model.operator_content;
			parameters[2].Value = model.user_id;
			parameters[3].Value = model.operator_time;

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
		public bool Update(PermissionSystem.Model.OperatorLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OperatorLog set ");
			strSql.Append("operator_type=@operator_type,");
			strSql.Append("operator_content=@operator_content,");
			strSql.Append("user_id=@user_id,");
			strSql.Append("operator_time=@operator_time");
			strSql.Append(" where operator_log_id=@operator_log_id");
			SqlParameter[] parameters = {
					new SqlParameter("@operator_type", SqlDbType.NVarChar,50),
					new SqlParameter("@operator_content", SqlDbType.NVarChar,200),
					new SqlParameter("@user_id", SqlDbType.BigInt,8),
					new SqlParameter("@operator_time", SqlDbType.DateTime),
					new SqlParameter("@operator_log_id", SqlDbType.BigInt,8)};
			parameters[0].Value = model.operator_type;
			parameters[1].Value = model.operator_content;
			parameters[2].Value = model.user_id;
			parameters[3].Value = model.operator_time;
			parameters[4].Value = model.operator_log_id;

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
		public bool Delete(long operator_log_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OperatorLog ");
			strSql.Append(" where operator_log_id=@operator_log_id");
			SqlParameter[] parameters = {
					new SqlParameter("@operator_log_id", SqlDbType.BigInt)
			};
			parameters[0].Value = operator_log_id;

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
		public bool DeleteList(string operator_log_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OperatorLog ");
			strSql.Append(" where operator_log_id in ("+operator_log_idlist + ")  ");
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
		public PermissionSystem.Model.OperatorLog GetModel(long operator_log_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 operator_log_id,operator_type,operator_content,user_id,operator_time from OperatorLog ");
			strSql.Append(" where operator_log_id=@operator_log_id");
			SqlParameter[] parameters = {
					new SqlParameter("@operator_log_id", SqlDbType.BigInt)
			};
			parameters[0].Value = operator_log_id;

			PermissionSystem.Model.OperatorLog model=new PermissionSystem.Model.OperatorLog();
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
		public PermissionSystem.Model.OperatorLog DataRowToModel(DataRow row)
		{
			PermissionSystem.Model.OperatorLog model=new PermissionSystem.Model.OperatorLog();
			if (row != null)
			{
				if(row["operator_log_id"]!=null && row["operator_log_id"].ToString()!="")
				{
					model.operator_log_id=long.Parse(row["operator_log_id"].ToString());
				}
				if(row["operator_type"]!=null)
				{
					model.operator_type=row["operator_type"].ToString();
				}
				if(row["operator_content"]!=null)
				{
					model.operator_content=row["operator_content"].ToString();
				}
				if(row["user_id"]!=null && row["user_id"].ToString()!="")
				{
					model.user_id=long.Parse(row["user_id"].ToString());
				}
				if(row["operator_time"]!=null && row["operator_time"].ToString()!="")
				{
					model.operator_time=DateTime.Parse(row["operator_time"].ToString());
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
			strSql.Append("select operator_log_id,operator_type,operator_content,user_id,operator_time ");
			strSql.Append(" FROM OperatorLog ");
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
			strSql.Append(" operator_log_id,operator_type,operator_content,user_id,operator_time ");
			strSql.Append(" FROM OperatorLog ");
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
			strSql.Append("select count(1) FROM OperatorLog ");
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
				strSql.Append("order by T.operator_log_id desc");
			}
			strSql.Append(")AS Row, T.*  from OperatorLog T ");
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

