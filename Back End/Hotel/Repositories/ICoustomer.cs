namespace Hotel.Repositories
{
    public interface ICoustomer<T>
    {
        public ICollection<T> GetAllCustomers();

    }
}
