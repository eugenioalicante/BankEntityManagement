using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BackEntityManagement.Infrastructure.Exceptions
{
    public class Error
    {       
        public int Id { get; set; }
     
        public string Descripcion { get; set; }

        public HttpStatusCode RespuestaHTTP { get; set; }
    }
}
