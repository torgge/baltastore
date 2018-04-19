using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("André", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            var customer = new Customer(name, document, email, "551999876542");
            var customers = new List<Customer>();
            customers.Add(customer);
            
            return customers;
        }
        
        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }
        
        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }
        
        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new {message = "Cliente removido com sucesso"};
        }
        
        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("André", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            var customer = new Customer(name, document, email, "551999876542");

            return customer;
        }
        
        [HttpGet]
        [Route("orders")]
        public List<Order> GetOrders()
        {
            var name = new Name("André", "Baltieri");
            var document = new Document("46718115533");
            var email = new Email("hello@balta.io");
            var customer = new Customer(name, document, email, "551999876542");
            var order = new Order(customer);
            
            var mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            var keyboard = new Product("Teclado Gamer", "Teclado Gamer", "Teclado.jpg", 100M, 10);
            var chair = new Product("Cadeira Gamer", "Cadeira Gamer", "Cadeira.jpg", 100M, 10);
            var monitor = new Product("Monitor Gamer", "Monitor Gamer", "Monitor.jpg", 100M, 10);
            
            order.AddItem(mouse, 4);
            order.AddItem(keyboard, 2);
            order.AddItem(chair, 4);
            order.AddItem(monitor, 5);

            var orders = new List<Order>();
            orders.Add(order);

            return orders;
        }
        
    }
}