using ProductClientHub.API.Infrastructure;
using ProductClientHub.Exceptions.ExceptionsBase;

namespace ProductClientHub.API.UseCases.Products.Delete
{
    public class DeleteProductUsecase
    {
        public void Execute(Guid id)
        {
            var dbContext = new ProductClientHubDbContext();
            var entity = dbContext.Clients.FirstOrDefault(clients => clients.Id == id);
            if (entity is null)
            {
                throw new NotFoundException("Cliente não encontrado.");
            }

            dbContext.Clients.Remove(entity);
            dbContext.SaveChanges();
        }
    }
 }
