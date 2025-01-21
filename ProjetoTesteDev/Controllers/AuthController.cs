using Microsoft.AspNetCore.Mvc;
using ProjetoTesteDev.Dtos;
using ProjetoTesteDev.Repository.Usuario;
using ProjetoTesteDev.Service.Token;

namespace ProjetoTesteDev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public AuthController(IUsuarioRepository usuarioRepository, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginDto)
        {
            
            try
            {
                var usuario = await _usuarioRepository.ValidarCredenciais(loginDto);

                if (usuario == null)
                {
                    return Unauthorized("Usuário ou senha inválidos.");
                }

                var token = _tokenService.GerarTokenJWT(usuario);

                return Ok(new LoginResponseDto
                {
                    Token = token,
                    Nome = usuario.Nome,
                    Email = usuario.Email
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao processar a solicitação: {ex.Message}");
            }
        }

    }
}
