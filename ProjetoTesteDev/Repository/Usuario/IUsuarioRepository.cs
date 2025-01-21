using ProjetoTesteDev.Dtos;

namespace ProjetoTesteDev.Repository.Usuario
{
    public interface IUsuarioRepository
    {
        Task<LoginResponseDto?> ValidarCredenciais(LoginRequestDto login);       
    }
}
