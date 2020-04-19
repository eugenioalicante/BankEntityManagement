using System.Net;


namespace BackEntityManagement.Helpers.Exceptions
{
    public class ResourceNotFoundException : BaseException
    {
        public ResourceNotFoundException(string mensaje = "El recurso solicitado no existe.") : base(mensaje)
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
