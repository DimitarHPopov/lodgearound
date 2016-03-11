using LodgeAround.Entity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeAround.Interfaces.Administration
{
    public interface IEnvironment
    {
        Users LoggedUser { get; set; }
        Task SaveUser();
    }
}
