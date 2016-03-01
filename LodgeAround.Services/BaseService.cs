using LodgeAround.Interfaces.Administration;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodgeAround.Services
{
    public class BaseService<T> : Service<T> where T : class, IObjectState
    {
        protected IRepositoryAsync<T> _repository;
        protected IEnvironment _environment;
        public BaseService(IRepositoryAsync<T> repository, IEnvironment environment) : base(repository)
        {
            this._repository = repository;
            this._environment = environment;
        }
    }
}
