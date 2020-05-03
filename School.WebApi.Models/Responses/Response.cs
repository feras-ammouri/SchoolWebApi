using System;
using System.Collections.Generic;
using System.Text;

namespace School.WebApi.Models.Responses
{
    public class Response<T>
    {
        public string ErrorMessage { get; set; }

        public T Model { get; set; }
    }
}
