using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDay01.Models
{
    /*
     * Q1:  Why did the property "Id" become a Primary Key
            without any explicit configuration?

        because of the convention in Entity Framework Core. By default, EF Core treats a property named "Id" or ClassNameId as the primary key 


       Q2: Why is "Country" nullable in the database
       while "Price" is not

         because we used the nullable reference (?) with the country property which means that this property can have a null value while the price property is a non-nullable value type (decimal) because the EFCore convention is required while you did not make it nullable
        */
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
