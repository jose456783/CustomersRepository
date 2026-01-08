using customers1.customerModel;
using customers1.entities;
using customers1.repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace customers1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersRepository _customersRepository;
        public CustomersController(ICustomersRepository repository)
        {
            _customersRepository = repository;
        }

        [HttpPost]
        public async Task <IActionResult> Criar(CustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = new Customer(request);
           await _customersRepository.CriarAsync(customer);
            
            return Ok(customer);
        }
        [HttpGet]
        [Route("ObterTodos")]

        public async Task<IActionResult> ObterTodos()
        {
            var customers = await _customersRepository.ObterTodosAsync();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = customers.Select(a => new CustomerResponse
            {
                Name = a.Name,
                ExternallId = a.ExternalId,
                Document = a.Document,
                DocumentType = a.DocumentType
            });
            return Ok(response);

        }
    }
}
