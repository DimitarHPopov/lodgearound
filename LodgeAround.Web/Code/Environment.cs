using LodgeAround.Entity.Data;
using LodgeAround.Interfaces.Administration;
using LodgeAround.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LodgeAround.Web.Code
{
    public class Environment : IEnvironment
    {
        public static string GetFullName(string username)
        {
            var container = new Microsoft.Practices.Unity.UnityContainer();

            var user = ((ILogin)UnityConfig.GetConfiguredContainer().Resolve(typeof(ILogin), string.Empty)).GetUserByName(username);

            if (user != null)
            {
                return user.UserInfos.FullName;
            }

            return string.Empty;
        }
        public Users LoggedUser
        {
            get
            {
                if (HttpRuntime.Cache[HttpContext.Current.User.Identity.Name] == null)
                {
                    var user = ((ILogin)UnityConfig.GetConfiguredContainer().Resolve(typeof(ILogin), string.Empty)).GetUserByName(HttpContext.Current.User.Identity.Name);

                    if (user != null)
                    {
                        HttpRuntime.Cache.Insert(HttpContext.Current.User.Identity.Name,
                            user,
                            null,
                            System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 20, 0));
                    }
                    else
                    {
                        HttpContext.Current.Response.Redirect("Account/Login");
                    }
                }

                return HttpRuntime.Cache[HttpContext.Current.User.Identity.Name] as Users;

            }

            set
            {
                HttpRuntime.Cache.Insert(HttpContext.Current.User.Identity.Name,
                    value,
                    null,
                    System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 20, 0));

            }
        }

        public async Task SaveUser()
        {
        }
    }
}