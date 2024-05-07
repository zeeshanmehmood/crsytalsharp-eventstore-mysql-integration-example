using System.Threading;
using System.Threading.Tasks;
using CrystalSharp.Domain.Infrastructure;
using CrystalSharpEventStoreMySqlIntegrationExample.Application.Domain.Aggregates.ProductAggregate.Events;

namespace CrystalSharpEventStoreMySqlIntegrationExample.Application.EventHandlers
{
    public class ProductNameChangedDomainEventHandler : ISynchronousDomainEventHandler<ProductNameChangedDomainEvent>
    {
        public async Task Handle(ProductNameChangedDomainEvent notification, CancellationToken cancellationToken = default)
        {
            //
        }
    }
}
