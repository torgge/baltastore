using BaltaStore.Domain.StoreContext.Entities;

namespace BaltaStore.Domain.StoreContext.Repositories
{
    public interface ICustomeRepository
    {
        bool CheckDocument(string document);
        
        bool CheckEmail(string email);

        void Save(Customer customer);
    }
}