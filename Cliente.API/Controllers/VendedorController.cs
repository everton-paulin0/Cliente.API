using Cliente.Application.Model;
using Cliente.Application.Services;
using Cliente.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : Controller
    {
        private readonly IVendedorServices _services;
        public VendedorController(IVendedorServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string search = "")
        {
            var result = _services.GetAll(search);

            if (!result.IsSucess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _services.GetById(id);

            if (!result.IsSucess)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateVendedorInputModel model)
        {
            var result = _services.Insert(model);

            if (!result.IsSucess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateVendedorInputModel model)
        {
            model.IdVendedor = id; 

            var result = _services.UpdateVendedor(model);

            if (!result.IsSucess)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _services.Delete(id);

            if (!result.IsSucess)
                return NotFound(result);

            return Ok(result);
        }
    }
}
