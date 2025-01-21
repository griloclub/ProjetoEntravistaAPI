using ProjetoTesteDev.Dtos;
using ProjetoTesteDev.Model;

namespace ProjetoTesteDev.Repository.Mesa
{
    public interface IMesaRepository
    {
        Task<ServiceResponse<List<MesaResumoDto>>> ListarMesasAbertas();
        Task<ServiceResponse<MesaDetalhesDto>> BuscarDetalhesPorId(int id);
    }
}
