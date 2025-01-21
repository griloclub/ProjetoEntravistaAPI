using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteDev.Dtos;
using ProjetoTesteDev.Model;
using ProjetoTesteDev.Repository.Mesa;

namespace ProjetoTesteDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaRepository _mesaRepository;

        public MesaController(IMesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }

        [HttpGet("abertas")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<List<MesaResumoDto>>>> ListarMesasAbertas()
        {
            
                var mesas = await _mesaRepository.ListarMesasAbertas();
                return Ok(mesas);          
        }

        [HttpGet("Detalhes")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<MesaDetalhesDto>>> BuscarDetalhesMesa(int id)
        {         
                var detalhesMesa = await _mesaRepository.BuscarDetalhesPorId(id);               
                return Ok(detalhesMesa);          
        }

    }
}
