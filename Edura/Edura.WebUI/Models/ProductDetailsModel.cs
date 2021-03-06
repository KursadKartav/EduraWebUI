using Edura.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Models
{
    public class ProductDetailsModel
    {
        public Product  Product { get; set; }
        public List<Image> ProductImages { get; set; }
        public List<ProductAttribute> ProductAttributes { get; set; } //List olduğu için s olucak sonlarında

        public List<Category> Categories { get; set; }

    }
}
