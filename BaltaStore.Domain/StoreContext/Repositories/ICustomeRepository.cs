using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;

namespace BaltaStore.Domain.StoreContext.Repositories
{
    public interface ICustomeRepository
    {
        bool CheckDocument(string document);
        
        bool CheckEmail(string email);

        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);

        IEnumerable<ListCustomerQueryResult> Get();

        GetCustomerQueryResult GetById(Guid id);

        IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id);
    }
}