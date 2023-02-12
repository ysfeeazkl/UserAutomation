using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAutomation.Business.Abstract;
using UserOtomation.Shared.Utilities.Results.Abstract;

namespace UserAutomation.Business.Concrete
{
    public class WorkerManager : IWorkerService
    {
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

        public Task<IDataResult> GetCompanyByUserIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetUserByCompanyIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> GetUserByCompanyLocationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult> UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
