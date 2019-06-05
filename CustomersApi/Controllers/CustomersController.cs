using System;
using System.Collections.Generic;
using CustomersApi.BL.Services;
using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<CustomerModel>> GetAll()
        {
            var result = _customerService.GetAllCustomersWithAdresses();
            if (result == null)
            {
                return NoContent();
            }

            return Ok(new JsonResult(result));
        }

        [HttpGet("{id}/{name}")]
        public ActionResult<CustomerModel> Get(string id, string name)
        {
            if (string.IsNullOrEmpty(id)|| string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var customer = _customerService.GetCustomer(id, name);

            if (customer == null)
            {
                return NoContent();
            }

            return Ok(new JsonResult(customer));
        }

        [HttpPost]
        public ActionResult<CustomerModel> Add([FromBody] CustomerModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                var result = _customerService.AddCustomer(model);

                return Ok(new JsonResult(result));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomerModel model)
        {
            var isSuccess = _customerService.Update(model);

            if (isSuccess)
            {
                return Ok();
            }

            return UnprocessableEntity("Unable to update");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] CustomerModel model)
        {
            var isSuccess = _customerService.Delete(model);

            if (isSuccess)
            {
                return Ok();
            }

            return UnprocessableEntity("Unable to delete");
        }
    }
}
