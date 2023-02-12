using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOtomation.Shared.Utilities.Results.Abstract;

namespace UserAutomation.Business.Abstract
{
    public interface IWorkerService
    {
        Task<IDataResult> AddAsync();
        Task<IDataResult> UpdateAsync();
        Task<IDataResult> GetAllAsync();
        Task<IDataResult> GetByIdAsync();
        Task<IDataResult> GetUserByCompanyIdAsync();
        Task<IDataResult> GetCompanyByUserIdAsync();
        Task<IDataResult> GetUserByCompanyLocationAsync();
        Task<IDataResult> DeleteByIdAsync(int id);
    }
}
