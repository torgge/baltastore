using BaltaStore.Domain.StoreContext.Services;

namespace BaltaStore.Infra.StoreContext.EmailService
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string @from, string subject, string body)
        {
            //todo: implementar.
            throw new System.NotImplementedException();
        }
    }
}