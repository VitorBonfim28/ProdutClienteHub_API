using FluentValidation;
using ProductClientHub.Communication.Request;

namespace ProductClientHub.API.UseCases.Products.SharedValidator
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator() 
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Nome do produto é inválido.");
            RuleFor(product => product.Brand).NotEmpty().WithMessage("Marca do produto é inválida.");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Preço para o Produto inválido");
        }

    }
}
