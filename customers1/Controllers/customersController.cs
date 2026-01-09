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
        public async Task<IActionResult> Criar(CustomerRequest request)
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
        [HttpGet("{id}")]
        

        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var customer = await _customersRepository.ObterPorIdAsync(id);
            if (customer == null)
            {
                return NotFound($"Usuário com o Id {id}, não encontrado.");
            }
            //var response = customer.Select(a => new CustomerResponse
            //{
            //    Name = a.Name,
            //    ExternallId = a.ExternalId,
            //    Document = a.Document,
            //    DocumentType = a.DocumentType
            //});

            return Ok(customer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(CustomerRequest customer, int id)
        {
            var customerExisting = new Customer(customer);
            if (customerExisting == null)
            {
                return NotFound($"Usuário com o Id {id}, não encontrado.");
            }
            customerExisting.Name= customer.Name;
            customerExisting.Document = customer.Document;
            customerExisting.Email = customer.Email;

            var response = new CustomerResponse
            {
                Name = customerExisting.Name,
                Document = customerExisting.Document,
                Email = customerExisting.Email


               
            };
            

            await _customersRepository.AtualizarAsync(customerExisting);
            return Ok(customerExisting);

        }
    }
}
