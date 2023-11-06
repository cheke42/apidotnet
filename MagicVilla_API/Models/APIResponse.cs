using System.Net;

namespace MagicVilla_API.Models
{
    public class APIResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public bool isSuccess { get; set; }
        public List<string> errorMessages { get; set; }
        public object result { get; set; }
    }
}
