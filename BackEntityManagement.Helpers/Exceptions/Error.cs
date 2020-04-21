using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BackEntityManagement.Helpers.Exceptions
{
    public class ErrorProblemDetails
    {                     
        public string Title { get; set; }        
        public int Status { get; set; }        
        public string TraceId { get; set; }        
        public Errors Errors { get; set; }
    }

    public class Errors
    {        
        public string[] resultError { get; set; }
    }
}
