using AutoMapper;
using ProjetoTesteDev.Dtos;
using ProjetoTesteDev.Model;

namespace ProjetoTesteDev.Configuration
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // Usuário
            CreateMap<UsuarioModel, LoginResponseDto>().ReverseMap();

            // Mesa
            CreateMap<MesaModel, MesaResumoDto>().ReverseMap();
            CreateMap<MesaModel, MesaDetalhesDto>().ReverseMap();

            // Item Consumido
            CreateMap<ItemConsumidoModel, ItemConsumidoDto>().ReverseMap();
          
        }
    }
}
