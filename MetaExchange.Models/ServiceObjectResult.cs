namespace MetaExchange.Models
{
    public class ServiceObjectResult<TValue> : ServiceResult
    {
        public TValue Value { get; set; }

        public ServiceObjectResult()
        {
        }

        public ServiceObjectResult(string message)
        : base(message)
        {
        }

        public ServiceObjectResult(TValue value)
        {
            IsSuccess = true;
            Value = value;
        }

        public ServiceObjectResult(string message, TValue value)
            : this(message)
        {
            Value = value;
        }
    }
}
