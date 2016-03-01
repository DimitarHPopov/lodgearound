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
                string hashPass = Common.Utility.ConvertToBase64(purePassword);

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
    }
}
