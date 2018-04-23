using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomeRepository _repository;
        private readonly CustomerHandler _customerHandler;

        public CustomerController(ICustomeRepository repository, CustomerHandler customerHandler)
        {
            _repository = repository;
            _customerHandler = customerHandler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }
        
        [HttpPost]
        [Route("v1/customers")]
        public object Post([FromBody] CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_customerHandler.Handle(command);
            if (_customerHandler.Invalid)
                return BadRequest(_customerHandler.Notifications);
            
            return result;
        }
        
        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete()
        {
            return new {message = "Cliente removido com sucesso"};
        }
        
        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.GetById(id);
        }
        
        [HttpGet]
        [Route("v2/customers/{id}")]
        public GetCustomerQueryResult GetByDocument(Guid document)
        {
            return _repository.GetById(document);
        }
        
        [HttpGet]
        [Route("v1/orders/{id}/orders")]
        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }
        
    }
}