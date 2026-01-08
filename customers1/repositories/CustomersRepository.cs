using customers1.Data;
using customers1.entities;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace customers1.repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AppDbContext _context;

        public CustomersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CriarAsync(Customer customer)
        {
           _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> ObterTodosAsync()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
