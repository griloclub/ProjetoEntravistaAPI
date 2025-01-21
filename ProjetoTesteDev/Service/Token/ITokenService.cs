using ProjetoTesteDev.Dtos;

namespace ProjetoTesteDev.Service.Token
{
    public interface ITokenService
    {
        string GerarTokenJWT(LoginResponseDto usuarioDto);
    }
}
