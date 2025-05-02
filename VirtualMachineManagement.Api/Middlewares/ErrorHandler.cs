using System.Net;
using System.Text.Json;
using VirtualMachineManagement.Core.Dtos;
using VirtualMachineManagement.Core.Exceptions;
using VirtualMachineManagement.Core.Wrappers;

namespace VirtualMachineManagement.Api.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate next;

        public ErrorHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ErrorDTo();
                var responseGeneric = new Response<List<string>>();

                switch (error)
                {
                    case BusinessException e:
                        response.StatusCode = (int)e.CodeResponse;
                        responseModel.Mensaje = e.ErrorMessage;
                        responseGeneric.Data = e.Errors;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var result = JsonSerializer.Serialize(responseModel, options);
                if (responseGeneric?.Data != null) result = JsonSerializer.Serialize(responseGeneric, options);
                await response.WriteAsync(result);
            }
        }
    }

}
