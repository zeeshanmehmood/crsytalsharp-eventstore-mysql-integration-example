using System;
using CrystalSharp.Application;
using CrystalSharpEventStoreMySqlIntegrationExample.Application.ReadModels;

namespace CrystalSharpEventStoreMySqlIntegrationExample.Application.Queries
{
    public class ProductDetailByVersionQuery : IQuery<QueryExecutionResult<ProductReadModel>>
    {
        public Guid GlobalUId { get; set; }
        public long Version { get; set; }
    }
}
