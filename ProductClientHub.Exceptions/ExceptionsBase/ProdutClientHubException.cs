using System.Net;

namespace ProductClientHub.Exceptions.ExceptionsBase
{
    public abstract class ProdutClientHubException : SystemException
    {
        public ProdutClientHubException(string errormessage) : base(errormessage)
        {  
        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
