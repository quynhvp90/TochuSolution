using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Infrastructure.SeedData
{
    public class MasterData
    {
        public class MasterDataSet
        {
            public List<ProductSpec> ProductSpecs { get; set; } = new List<ProductSpec>();
            public List<Property> Properties { get; set; } = new List<Property>();  
        }

        public class ProductSpec
        {
            public string ProductName { get; set; }
            public string CustomerName { get; set; }
            public int Id { get; set; }
            public double Min { get; set; }
            public double Max { get; set; }
        }

        public class Property
        {
            public string Kbn { get; set; }
            public int Id { get; set; }
            public string Nm { get; set; }
            public int Enum { get; set; }
            public string Eyobi { get; set; }
        }
    }
}
