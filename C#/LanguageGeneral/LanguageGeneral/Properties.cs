using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanguageGeneral
{
    public abstract class Customer
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public abstract string Description { get; protected set; }
    }

    public class MurderousCustomer :  Customer
    {
        public override string Description { get; protected set; }

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

            // Customer illegalCustomer = new Customer(); /* Abstract class, can't be instantiated. */
        }
    }
}
