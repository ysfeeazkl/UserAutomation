using UserOtomation.Shared.Entities.Concrete;

namespace UserOtomation.Shared.Utilities.Exceptions
{
    public class NotFoundArgumentsException : Exception
    {
        public NotFoundArgumentsException(string message, IEnumerable<Error> validationErrors) : base(message)
        {
            ValidationErrors = validationErrors;
        }
        public IEnumerable<Error> ValidationErrors { get; set; }
    }
}

