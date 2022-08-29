using System.Collections.Generic;

namespace MetaExchange.Models
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public IDictionary<string, IList<string>> Data { get; set; }

        public ServiceResult()
        {
        }

        public ServiceResult(string message)
        {
            Message = message;
        }

        public void AddData(string key, string value)
        {
            if (Data == null)
            {
                Data = new Dictionary<string, IList<string>>();
            }

            if (Data.TryGetValue(key, out var values))
            {
                values.Add(value);
            }
            else
            {
                values = new List<string>
                {
                    value
                };

                Data.Add(key, values);
            }
        }
    }
}
