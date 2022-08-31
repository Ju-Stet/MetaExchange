namespace MetaExchange.Models
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public ServiceResult()
        {
        }

        public ServiceResult(string message)
        {
            Message = message;
        }
    }
}
