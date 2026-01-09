using customers1.entities;

namespace customers1.repositories
{
    public interface ICustomersRepository
    {
        Task CriarAsync(Customer customer);
        Task<IEnumerable<Customer>> ObterTodosAsync();
        Task<Customer> ObterPorIdAsync(int id);
        Task AtualizarAsync(Customer customer);

    }
}
