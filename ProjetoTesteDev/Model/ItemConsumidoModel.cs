using Microsoft.EntityFrameworkCore;

namespace ProjetoTesteDev.Model
{
    public class ItemConsumidoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        [Precision(18, 2)]
        public decimal Valor { get; set; }
        public int MesaId { get; set; }
        public MesaModel Mesa { get; set; } = null!;
    }
}
