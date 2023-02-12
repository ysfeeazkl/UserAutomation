using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOtomation.Shared.Utilities.Results.Abstract;

namespace UserAutomation.Business.Abstract
{
    public interface ICompanyService
    {
        Task<IDataResult> AddAsync();
        Task<IDataResult> UpdateAsync();
        Task<IDataResult> GetAllAsync();
        Task<IDataResult> GetByIdAsync();
        Task<IDataResult> GetByLocationIdAsync();
        Task<IDataResult> DeleteByIdAsync(int id);


    }
}
