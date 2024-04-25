using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usoDelYield.Clases
{
    internal class OrderList : DbContext
    {
        public int OrderListId { get; set; }
        public Category Category { get; set; }
        public Order Order { get; set; }
    }
}
