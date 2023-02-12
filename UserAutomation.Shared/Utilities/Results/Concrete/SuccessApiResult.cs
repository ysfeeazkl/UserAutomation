using UserOtomation.Shared.Entities.ComplexTypes;
using UserOtomation.Shared.Utilities.Results.Abstract;

namespace UserOtomation.Shared.Utilities.Results.Concrete
{
    public class SuccessApiResult : ApiResult
    {
        public SuccessApiResult(IResult result, string href) : base(result.ResultStatus, result.Message, HttpStatusCode.OK, href)
        {
        }
    }
}

