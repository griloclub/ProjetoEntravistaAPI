using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoTesteDev.Controllers;
using ProjetoTesteDev.Dtos;
using ProjetoTesteDev.Repository.Usuario;
using ProjetoTesteDev.Service.Token;


namespace ProjetoTesteDev.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<IUsuarioRepository> _mockUsuarioRepository;
        private readonly Mock<ITokenService> _mockTokenService;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _mockUsuarioRepository = new Mock<IUsuarioRepository>();
            _mockTokenService = new Mock<ITokenService>();
            _controller = new AuthController(_mockUsuarioRepository.Object, _mockTokenService.Object);
        }

        [Fact]
        public async Task Login_DeveRetornarOk_QuandoCredenciaisSaoValidas()
        {

            var loginRequest = new LoginRequestDto
            {
                Email = "tiago@teste.com",
                Senha = "Qu@Dr@d0"
            };

            var usuarioResponse = new LoginResponseDto
            {
                Nome = "Usuário Teste",
                Email = "usuario@teste.com",
                Token = "TokenValido"
            };

            _mockUsuarioRepository
                .Setup(repo => repo.ValidarCredenciais(loginRequest))
                .ReturnsAsync(usuarioResponse);

            _mockTokenService
                .Setup(service => service.GerarTokenJWT(usuarioResponse))
                .Returns("TokenValido");

            var actionResult = await _controller.Login(loginRequest);

            Assert.NotNull(actionResult);

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var response = Assert.IsType<LoginResponseDto>(okResult.Value);

            Assert.NotNull(response);
            Assert.Equal("TokenValido", response.Token);
            Assert.Equal("Usuário Teste", response.Nome);
            Assert.Equal("usuario@teste.com", response.Email);
        }


        [Fact]
        public async Task Login_DeveRetornarUnauthorized_QuandoCredenciaisSaoInvalidas()
        {
            var loginRequest = new LoginRequestDto
            {
                Email = "tiago@teste.com",
                Senha = "Qu@Dr@d0"
            };

            _mockUsuarioRepository
                .Setup(repo => repo.ValidarCredenciais(loginRequest))
                .ReturnsAsync((LoginResponseDto)null);

            var actionResult = await _controller.Login(loginRequest);

            Assert.NotNull(actionResult);

            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(actionResult.Result);
            Assert.Equal("Usuário ou senha inválidos.", unauthorizedResult.Value);
        }

    }
}
