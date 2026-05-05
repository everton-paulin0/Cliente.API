using Cliente.Application.Model;
using Cliente.Application.Services;
using Cliente.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Cliente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly IPedidosServices _services;
        public PedidoController(IPedidosServices services)
        {
            _services = services;

        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string search = "")
        {
            var result = _services.GetAll(search);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _services.GetById(id);

            if (!result.IsSuccess)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePedidoInputModel model)
        {
            var result = _services.Insert(model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);



        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _services.Delete(id);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdatePedidoInputModel model)
        {
            model.IdPedido = id;

            var result = _services.UpdatePedido(model);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{pedidoId}/itens/{produtoId}")]
        public IActionResult RemoverItem(int pedidoId, int produtoId)
        {
            var result = _services.RemoverItem(pedidoId, produtoId);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
