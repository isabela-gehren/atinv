using System;
using System.Collections.Generic;
using System.Text;

namespace ATINV.Utils
{
    /// <summary>
    /// Class responsible for encapsulating message exchange through the application.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public Response(T entity)
        {
            Entity = entity;
            StatusCode = StatusCode.OK;
            Messages = new List<string>();
        }

        public Response()
        {
            StatusCode = StatusCode.OK;
            Messages = new List<string>();
        }

        /// <summary>
        /// The status code. 
        /// </summary>
        public StatusCode StatusCode { get; set; }

        /// <summary>
        /// The list of messages, if the request failed.
        /// </summary>
        public List<string> Messages { get; set; }

        /// <summary>
        /// The manipulated object, if sucessful.
        /// </summary>
        public T Entity { get; set; }

        public void ReponseException(Exception ex)
        {
            if (Messages == null)
                Messages = new List<string>();

            Messages.Add(ex.ToString());
            StatusCode = StatusCode.InternalServerError;
        }
    }
}
