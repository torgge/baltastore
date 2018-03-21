using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContent.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirsName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firsName, string lastName)
        {
            FirsName = firsName;
            LastName = lastName;

            AddNotifications(
                    new ValidationContract()
                    .Requires()
                    .HasMinLen(FirsName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(FirsName, 40, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                    .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                    .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                );
        }

        public override string ToString()
        {
            return $"{FirsName} {LastName}";
        }
    }
}