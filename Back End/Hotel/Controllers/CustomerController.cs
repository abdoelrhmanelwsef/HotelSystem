using Hotel.Models;
using Hotel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        IRepository<Customer> CustomerRepo;
        IRepoGetByEmail<Customer> CustomerRepoGetByEmail;

        public CustomerController(IRepository<Customer> _customerRepo,IRepoGetByEmail<Customer> repoGetByEmail)
        {
            this.CustomerRepo = _customerRepo;
            this.CustomerRepoGetByEmail = repoGetByEmail;
        }

        [HttpGet]
        public ActionResult getAllCustomer()
        {
            if (CustomerRepo.getAll().Count > 0)
            {
                return Ok(CustomerRepo.getAll());
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult addNewCustomer(Customer customer)
        {
            CustomerRepo.creat(customer);
            return Created("url", customer);
        }

        [HttpGet("id")]
        public ActionResult getById(int id)
        {
            Customer customer=CustomerRepo.getById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
               return Ok(customer);
            }
        }
        [HttpGet("email")]
        public ActionResult getCustomerByEmail(string email)
        {
            Customer customer = CustomerRepoGetByEmail.GetByEmail(email);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }
    }
}
