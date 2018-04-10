using System.Runtime.InteropServices;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            
            command.FirstName = "Juca";
            command.LastName = "Bala";
            command.Document = "28659170377";
            command.Email = "meuemail@gmail.com";
            command.Phone = "44454556654";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);
            
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
            
        }
    }
}