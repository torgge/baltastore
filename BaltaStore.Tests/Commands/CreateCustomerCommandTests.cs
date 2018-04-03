using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();

            command.FirstName = "George";
            command.LastName = "Bonespírito";
            command.Document = "123123123123";
            command.Email = "torgge@gmail.com";
            command.Phone = "12312313131";
            
            Assert.AreEqual(false, command.Valid());
        }
        
    }
}