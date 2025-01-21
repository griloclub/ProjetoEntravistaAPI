namespace ProjetoTesteDev.Dtos
{
    public class ItemConsumidoDto
    {      
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public int MesaId { get; set; }       
    }
}
