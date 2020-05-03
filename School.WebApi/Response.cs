using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace School.WebApi
{
    public class Response : IActionResult
    {
        public Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
