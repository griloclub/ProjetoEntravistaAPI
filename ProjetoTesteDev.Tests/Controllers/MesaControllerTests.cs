using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProjetoTesteDev.Controllers;
using ProjetoTesteDev.Dtos;
using ProjetoTesteDev.Repository.Mesa;
using ProjetoTesteDev.Model;

namespace ProjetoTesteDev.Tests.Controllers
{
    public class MesaControllerTests
    {
        private readonly Mock<IMesaRepository> _mockMesaRepository;
        private readonly MesaController _controller;

        public MesaControllerTests()
        {
            _mockMesaRepository = new Mock<IMesaRepository>();
            _controller = new MesaController(_mockMesaRepository.Object);
        }

        [Fact]
        public async Task ListarMesasAbertas_DeveRetornarOk_ComListaDeMesas()
        {

            var mesasMock = new ServiceResponse<List<MesaResumoDto>>
            {
                Sucesso = true,
                Dados = new List<MesaResumoDto>
                {
                    new MesaResumoDto { Id = 1, Numero = "M001", Aberta = true, HorarioAbertura = System.DateTime.Now },
                    new MesaResumoDto { Id = 2, Numero = "M002", Aberta = true, HorarioAbertura = System.DateTime.Now }
                }
            };

            _mockMesaRepository
                .Setup(repo => repo.ListarMesasAbertas())
                .ReturnsAsync(mesasMock);

            var result = await _controller.ListarMesasAbertas();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ServiceResponse<List<MesaResumoDto>>>(okResult.Value);

            Assert.True(response.Sucesso);
            Assert.Equal(2, response.Dados.Count);
        }

        [Fact]
        public async Task BuscarDetalhesMesa_DeveRetornarOk_ComDetalhesDaMesa()
        {
            var mesaDetalhesMock = new ServiceResponse<MesaDetalhesDto>
            {
                Sucesso = true,
                Dados = new MesaDetalhesDto
                {
                    Id = 1,
                    Numero = "M001",
                    Aberta = true,
                    HorarioAbertura = System.DateTime.Now,
                    ItensConsumidos = new List<ItemConsumidoDto>
                    {
                        new ItemConsumidoDto { Id = 1, Nome = "Cerveja", Valor = 10.5m },
                        new ItemConsumidoDto { Id = 2, Nome = "Petisco", Valor = 25.0m }
                    }
                }
            };

            _mockMesaRepository
                .Setup(repo => repo.BuscarDetalhesPorId(1))
                .ReturnsAsync(mesaDetalhesMock);


            var result = await _controller.BuscarDetalhesMesa(1);


            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ServiceResponse<MesaDetalhesDto>>(okResult.Value);

            Assert.True(response.Sucesso);
            Assert.NotNull(response.Dados);
            Assert.Equal(1, response.Dados.Id);
            Assert.Equal("M001", response.Dados.Numero);
        }

        [Fact]
        public async Task BuscarDetalhesMesa_DeveRetornarNotFound_QuandoMesaNaoExiste()
        {
            _mockMesaRepository
                .Setup(repo => repo.BuscarDetalhesPorId(99))
                .ReturnsAsync(new ServiceResponse<MesaDetalhesDto>
                {
                    Sucesso = false,
                    Mensagem = "Mesa não encontrada.",
                    Dados = null
                });

            var result = await _controller.BuscarDetalhesMesa(99);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Mesa com ID 99 não encontrada.", notFoundResult.Value);
        }

    }
}
