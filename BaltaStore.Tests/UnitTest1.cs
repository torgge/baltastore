using BaltaStore.Domain.StoreContent.Entities;
using BaltaStore.Domain.StoreContent.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var customer = new Customer( 
                new Name("George","Bonespírito"),
                new Document("12312213"), 
                new Email("torgge@gmail.com"), 
                "1312312312");
            customer.ToString();
        }
    }
}