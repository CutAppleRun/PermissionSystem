using PermissionSystem.IDAL;
using PermissionSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using PermissionSystem.WebUI.Infrastructure;

namespace PermissionSystem.Controllers
{
    public class PermissionController : Controller
    {
        private IPermission permission;
        public PermissionController(IPermission permission)
        {
            this.permission = permission;
        }


        // 获取所有权限列表的Json
        [HttpPost]
        public JsonResult GetPermissionsJson( )
        {
            DataSet ds = permission.GetList("");
            List<PermissionSystem.Model.Permission> permissions = Tools.ToList<PermissionSystem.Model.Permission>(ds.Tables[0]);
            return Json(GetJsonStr.GetPermissions(permissions));
        }
        // 权限目录
        public ActionResult Index()
        {
            return View();
        }


        // 获取所有游离权限的json
        public string GetDissociatePermissions( )
        {
            DataSet ds1 = permission.GetList("");
            List<PermissionSystem.Model.Permission> all = Tools.ToList<PermissionSystem.Model.Permission>(ds1.Tables[0]);
            DataSet ds2 = permission.GetFreePrivileges( );
            List<PermissionSystem.Model.Permission> dp = Tools.ToList<PermissionSystem.Model.Permission>(ds2.Tables[0]);
            return GetJsonStr.GetDissociatePermissionJson(all, dp);
        }
        // 游离权限
        public ActionResult DissociatePermissions( )
        {
            return View();
        }





        // 添加新的权限
        [HttpPost]
        public long Add(PermissionSystem.Model.Permission model)
        {
            return permission.Add(model);
        }
        // 修改权限
        [HttpPost]
        public bool Edit(PermissionSystem.Model.Permission model)
        {
            return permission.Update(model);
        }
        // 删除权限
        [HttpPost]
        public bool Remove(long id)
        {
            return permission.Delete(id);
        }
        // 启用一个权限（被删除后重新启用）
        [HttpPost]
        public bool UnRemove(long id)
        {
            return permission.UnRemove(id);
        }
    }
}
