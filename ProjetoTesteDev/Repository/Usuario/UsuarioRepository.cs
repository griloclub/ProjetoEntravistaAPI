using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoTesteDev.DataContext;
using ProjetoTesteDev.Dtos;

namespace ProjetoTesteDev.Repository.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {   
        private readonly SqlServerDbContext _context;
        private IMapper _mapper;

        public UsuarioRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LoginResponseDto?> ValidarCredenciais(LoginRequestDto loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Senha, usuario.SenhaHash))
            {
                return null;
            }
            
            return new LoginResponseDto
            {
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }
    }
}
