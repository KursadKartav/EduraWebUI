using Edura.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; } //Bütün sayfalar
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }
    public class ProductListModel
    {
        public IEnumerable<Product> Products { get; set; } //productaki bütün verileri almak istiyorum
        public PagingInfo PagingInfo { get; set; }
    }
}
