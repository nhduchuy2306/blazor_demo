using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ServerLibrary.Dtos;
using ServerLibrary.Models;
using ServerLibrary.Repositories;

namespace ServerLibrary.Services.impl;

public class CustomerService : ICustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public CustomerService(CustomerRepository customerRepository, ITokenService tokenService, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _tokenService = tokenService;
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

        var passwordHashd = new PasswordHasher<Customer>();
        newCustomer.Password = passwordHashd.HashPassword(newCustomer, newCustomer.Password);

        _customerRepository.Create(newCustomer);
    }

    public AuthenticationOutputDTO Login(AuthenticationDTO authenticationDTO)
    {
        var customer = _customerRepository.GetCustomerByCustomerCode(authenticationDTO.CustomerCode);

        if (customer == null)
        {
            throw new KeyNotFoundException("Invalid customer code or password");
        }

        // Verify the password
        var passwordHasher = new PasswordHasher<Customer>();
        var result = passwordHasher.VerifyHashedPassword(customer, customer.Password, authenticationDTO.Password);

        if (result != PasswordVerificationResult.Success)
        {
            throw new KeyNotFoundException("Invalid customer code or password");
        }

        AccountDTO accountModel = new AccountDTO
        {
            CustomerId = customer.CustomerId,
            CustomerCode = customer.CustomerCode,
            CustomerName = customer.CustomerName,
            RoleId = customer.RoleId,
            RoleName = customer.Role.RoleName
        };

        var token = _tokenService.GenerateToken(accountModel);

        return new AuthenticationOutputDTO
        {
            Account = accountModel,
            AccessToken = token
        };
    }
}