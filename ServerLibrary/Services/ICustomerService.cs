using ServerLibrary.Dtos;

namespace ServerLibrary.Services;

public interface ICustomerService
{
    CustomerDTO GetByName(string customerName);
    CustomerDTO GetById(int customerId);
    IEnumerable<CustomerDTO> GetAll();
    void Delete(int customerId);
    void Update(int customerId, CustomerInputDTO customer);
    void Create(CustomerInputDTO customer);
}