using Microsoft.EntityFrameworkCore;
using ServerLibrary.Models;

namespace ServerLibrary.Repositories;

public class CustomerRepository : Repository<Customer, int>
{
    public CustomerRepository(ManagementdbContext context) : base(context)
    {
    }

    public Customer? GetByName(string customerName)
    {
        return _context.Customers.SingleOrDefault(c => c.CustomerName.Contains(customerName));
    }

    public new IEnumerable<Customer> GetAll()
    {
        return _context.Customers
            .Include(c => c.Role)
            .ToList();
    }

    public Customer? GetCustomerByCustomerIdAndPassword(string customerCode, string password)
    {
        return _context.Customers
            .Include(c => c.Role)
            .SingleOrDefault(c => c.CustomerCode == customerCode && c.Password == password);
    }

    public Customer? GetCustomerByCustomerCode(string customerCode)
    {
        return _context.Customers
            .Include(c => c.Role)
            .SingleOrDefault(c => c.CustomerCode == customerCode);
    }
}
