using PermissionSystem.Model;
using PermissionSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PermissionSystem.WebUI.Infrastructure
{
    public class GetJsonStr
    {
        #region Permission
        public static List<PermissionJsonModel> GetPermissions(List<Permission> list, long parent_id = 0)
        {
            List<PermissionJsonModel> currentData = new List<PermissionJsonModel>( );
            // 获取父ID为当前节点的所有节点
            List<Permission> permissions = (from l in list
                                            where l.partent_permission_id == parent_id
                                            select l).ToList<Permission>( );
            // 如果是叶子节点，则返回null
            if (permissions.Count( ) <= 0)
            {
                return null;
            }
            // 否则递归构建
            foreach (var item in permissions)
            {
                List<PermissionJsonModel> childrens = GetPermissions(list, item.permission_id);
                currentData.Add(new PermissionJsonModel
                {
                    Id = item.permission_id,
                    name = item.permission_name,
                    description = item.description,
                    state = childrens == null ? "open" : "closed",
                    children = childrens
                });
            }
            return currentData;
        }

        public static string DiGuiPermission(List<Permission> list, long parent_id)
        {
            // 获取父ID为当前节点的所有节点
            List<Permission> permissions = (from l in list
                                            where l.partent_permission_id == parent_id
                                            select l).ToList<Permission>( );
            // 如果是叶子节点，则返回null
            if (permissions.Count( ) <= 0)
            {
                return null;
            }
            // 否则递归构建
            StringBuilder sb = new StringBuilder( );
            foreach (var item in permissions)
            {
                sb.Append("{");
                sb.Append("\"Id\":").Append(item.permission_id);
                sb.Append(",\"name\":\"").Append(item.permission_name).Append("\"");
                sb.Append(",\"description\":\"").Append(item.description).Append("\"");

                // 递归获取子节点数据
                string str = DiGuiPermission(list, item.permission_id);

                if (str != null)
                {
                    sb.Append(",\"children\":[").Append(str).Append("]");
                    // 添加关闭样式
                    sb.Append(",\"state\":\"closed\"");
                }
                sb.Append("},");
            }
            // 删除最后的“,”并返回节点数据
            return sb.ToString( ).Substring(0, sb.Length - 1);
        }


        // 选取游离权限：获取所有父ID不存在的 Permission 进行递归构建Json数据
        public static string GetDissociatePermissionJson(List<Permission> all, List<Permission> dp)
        {
            StringBuilder sb = new StringBuilder( );
            sb.Append("[");
            foreach (var item in dp)
            {
                sb.Append("{");
                sb.Append("\"Id\":").Append(item.permission_id);
                sb.Append(",\"name\":\"").Append(item.permission_name).Append("\"");
                sb.Append(",\"description\":\"").Append(item.description).Append("\"");

                // 递归获取子节点数据
                string str = DiGuiPermission(all, item.permission_id);
                if (str != null)
                {
                    sb.Append(",\"children\":[").Append(str).Append("]");
                    // 添加关闭样式
                    sb.Append(",\"state\":\"closed\"");
                }
                sb.Append("},");
            }
            return sb.ToString( ).Substring(0, sb.Length - 1) + "]";
        }
        #endregion



        #region Organization
        public static string GetAllOrganizationJson(List<PermissionSystem.Model.Organization> organizations)
        {
            return "";
        }
        #endregion
    }
}