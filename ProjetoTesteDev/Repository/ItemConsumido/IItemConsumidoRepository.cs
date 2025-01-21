using ProjetoTesteDev.Dtos;

namespace ProjetoTesteDev.Repository.ItemConsumido
{
    public interface IItemConsumidoRepository
    {
        /// <summary>
        /// Lista todos os itens consumidos de uma mesa.
        /// </summary>
        Task<List<ItemConsumidoDto>> ListarItensPorMesaId(int mesaId);

        /// <summary>
        /// Adiciona um novo item consumido.
        /// </summary>
        Task AdicionarItem(ItemConsumidoDto itemDto);

        /// <summary>
        /// Remove um item consumido.
        /// </summary>
        Task RemoverItem(int itemId);
    }
}
