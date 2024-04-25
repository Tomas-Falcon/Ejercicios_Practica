using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usoDelYield.Clases
{
    internal class Category : DbContext
    {
        public int CategoryId {get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public OrderList OrderList { get; set; }
    }
}
