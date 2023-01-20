using System.Net;

namespace GestionDeTareas.API.Core.Models
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data, bool succeeded = true, List<string> errors = null, string message = "Success") 
        {
            Data = data;
            Succeeded = succeeded;
            Errors = errors ?? new List<string>();
            Message = message;
            TimeStamp = DateTime.UtcNow;
        }

        //public Response(string error, HttpStatusCode statusCode, Exception exception)
        //{
        //    Errors = new string[] { error };
        //    Succeeded = false;
        //    TimeStamp = DateTime.Now;
        //    StatusCode = statusCode;
        //    ErrorDetails = exception;
        //    TimeStamp = DateTime.Now;
        //}

        public T Data { get; set; }

        public bool Succeeded { get; set;}

        public List<string> Errors { get; set; }

        public string Message { get; set; }

        public DateTime TimeStamp { get; set; }

        //public HttpStatusCode StatusCode { get; set; }

        //public object ErrorDetails { get; set; }

        //public void AddError(string error)
        //{
        //    if (Errors == null)
        //    {
        //        Errors = new string[] { error };
        //    }
        //    else
        //    {
        //        var currentErrors = Errors.ToList();
        //        currentErrors.Add(error);
        //        Errors = currentErrors.ToArray();
        //    }
        //}
    }
}
