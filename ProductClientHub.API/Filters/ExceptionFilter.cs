using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ProdutClientHubException produtClientHubException)
            {
                context.HttpContext.Response.StatusCode = (int)produtClientHubException.GetHttpStatusCode();

                context.Result = new ObjectResult(new ResponseErrorMessageJson(produtClientHubException.GetErrors()));
            }

            else
            {
                ThrowUnknowError(context);
            }
        }
        private void ThrowUnknowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessageJson("Erro Desconhecido"));
        }
    }
    
}

