using Clean.Domain.Entities.Customers;

namespace Clean.Repositories.Abstractions.Customers;

public interface ICustomerRepository
{
    Task Add(Customer customer);
    Task<bool> Exists(int id);
    Task<Customer?> GetById(int id);
}
