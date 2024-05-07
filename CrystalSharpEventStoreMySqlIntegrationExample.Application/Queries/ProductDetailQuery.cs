using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreMySqlIntegrationExample.Application.ReadModels;

namespace CrystalSharpEventStoreMySqlIntegrationExample.Application.Queries
{
    public class ProductDetailQuery : IQuery<QueryExecutionResult<ProductReadModel>>
    {
        public Guid GlobalUId { get; set; }
    }
}
