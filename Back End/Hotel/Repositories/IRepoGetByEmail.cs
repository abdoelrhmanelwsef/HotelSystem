namespace Hotel.Repositories
{
    public interface IRepoGetByEmail<T>
    {
        public T GetByEmail(string email);
    }
}
