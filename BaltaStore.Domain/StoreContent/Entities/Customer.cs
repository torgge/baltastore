using System.Collections.Generic;
using BaltaStore.Domain.StoreContent.ValueObjects;

namespace BaltaStore.Domain.StoreContent.Entities
{
    //SOLID

    public class Customer
    {
        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            AdrrAddresses = new List<Address>();
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> AdrrAddresses { get; private set; }


        public override string ToString()
        {
            return $"{Name.ToString()}";
        }
    }
}