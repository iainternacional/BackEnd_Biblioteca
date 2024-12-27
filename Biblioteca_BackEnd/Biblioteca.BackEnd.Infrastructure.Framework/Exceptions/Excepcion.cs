using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BackEnd.Infrastructure.Framework.Exceptions
{
    public class Excepcion : Exception
    {
        public Excepcion(HttpStatusCode statusCode, string mensaje)
        {
            this.StatusCode = statusCode;
            this.Mensaje = mensaje;
        }
        public HttpStatusCode StatusCode { get; set; }

        public string Mensaje { get; set; }
    }
}
