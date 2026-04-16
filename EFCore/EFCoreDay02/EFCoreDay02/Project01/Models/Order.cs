using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDay02.Project01.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
