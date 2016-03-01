using LodgeAround.Entity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeAround.Interfaces.Administration
{
    public interface ILogin
    {
        LodgeAround.Entity.Data.Users GetUserByName(string userName);
        LodgeAround.Entity.Data.Users GetUserByNameAndPassword(string userName, string purePassword);
    }
}

