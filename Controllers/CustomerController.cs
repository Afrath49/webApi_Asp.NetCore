using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class CustomerController : Controller
    {
        private readonly CustomerApidbcontext dbContext;

        public CustomerController(CustomerApidbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public CustomerApidbcontext DbContext { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            return Ok(await dbContext.customer.ToListAsync());
            
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(AddCustomerRequest addContactRequest)
        {
            var contact = new Customer()
            {
                Id = addContactRequest.Id,
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                Name = addContactRequest.Name,
                Phone = addContactRequest.Phone
            };

             await dbContext.customer.AddAsync(contact);
            await dbContext.SaveChangesAsync();

            return Ok(contact);
        }

        [HttpGet("{id:int}")]
        

        public async Task<IActionResult> GetbyId(int id)
        {
           
           return Ok(await dbContext.customer.FindAsync(id));
            

            
        }
    }
}
