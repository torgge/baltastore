using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("cutomers")]
        public List<Customer> Get()
        {
            return null;
        }
        
        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] Customer customer)
        {
            return customer;
        }
        
        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] Customer customer)
        {
            return customer;
        }
        
        [HttpDelete]
        [Route("customers/{id}")]
        public Customer Delete()
        {
            return null;
        }
        
        [HttpGet]
        [Route("cutomer/{id}")]
        public Customer GetById(Guid id)
        {
            return null;
        }
        
        [HttpGet]
        [Route("orders")]
        public List<Order> GetOrders()
        {
            return null;
        }
        
        
        
    }
}