using Ninject;
using PermissionSystem.BLL;
using PermissionSystem.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PermissionSystem.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IGroup>( ).To<Group>( );
            ninjectKernel.Bind<IGroupPermission>( ).To<GroupPermission>( );
            ninjectKernel.Bind<IGroupRole>( ).To<GroupRole>( );
            ninjectKernel.Bind<IOperatorLog>( ).To<OperatorLog>( );
            ninjectKernel.Bind<IOrganization>( ).To<Organization>( );
            ninjectKernel.Bind<IPermission>( ).To<Permission>( );
            ninjectKernel.Bind<IPermissionType>( ).To<PermissionType>( );
            ninjectKernel.Bind<IRole>( ).To<Role>( );
            ninjectKernel.Bind<IRolePermission>( ).To<RolePermission>( );
            ninjectKernel.Bind<IUser>( ).To<User>( );
            ninjectKernel.Bind<IUserGroup>( ).To<UserGroup>( );
            ninjectKernel.Bind<IUserPermission>( ).To<UserPermission>( );
            ninjectKernel.Bind<IUserRole>( ).To<UserRole>( );
        }
    }
}