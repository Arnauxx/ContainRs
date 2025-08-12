using ContainRs.Application.UseCases;
using ContainRs.Domain.Models;
using ContainRs.WebApp.Data;
using ContainRs.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContainRs.WebApp.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ApiClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApiClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string? estado)
        {
            var useCase = new ConsultarClientes(UfStringConverter.From(estado), _context);
            var clientes = await useCase.ExecutarAsync();
            return Ok(clientes.Select(c => new ClienteResponse(c.Id.ToString(), c.Nome, c.Email.Value)));
        }
    }
}
