using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usoDelYield.Clases
{
    internal class Order : DbContext
    {
        public int OrderId { get; set; }
        public OrderList OrderList { get; set; }
        public Customer Customer { get; set; }
       
    }
}
