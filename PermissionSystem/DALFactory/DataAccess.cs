using System;
using System.Reflection;
using System.Configuration;
using PermissionSystem.IDAL;
using Maticsoft.Common;
namespace PermissionSystem.DALFactory
{
    /// <summary>
    /// 抽象工厂模式创建DAL。
    /// web.config 需要加入配置：(利用工厂模式+反射机制+缓存机制,实现动态创建不同的数据层对象接口) 
    /// DataCache类在导出代码的文件夹里
    /// <appSettings> 
    ///     <add key="DAL" value="PermissionSystem.SQLServerDAL" /> (这里的命名空间根据实际情况更改为自己项目的命名空间)
    /// </appSettings> 
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);// 写入缓存
                } catch (Exception e)
                {
                }
            }
            return objType;
        }
        /// <summary>
        /// 创建Group数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IGroup CreateGroup( )
        {

            string ClassNamespace = AssemblyPath + ".Group";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IGroup) objType;
        }


        /// <summary>
        /// 创建GroupPermission数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IGroupPermission CreateGroupPermission( )
        {

            string ClassNamespace = AssemblyPath + ".GroupPermission";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IGroupPermission) objType;
        }


        /// <summary>
        /// 创建GroupRole数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IGroupRole CreateGroupRole( )
        {

            string ClassNamespace = AssemblyPath + ".GroupRole";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IGroupRole) objType;
        }


        /// <summary>
        /// 创建OperatorLog数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IOperatorLog CreateOperatorLog( )
        {

            string ClassNamespace = AssemblyPath + ".OperatorLog";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IOperatorLog) objType;
        }


        /// <summary>
        /// 创建Organization数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IOrganization CreateOrganization( )
        {

            string ClassNamespace = AssemblyPath + ".Organization";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IOrganization) objType;
        }


        /// <summary>
        /// 创建Permission数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IPermission CreatePermission( )
        {

            string ClassNamespace = AssemblyPath + ".Permission";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IPermission) objType;
        }


        /// <summary>
        /// 创建PermissionType数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IPermissionType CreatePermissionType( )
        {

            string ClassNamespace = AssemblyPath + ".PermissionType";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IPermissionType) objType;
        }


        /// <summary>
        /// 创建Role数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IRole CreateRole( )
        {

            string ClassNamespace = AssemblyPath + ".Role";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IRole) objType;
        }


        /// <summary>
        /// 创建RolePermission数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IRolePermission CreateRolePermission( )
        {

            string ClassNamespace = AssemblyPath + ".RolePermission";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IRolePermission) objType;
        }


        /// <summary>
        /// 创建User数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IUser CreateUser( )
        {

            string ClassNamespace = AssemblyPath + ".User";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IUser) objType;
        }


        /// <summary>
        /// 创建UserGroup数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IUserGroup CreateUserGroup( )
        {

            string ClassNamespace = AssemblyPath + ".UserGroup";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IUserGroup) objType;
        }


        /// <summary>
        /// 创建UserPermission数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IUserPermission CreateUserPermission( )
        {

            string ClassNamespace = AssemblyPath + ".UserPermission";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IUserPermission) objType;
        }


        /// <summary>
        /// 创建UserRole数据层接口。
        /// </summary>
        public static PermissionSystem.IDAL.IUserRole CreateUserRole( )
        {

            string ClassNamespace = AssemblyPath + ".UserRole";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (PermissionSystem.IDAL.IUserRole) objType;
        }

    }
}