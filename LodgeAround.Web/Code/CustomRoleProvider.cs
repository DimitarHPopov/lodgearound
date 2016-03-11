using LodgeAround.Interfaces.Administration;
using LodgeAround.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace LodgeAround.Web.Code
{
    public class CustomRoleProvider : RoleProvider
    {
        private ILogin _service;
        public CustomRoleProvider()
        {
            _service = (ILogin)UnityConfig.GetConfiguredContainer().Resolve(typeof(ILogin), "");
        }
        public override string ApplicationName
        {
            get
            {
                return "/LodgeAround.Web";
            }

            set
            {
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return _service.GetAllRoles();
        }

        public override string[] GetRolesForUser(string username)
        {
            return _service.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return _service.IsUserInRole(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}