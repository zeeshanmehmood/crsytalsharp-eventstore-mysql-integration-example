using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreMySqlIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreMySqlIntegrationExample.Application.Commands
{
    public class DeleteProductCommand : ICommand<CommandExecutionResult<DeleteProductResponse>>
    {
        public Guid GlobalUId { get; set; }
    }
}
