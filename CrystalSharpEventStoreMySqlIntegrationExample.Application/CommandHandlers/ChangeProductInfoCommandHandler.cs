using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Application;
using CrystalSharp.Application.Handlers;
using CrystalSharp.Infrastructure.EventStoresPersistence;
using CrystalSharpEventStoreMySqlIntegrationExample.Application.Commands;
using CrystalSharpEventStoreMySqlIntegrationExample.Application.Domain.Aggregates.ProductAggregate;
using CrystalSharpEventStoreMySqlIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreMySqlIntegrationExample.Application.CommandHandlers
{
    public class ChangeProductInfoCommandHandler : CommandHandler<ChangeProductInfoCommand, ProductResponse>
    {
        private readonly IAggregateEventStore<int> _eventStore;

        public ChangeProductInfoCommandHandler(IAggregateEventStore<int> eventStore)
        {
            _eventStore = eventStore;
        }

        public override async Task<CommandExecutionResult<ProductResponse>> Handle(ChangeProductInfoCommand request, CancellationToken cancellationToken = default)
        {
            if (request == null) return await Fail("Invalid command.");

            Product existingProduct = await _eventStore.Get<Product>(request.GlobalUId, cancellationToken).ConfigureAwait(false);

            if (existingProduct == null)
            {
                await Fail("Product not found.");
            }

            existingProduct.ChangeProductInfo(new ProductInfo(request.Sku, request.Price));
            await _eventStore.Store(existingProduct, cancellationToken).ConfigureAwait(false);

            ProductResponse response = new() { GlobalUId = existingProduct.GlobalUId, Name = existingProduct.Name };

            return await Ok(response);
        }
    }
}
