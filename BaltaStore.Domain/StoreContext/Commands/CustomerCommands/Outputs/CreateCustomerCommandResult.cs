using System;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        public CreateCustomerCommandResult()
        {
        }

        public CreateCustomerCommandResult(Guid id, string firsName, string email)
        {
            Id = id;
            FirsName = firsName;
            Email = email;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Guid Id { get; set; }
        public string FirsName { get; set; }
        public string Email { get; set; }
        
    }
}