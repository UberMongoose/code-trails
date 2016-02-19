using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanguageGeneral
{
    internal class Customer
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

    [TestClass]
    public class Properties
    {
        [TestMethod]
        public void TestProperties()
        {            
            Customer customer = new Customer();
            customer.Number = 9;
            customer.Name = "Mrs Lovett's Pie Shop";
        }
    }
}
