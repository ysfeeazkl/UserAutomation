using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAutomation.Business.Abstract;
using UserAutomation.Dapper.Repository;
using UserAutomation.Entities.Concrete;
using UserOtomation.Shared.Utilities.Results.Abstract;

namespace UserAutomation.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IDapperRepository<User> _userRepository;

        public UserManager(IDapperRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IDataResult> AddAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> HomeLocationId()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
