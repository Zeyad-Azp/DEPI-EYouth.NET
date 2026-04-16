using static DEPI_LINQ01.ListGenerators;
namespace DEPI_LINQ01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Arrays
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
                            "nine" };
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            int[] Arr01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] words01 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            #endregion
            #region LINQ - Restriction Operators
            // 1 
            var ProductsOutOfStock = ProductList.Where((product) => product.UnitsInStock == 0);
            // 2
            var ProductsInStock = ProductList.Where((p) => p.UnitsInStock > 0 && p.UnitPrice > 3);
            // 3
            

            var digitsGreaterThanName = Arr.Where((n, I) => n.Length < I);
            #endregion
            #region LINQ - Element Operators 
            // 1
            var ProductOutOfStock = ProductList.FirstOrDefault((p) => p.UnitsInStock == 0);
            //2
            var ProductPrice = ProductList.FirstOrDefault((p) => p.UnitPrice > 1000);
            //3
            

            var number = Arr01.Where((n) => n > 5)
                              .ElementAt(1);
            #endregion
            #region LINQ - Aggregate Operators 
            //1
            var TheCount = Arr01.Count((n) => n % 2 == 1);


            //2
            var TheCustomers = CustomerList.Select((c) => new { c.Id, c.Name, NumberOfOrders = c.Orders.Length });
            //foreach (var c in TheCustomers)
            //{
            //    Console.WriteLine(c);
            //}



            //3
            // using group by
            var TheCategories = ProductList.GroupBy(p => p.Category) // group key = category1 , elements [e1 , e2 , e3]
                                           .Select(g => new
                                           {
                                               category = g.Key,
                                               NumberOfProducts = g.Count() }
                                           );

            // another query
            var DistinctCategories = ProductList.Select(p => p.Category)
                                    .Distinct()
                                    .Select(c => new
                                    {
                                        Category = c,
                                        NumberOfProducts = ProductList.Count(p => p.Category == c)
                                    });

            //foreach (var c in TheCategories)
            //{
            //    Console.WriteLine(c);
            //}
            //foreach (var c in DistinctCategories)
            //{
            //    Console.WriteLine(c);
            //}


            //4 
            var Total = Arr01.Sum();

            //5

            //6
            var totalUnitOfStock = ProductList.GroupBy(p => p.Category)
                                              .Select(g => new // g represents each group
                                              {
                                                  Category = g.Key,
                                                  Total_Units = g.Sum(p => p.UnitsInStock)
                                              });
            //foreach (var c in totalUnitOfStock)
            //{
            //    Console.WriteLine(c);
            //}


            //7

            //8
            var MinPrice = ProductList.GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          Category = g.Key,
                                          MinPriceProduct = g.Min(p => p.UnitPrice)
                                      });
            //foreach (var c in MinPrice)
            //{
            //    Console.WriteLine(c);
            //}


            //9
            var MinPriceLet = from p in ProductList
                              group p by (p.Category) into g
                              let minPrice = g.Min(p => p.UnitPrice)
                              from p in g
                              where p.UnitPrice == minPrice
                              select new
                              {
                                  g.Key,
                                  minPrice
                              };

            //foreach (var c in MinPriceLet)
            //{
            //    Console.WriteLine(c);
            //}


            //10

            //11
            var MaxPrice = ProductList.GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          Category = g.Key,
                                          MaxPrice = g.Max(p => p.UnitPrice)
                                      });

            foreach (var c in MaxPrice)
            {
                Console.WriteLine(c);
            }

            //12
            var MaxPriceProduct = ProductList.GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          Category = g.Key,
                                          MaxPriceProduct = g.Max()
                                      });
            //foreach (var c in MaxPriceProduct)
            //{
            //    Console.WriteLine(c);
            //}

            //13

            //14
            var AVGPrice = ProductList.GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          Category = g.Key,
                                          AVGPrice = g.Average(p => p.UnitPrice)
                                      });

            //foreach (var c in AVGPrice)
            //{
            //    Console.WriteLine(c);
            //}
            #endregion
            #region LINQ - Ordering Operators 
            //1 
            var result = ProductList.OrderBy(p => p.ProductName);

            //2 
            // some LINQ methods can recieve an additional parameter to determine the comparing approach
            var res = words.OrderBy(s => s , StringComparer.OrdinalIgnoreCase);

            //3
            var res01 = ProductList.OrderByDescending(p => p.UnitsInStock);

            //4
            var res02 = Arr.OrderBy(s => s.Length)
                           .ThenBy(s => s);

            //5
            var res03 = words.OrderBy(w => w.Length)
                             .ThenBy(w => w , StringComparer.OrdinalIgnoreCase);

            //6
            var res04 = ProductList.OrderByDescending(p => p.Category)
                                   .ThenBy(p => p.UnitPrice);

            //7
            var res05 = words.OrderBy(w => w.Length)
                             .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);

            //8
            var res06 = Arr.Where((n) => n[1] == 'i')
                           .Reverse();
            #endregion
            #region LINQ – Transformation Operators 
            //1
            var res07 = ProductList.Select(p => p.ProductName);

            //2
            
            var res08 = words01.Select(w => new 
            { 
                LowerName = w.ToLower(),
                UpperName = w.ToUpper()
            });

            //3
            var res09 = ProductList.Select(p => new
            {
                p.ProductName,
                Price = p.UnitPrice,
                p.UnitsInStock
            });


            //4
            var res10 = Arr01.Select((num ,i) => new
            {
                result = $"{num} : {num == i}"  
            });
            //foreach (var line in res10)
            //{
            //    Console.WriteLine(line);
            //}


            //5
            // SelectMany takes two FUNCs 1. Func<TSource, IEnumerable<TCollection>> collectionSelector,
            //                            2. Func<TSource, TCollection, TResult> resultSelector
            var res11 = numbersA.SelectMany( numA => numbersB.Where(numB => numB > numA) , (numA , numB) => new
            {
                result = $"{numA} is less than {numB}"
            });
            //foreach (var line in res11)
            //{
            //    Console.WriteLine(line);
            //}


            //6
            var res12 = CustomerList.SelectMany(c => c.Orders
                                    .Where(o => o.Total < 500));

            //foreach (var line in res12)
            //{
            //    Console.WriteLine(line);
            //}

            //7
            var res13 = CustomerList.SelectMany(c => c.Orders
                                    .Where(o => o.OrderDate.Year >= 1998));
            //foreach (var line in res13)
            //{
            //    Console.WriteLine(line);
            //}
            #endregion
            #region LINQ - Aggregate Operators 
            //1 
            var res14 = Arr01.Count(num => num % 2 == 1);

            //2
            var res15 = CustomerList.Select(c => new 
            {
                c.Name,
                NumberOfOrders = c.Orders.Length
            });

            //3
            var res16 = ProductList.GroupBy(p => p.Category)
                                   .Select(g => new
                                   {
                                       Category = g.Key,
                                       NumberOfProducts = g.Count()
                                   });

            //4
            var res17 = Arr01.Sum();

            //5


            //6
            var res18 = ProductList.GroupBy(p => p.Category)
                                              .Select(g => new // g represents each group
                                              {
                                                  Category = g.Key,
                                                  Total_Units = g.Sum(p => p.UnitsInStock)
                                              });

            //7


            //8
            var res19 = ProductList.GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          Category = g.Key,
                                          MinPriceProduct = g.Min(p => p.UnitPrice)
                                      });
            //foreach (var c in MinPrice)
            //{
            //    Console.WriteLine(c);
            //}


            //9
            var res20 = from p in ProductList
                              group p by (p.Category) into g
                              let minPrice = g.Min(p => p.UnitPrice)
                              from p in g
                              where p.UnitPrice == minPrice
                              select new
                              {
                                  g.Key,
                                  minPrice
                              };

            //foreach (var c in MinPriceLet)
            //{
            //    Console.WriteLine(c);
            //}


            //10

            //11
            var res21 = ProductList.GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          Category = g.Key,
                                          MaxPrice = g.Max(p => p.UnitPrice)
                                      });

            foreach (var c in MaxPrice)
            {
                Console.WriteLine(c);
            }

            //12
            var res22 = ProductList.GroupBy(p => p.Category)
                                      .Select(g => new
                                      {
                                          Category = g.Key,
                                          MaxPriceProduct = g.Max()
                                      });
            //foreach (var c in MaxPriceProduct)
            //{
            //    Console.WriteLine(c);
            //}

            //13
            var res23 = ProductList.GroupBy(p => p.Category)
                                   .Select(g => new 
                                   {
                                       category = g.Key,
                                       AVGPrice = g.Average(p => p.UnitPrice)
                                   });
            #endregion
            #region LINQ - Partitioning Operators 
            //1
            var res24 = CustomerList.Where(c => c.Country == "Germany")
                                    .SelectMany(c => c.Orders.Take(3),(c , o) => new
                                    {
                                        c.Name,
                                        o
                                    });
            //foreach (var c in res24)
            //{
            //    Console.WriteLine(c);
            //}


            //2
            var res25 = CustomerList.Where(c => c.Country == "Germany")
                                    .SelectMany(c => c.Orders.Skip(2), (c, o) => new
                                    {
                                        c.Name,
                                        o
                                    });

            //3
            var res26 = Arr01.TakeWhile((num , i) => num >= i);

            //4
            var res27 = Arr01.SkipWhile(num => num % 3 != 0);

            //5
            var res28 = Arr01.SkipWhile((num , i) => num >= i);
            #endregion
            #region LINQ - Quantifiers 
            //2
            var res29 = ProductList.Where(p => p.UnitsInStock == 0)
                                   .GroupBy(p => p.Category)
                                   .Select(g => new
                                   {
                                       Category = g.Key,
                                       products = g.ToList()
                                   });

            //3
            var res30 = ProductList
                                   .GroupBy(p => p.Category)
                                   .Where(g => g.All(p => p.UnitsInStock > 0))
                                   .Select(g => new
                                   {
                                       Category = g.Key,
                                       products = g.ToList()
                                   });
            #endregion
        }
    }
}
