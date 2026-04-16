using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDay02.Project01.Models
{
    internal class OrderDetail
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
