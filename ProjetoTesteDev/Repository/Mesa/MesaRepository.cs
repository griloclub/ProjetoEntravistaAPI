using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoTesteDev.DataContext;
using ProjetoTesteDev.Dtos;
using ProjetoTesteDev.Model;
using System.Collections.Generic;

namespace ProjetoTesteDev.Repository.Mesa
{
    public class MesaRepository : IMesaRepository
    {
        private readonly SqlServerDbContext _context;
        private IMapper _mapper;

        public  MesaRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }     
        public async Task<ServiceResponse<MesaDetalhesDto>> BuscarDetalhesPorId(int id)
        {
            var response = new ServiceResponse<MesaDetalhesDto>();
            try
            {
                var detalhesMesa = await _context.Mesas
                .Include(m => m.ItensConsumidos)
                .FirstOrDefaultAsync(m => m.Id == id);

                if (detalhesMesa == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = $"Mesa com ID {id} não encontrada.";
                }
                else {
                    response.Dados = _mapper.Map<MesaDetalhesDto>(detalhesMesa);
                    response.Mensagem = "Detalhes da mesa encontrados com sucesso.";
                }            
            }
            catch (Exception ex)
            {

                response.Sucesso = false;
                response.Mensagem = $"Erro ao buscar detalhes da mesa: {ex.Message}";
            }

            return response;


        }

        public async Task<ServiceResponse<List<MesaResumoDto>>> ListarMesasAbertas()
        {
            var response = new ServiceResponse<List<MesaResumoDto>>();

            try
            {
                var mesas = await _context.Mesas
                .Where(m => m.Aberta)
                .ToListAsync();

                if (mesas == null)
                {
                    response.Sucesso = false;
                    response.Mensagem = $"Nenhuma mesa em aberto.";
                }
                else
                {
                    response.Dados = _mapper.Map<List<MesaResumoDto>>(mesas);
                    response.Mensagem = "Messas em aberto.";
                }
            }
            catch (Exception ex)
            {

                response.Sucesso = false;
                response.Mensagem = $"Erro ao buscar messas em aberto: {ex.Message}";
            }
       
            return response;
        }
    }
}
