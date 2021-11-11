using ecommerce.Encomenda.Application.Interfaces;
using ecommerce.Encomenda.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerce.WebApi.V1.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoApplicationService _pedidoApplicationService;

        public PedidosController(IPedidoApplicationService pedidoApplicationService)
        {
            _pedidoApplicationService = pedidoApplicationService;
        }

        [HttpGet]        
        public async Task<IActionResult> ObterPedidos()
        {
            try
            {
                var pedidos = await _pedidoApplicationService.ObterPedidos();

                return Ok(pedidos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
