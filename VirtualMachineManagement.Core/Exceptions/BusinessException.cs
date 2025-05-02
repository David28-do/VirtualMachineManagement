using System.Net;
namespace VirtualMachineManagement.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public List<string> Errors { get; set; }
        public string ErrorMessage { get; set; }
        public HttpStatusCode CodeResponse { get; set; }
        public BusinessException()
        {
        }
    }
}
