using AutoMapper;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

namespace ServerLibrary.Services.impl;

public class CustomerService : ICustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(CustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public CustomerDTO GetById(int customerId)
    {
        Customer? customer = _customerRepository.GetById(customerId);
        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with id {customerId} not found");
        }

        return _mapper.Map<CustomerDTO>(customer);
    }

    public CustomerDTO GetByName(string customerName)
    {
        Customer? customer = _customerRepository.GetByName(customerName);
        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with name {customerName} not found");
        }

        return _mapper.Map<CustomerDTO>(customer);
    }

    public IEnumerable<CustomerDTO> GetAll()
    {
        var customers = _customerRepository.GetAll();
        return _mapper.Map<IEnumerable<CustomerDTO>>(customers);
    }

    public void Delete(int customerId)
    {
        Customer? customer = _customerRepository.GetById(customerId);
        if (customer == null)
        {
            throw new KeyNotFoundException($"Customer with id {customerId} not found");
        }

        _customerRepository.Delete(customer);
    }

    public void Update(int customerId, CustomerInputDTO customer)
    {
        Customer? existingCustomer = _customerRepository.GetById(customerId);
        if (existingCustomer == null)
        {
            throw new KeyNotFoundException($"Customer with id {customerId} not found");
        }

        Customer updatedCustomer = _mapper.Map<Customer>(customer);
        updatedCustomer.CustomerId = customerId;
        _customerRepository.Update(updatedCustomer);
    }

    public void Create(CustomerInputDTO customer)
    {
        Customer newCustomer = _mapper.Map<Customer>(customer);
        _customerRepository.Create(newCustomer);
    }
}