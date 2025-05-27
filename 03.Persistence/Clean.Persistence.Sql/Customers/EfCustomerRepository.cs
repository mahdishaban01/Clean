using Clean.Domain.Entities.Customers;
using Clean.Persistence.Sql.DbContext;
using Clean.Repositories.Abstractions.Customers;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence.Sql.Customers;

public class EfCustomerRepository(ApplicationDbContext context) : ICustomerRepository
{
    public async Task Add(Customer customer) => await context.Customers.AddAsync(customer);

    public async Task<bool> Exists(int id) => await context.Customers.AnyAsync(c => c.Id == id);

    public async Task<Customer?> GetById(int id) => await context.Customers.FindAsync(id);
}
