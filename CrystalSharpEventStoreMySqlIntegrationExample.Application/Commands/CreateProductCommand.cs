using CrystalSharp.Application;
using CrystalSharpEventStoreMySqlIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreMySqlIntegrationExample.Application.Commands
{
    public class CreateProductCommand : ICommand<CommandExecutionResult<ProductResponse>>
    {
        public string Name { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}
