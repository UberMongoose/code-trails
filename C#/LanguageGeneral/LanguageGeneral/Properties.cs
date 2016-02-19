using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanguageGeneral
{
    public class Customer
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public string Description { get; protected set; }
    }

    public class MurderousCustomer :  Customer
    {
        public MurderousCustomer()
            : base()
        {
            Description = "A nasty operation.";
        }
    }

    [TestClass]
    public class Properties
    {
        [TestMethod]
        public void TestProperties()
        {            
            Customer customer = new MurderousCustomer();
            customer.Number = 9;
            customer.Name = "Mrs Lovett's Pie Shop";
            Assert.IsTrue(customer.Description == "A nasty operation.");
        }
    }
}
