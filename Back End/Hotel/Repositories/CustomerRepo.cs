using Hotel.Models;

namespace Hotel.Repositories
{
    public class CustomerRepo : IRepository<Customer>,IRepoGetByEmail<Customer>
    {
        HotelEnteties context;

        public CustomerRepo(HotelEnteties _context)
        {
            this.context = _context;
        }

        public int creat(Customer customer)
        {
            context.Add(customer);
            try
            {
                int rows = context.SaveChanges();
                return rows;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public ICollection<Customer> getAll()
        {
            return context.Coustomers.ToList();
        }

        public Customer GetByEmail(string email)
        {
            Customer? customer = context.Coustomers.FirstOrDefault(d => d.Email == email);
            return customer;
        }

        public Customer getById(int id)
        {
            Customer? customer = context.Coustomers.FirstOrDefault(d => d.Id == id);
            return customer;
        }
    }
}
