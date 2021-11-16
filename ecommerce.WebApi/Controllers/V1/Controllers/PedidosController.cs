using ecommerce.Encomenda.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ecommerce.WebApi.Controllers.V1.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoApplicationService _pedidoApplicationService;

        public PedidosController(IPedidoApplicationService pedidoApplicationService)
        {
            _pedidoApplicationService = pedidoApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterPedidos([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

                var pedidos = await _pedidoApplicationService.ObterPedidos(validFilter.PageNumber, validFilter.PageSize);

                return Ok(pedidos);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
