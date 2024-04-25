using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usoDelYield.Clases
{
    internal class Customer : DbContext
    {
        public int CustomerId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
