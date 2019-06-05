using System;
using System.Collections.Generic;
using CustomersApi.BL.Services;
using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace CustomersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult<List<AddressModel>> GetAll()
        {
            var result = _addressService.GetAllAddresses();

            if (result == null)
            {
                return NoContent();
            }

            return Ok(new JsonResult(result));
        }

        [HttpGet("{id}/{name}")]
        public ActionResult<AddressModel> Get(string id, string name)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }

            var customer = _addressService.GetCustomerAddresses(id, name);

            if (customer == null)
            {
                return NoContent();
            }

            return Ok(new JsonResult(customer));
        }

        [HttpPost]
        public ActionResult<AddressModel> Add([FromBody] AddressModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            try
            {
                var result = _addressService.AddAddress(model);

                return Ok(new JsonResult(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] AddressModel model)
        {
            var isSuccess = _addressService.Update(model);

            if (isSuccess)
            {
                return Ok();
            }

            return UnprocessableEntity("Unable to update");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] AddressModel model)
        {
            var isSuccess = _addressService.Delete(model);

            if (isSuccess)
            {
                return Ok();
            }

            return UnprocessableEntity("Unable to delete");
        }

        [HttpGet("customerAddressOfType/{customerId}/{customerName}/{addressName}")]
        public IActionResult Get(string customerId, string customerName, string addressName)
        {
            var result = _addressService.GetCustomerAddressesOfName(customerId, customerName, addressName);

            if (result == null || !result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
