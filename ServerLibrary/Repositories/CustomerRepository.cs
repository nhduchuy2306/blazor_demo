using ServerLibrary.Models;

namespace ServerLibrary.Repositories
{
    public class CustomerRepository : AbstractRepository<Customer, int>
    {
        public CustomerRepository(ManagementdbContext context) : base(context)
        {
        }

        public Customer? GetByName(string customerName)
        {
            return _context.Customers.SingleOrDefault(c => c.CustomerName.Contains(customerName));
        }
    }
}
