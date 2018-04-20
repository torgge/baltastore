using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.DataContexts;
using Dapper;
using System.Data;
using System.Linq;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomeRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            return _context
                .Connection
                .Query<bool>("spCheckDocument",
                    new {Document = document},
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>("spCheckEmail",
                    new {Email = email},
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context
                .Connection
                .Execute("spCreateCustomer",
                    new
                    {
                        Id = customer.Id,
                        FirstName = customer.Name.FirsName,
                        LastName = customer.Name.LastName,
                        Document = customer.Document.Number,
                        Email = customer.Email.Address,
                        Phone = customer.Phone
                    }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context
                    .Connection
                    .Execute("spCreateAddress",
                        new
                        {
                            Id = address.Id,
                            CustomerId = customer.Id,
                            Number = address.Number,
                            Complement = address.Complement,
                            District = address.District,
                            City = address.City,
                            State = address.State,
                            Country = address.Country,
                            ZipCode = address.ZipCode,
                            Type = address.Type
                        }, commandType: CommandType.StoredProcedure);
            }
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context
                    .Connection
                    .Query<CustomerOrdersCountResult>(
                        "spGetCustomerOrdersCount",
                        new {Document = document},
                        commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _context
                    .Connection
                    .Query<ListCustomerQueryResult>(
                        "SELECT [Id], CONCAT([FIRSTNAME],' ',[LASTNAME]) AS [NAME], [DOCUMENT], [EMAIL] FROM [CUSTOMER]",
                        new { });
                   
        }

        public GetCustomerQueryResult GetById(Guid id)
        {
            return _context
                .Connection
                .Query<GetCustomerQueryResult>(
                    "SELECT [Id], CONCAT([FIRSTNAME],' ',[LASTNAME]) AS [NAME] , [DOCUMENT], [EMAIL] FROM [CUSTOMER] WHERE [Id]=@id", new { Id = id })
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _context
                .Connection
                .Query<ListCustomerOrderQueryResult>(
                    "SELECT [Id], CONCAT([FIRSTNAME],' ',[LASTNAME]) AS [NAME] , [DOCUMENT], [EMAIL] FROM [CUSTOMER] WHERE [Id]=@id",
                    new {Id = id});

        }
    }
}