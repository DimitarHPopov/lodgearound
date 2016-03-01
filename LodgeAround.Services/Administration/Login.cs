using LodgeAround.Entity.Data;
using LodgeAround.Interfaces.Administration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeAround.Services.Administration
{
    public class Login : BaseService<Entity.Data.Users>, ILogin
    {
        public Login(Repository.Pattern.Repositories.IRepositoryAsync<Entity.Data.Users> repository, IEnvironment env) : base(repository, env)
        {

        }

        public LodgeAround.Entity.Data.Users GetUserByName(string userName)
        {
            return (from u in _repository.Queryable().Include("UserInfos")
                    where u.UserName == userName
                    select u).FirstOrDefault();
        }

        public LodgeAround.Entity.Data.Users GetUserByNameAndPassword(string userName, string purePassword)
        {
            try
            {
                string hashPass = Common.Utility.GetHash(purePassword);

                return (from u in _repository.Queryable().Include("UserInfos")
                        where u.UserName == userName
                              &&
                              u.PasswordHash == hashPass
                        select u).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Roles GetUserRole(string userName)
        {
            try
            {
                return (from u in _repository.Queryable().Include("Roles")
                        where u.UserName == userName
                        select u.Roles).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IsUserInRole(string username, string roleName)
        {
            try
            {
                return (from u in _repository.Queryable().Include("Roles")
                        where u.UserName == username
                        select u.Roles).FirstOrDefault().Name == roleName;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string[] GetRolesForUser(string username)
        {
            try
            {
                return new string[] { (from u in _repository.Queryable().Include("Roles")
                        where u.UserName == username
                        select u.Roles).FirstOrDefault().Name };
            }
            catch (Exception ex)
            {
                return new string[] { };
            }
        }
        public string[] GetAllRoles()
        {
            try
            {
                return (from r in _repository.GetRepository<Roles>().Queryable()
                        select r.Name).ToArray();
            }
            catch (Exception ex)
            {
                return new string[] { };
            }

        }
    }
}
