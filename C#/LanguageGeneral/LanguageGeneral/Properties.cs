using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LanguageGeneral
{
    public abstract class Customer
    {
        protected int rating;

        public int Number { get; set; }
        public string Name { get; set; }
        public virtual int Rating
        {
            get { return rating; }
            set
            {
                if (rating < 5)
                    rating++;
            }
        }

        public Customer()
        {
            rating = 1;
        }


        public abstract string Description { get; protected set; }
    }

    public class MurderousCustomer : Customer
    {
        public override string Description { get; protected set; }
        public override int Rating
        {
            get
            {
                return base.Rating;
            }

            set
            {
                base.rating = 0;
            }
        }

        public MurderousCustomer()
            : base()
        {
            base.Rating = 0;
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

            for (int i = 0; i < 10; i++)
                customer.Rating++;

            Assert.IsTrue(customer.Rating == 0);
        }
    }
}
