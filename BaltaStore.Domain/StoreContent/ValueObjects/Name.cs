namespace BaltaStore.Domain.StoreContent.ValueObjects
{
    public class Name
    {
        public string FirsName { get; private set; }
        public string LastName { get; private set; }

        public Name(string firsName, string lastName)
        {
            FirsName = firsName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FirsName} {LastName}";
        }
    }
}