using System.Net;

namespace Models
{
    public class Response<T> where T : class
    {
        public T ResponseModel { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
