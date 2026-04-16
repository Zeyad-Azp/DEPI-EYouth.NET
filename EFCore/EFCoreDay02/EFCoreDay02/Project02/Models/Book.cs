using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDay02.Project02.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public List<Loan>? Loans { get; set; }
    }
}
