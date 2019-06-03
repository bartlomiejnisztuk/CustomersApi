using System.Linq;
using CustomersApi.BL.Services;
using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApi.Controllers
{
    //TODO add mapper, where ? to BL? where put dtos ? to BL ?, where run mapping ? maybe each layer should have its own layer ? (controller- view models, bl - dtos, DAL- > entities)
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET api/values
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _customerService.GetAllCustomers().ToList();

            return new JsonResult(result);
        }

        // GET api/values/5
        [HttpGet("{id}/{name}")]
        public JsonResult Get(string id, string name)
        {
            var client = _customerService.GetCustomer(id, name);

            return new JsonResult(client);
        }

        // POST api/customers
        [HttpPost]
        public JsonResult Add([FromBody] CustomerModel model)
        {
            var result = _customerService.AddCustomer(model);

            return new JsonResult(result);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
