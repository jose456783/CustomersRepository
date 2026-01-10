using customers1.Data;
using customers1.entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace customers1.repositories
{
    public class CustomersRepository : ICustomersRepository
    {

        //DbContext injetado via DI.
        //O escopo é controlado pelo ASPNET CORE.
        private readonly AppDbContext _context;

        public CustomersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CriarAsync(Customer customer)
        {
            //Adicina a entidade ao context e persiste no banco.
           _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Customer customer)
        {
            //Marca a entidade como modificada. 
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Customer customer)
        {
            //Remoce a entidade do contexto e remove do banco.
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> ObterPorIdAsync(int id)
        {
            //Faz uma busca do cliente pelo o seu Id.
            return await _context.Customers.SingleOrDefaultAsync(u => u.Id == id);
        }

       
        public async Task<IEnumerable<Customer>> ObterTodosAsync()
        {
            // Retorna todos os clientes cadastrados.
            return await _context.Customers.ToListAsync();
        }

        
    }
}
