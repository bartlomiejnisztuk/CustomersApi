using System;
using System.Collections.Generic;
using CustomersApi.BL.Services;
using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;

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
            var isSuccess = _addressService.UpdateAddress(model);

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
    }
}
