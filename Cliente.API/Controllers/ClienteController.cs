using Cliente.Application.Model;
using Cliente.Application.Services;
using Cliente.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesServices _services;
        public ClienteController(AppDbContext context, IClientesServices services)
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

        // GET: api/cliente/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _services.GetById(id);

            if (!result.IsSucess)
                return NotFound(result);

            return Ok(result);
        }

        // POST: api/cliente
        [HttpPost]
        public IActionResult Post([FromBody] CreateClientInputModel model)
        {
            var result = _services.Insert(model);

            if (!result.IsSucess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
        }

        // PUT: api/cliente/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateClientInputModel model)
        {
            // garante que o ID do route seja usado
            model.IdCliente = id;

            var result = _services.Update(model);

            if (!result.IsSucess)
                return BadRequest(result);

            return Ok(result);
        }

        // DELETE: api/cliente/5
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
