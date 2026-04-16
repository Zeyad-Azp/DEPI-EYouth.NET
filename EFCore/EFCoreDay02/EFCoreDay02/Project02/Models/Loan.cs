using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDay02.Project02.Models
{
    internal class Loan
    {
        public int Id { get; set; }
        [ForeignKey("Book")]
        public int? BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("Borrower")]
        public int? BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
