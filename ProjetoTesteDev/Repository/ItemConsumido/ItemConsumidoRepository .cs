using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoTesteDev.DataContext;
using ProjetoTesteDev.Dtos;
using ProjetoTesteDev.Model;

namespace ProjetoTesteDev.Repository.ItemConsumido
{
    public class ItemConsumidoRepository : IItemConsumidoRepository
    {
        private readonly SqlServerDbContext _context;
        private IMapper _mapper;

        public ItemConsumidoRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AdicionarItem(ItemConsumidoDto itemDto)
        {
            var item = _mapper.Map<ItemConsumidoModel>(itemDto);
            await _context.ItensConsumidos.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ItemConsumidoDto>> ListarItensPorMesaId(int mesaId)
        {
            var itens = await _context.ItensConsumidos
            .Where(i => i.MesaId == mesaId)
            .ToListAsync();

            return _mapper.Map<List<ItemConsumidoDto>>(itens);
        }

        public async Task RemoverItem(int itemId)
        {
            var item = await _context.ItensConsumidos.FindAsync(itemId);
            if (item != null)
            {
                _context.ItensConsumidos.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
