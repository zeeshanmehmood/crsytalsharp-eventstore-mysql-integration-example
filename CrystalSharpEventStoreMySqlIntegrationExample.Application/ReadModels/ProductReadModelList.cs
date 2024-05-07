using System.Collections.Generic;

namespace CrystalSharpEventStoreMySqlIntegrationExample.Application.ReadModels
{
    public class ProductReadModelList
    {
        public IEnumerable<ProductReadModel> Products { get; set; }
    }
}
