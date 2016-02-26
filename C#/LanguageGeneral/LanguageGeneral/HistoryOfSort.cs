using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LanguageGeneral
{
    internal class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
            {
                new Product { Name="Watership Down", Price = 6.25m },
                new Product { Name="The Color of Magic", Price = 7.00m },
                new Product { Name="Guards! Guards!", Price = 12.00m },
                new Product { Name="War and Peace", Price = 23.00m }                
            };
        }
    }
    

    [TestClass]
    public class HistoryOfSort
    {
        private bool CheckNamesOrdered(List<Product> list)
        {
            List<Product> sorted = Product.GetSampleProducts();
            sorted.Sort((x, y) => x.Name.CompareTo(y.Name));
            
            for (int i = 0; i < sorted.Count; i++)
            {
                if (sorted[i].Name != list[i].Name)
                    return false;
            }

            return true;
        }

        private bool CheckNamesOrdered(ArrayList list)
        {
            return CheckNamesOrdered(list.Cast<Product>().ToList());
        }

        private class ProductNameComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                Product first = x as Product;
                Product second = y as Product;

                if (x == null || y == null)
                    throw new InvalidCastException("Objects passed in are not Products.");

                return first.Name.CompareTo(second.Name);
            }
        }

        [TestMethod]
        public void CSharp1IComparer()
        {
            ArrayList products = new ArrayList(Product.GetSampleProducts());
            products.Sort(new ProductNameComparer());
            Assert.IsTrue(CheckNamesOrdered(products));
        }        
    }
}
