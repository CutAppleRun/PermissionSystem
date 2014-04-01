using PermissionSystem.App_Code;
using PermissionSystem.IDAL;
using PermissionSystem.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermissionSystem.WebUI.Controllers
{
    public class OrganizationController : Controller
    {
        private IOrganization organization;
        public OrganizationController(IOrganization organization)
        {
            this.organization = organization;
        }


        // 获取所有权限列表的Json
        public string GetOrganization( )
        {
            DataSet ds = organization.GetList("");
            List<PermissionSystem.Model.Organization> organizations = Tools.ToList<PermissionSystem.Model.Organization>(ds.Tables[0]);
            return GetJsonStr.GetAllOrganizationJson(organizations);
        }
        // 权限目录
        public ActionResult Index()
        {
            return View();
        }
        /*
        // 获取所有游离权限的json
        public string GetDissociateOrganization( )
        {
            DataSet ds1 = permission.GetList("");
            List<PermissionSystem.Model.Permission> all = Tools.ToList<PermissionSystem.Model.Permission>(ds1.Tables[0]);
            DataSet ds2 = permission.GetFreePrivileges( );
            List<PermissionSystem.Model.Permission> dp = Tools.ToList<PermissionSystem.Model.Permission>(ds2.Tables[0]);
            return Tools.GetDissociatePermissionJson(all, dp);
        }
        // 游离权限
        public ActionResult DissociateOrganization( )
        {
            return View();
        }
        */




        // 添加新的权限
        [HttpPost]
        public long Add(PermissionSystem.Model.Organization model)
        {
            return organization.Add(model);
        }
        // 修改权限
        [HttpPost]
        public bool Edit(PermissionSystem.Model.Organization model)
        {
            return organization.Update(model);
        }
        // 删除权限
        [HttpPost]
        public bool Remove(long id)
        {
            return organization.Delete(id);
        }
        /*
        // 启用一个权限（被删除后重新启用）
        [HttpPost]
        public bool UnRemove(long id)
        {
            return organization.UnRemove(id);
        }
        */
    }
}
