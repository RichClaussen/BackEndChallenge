using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChellengeAspireApp.ApiService
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CrmDataContext context;

        public CustomerController(CrmDataContext context) => this.context = context;

        [HttpGet]
        public async Task<Customer[]> GetCustomers()
            => await context.Customers.ToArrayAsync();
    }
}
