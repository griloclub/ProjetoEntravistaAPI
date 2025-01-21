namespace ProjetoTesteDev.Dtos
{
    public class MesaDetalhesDto
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public bool Aberta { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime? HorarioFechamento { get; set; }
        public List<ItemConsumidoDto> ItensConsumidos { get; set; } = new();
        public decimal ValorTotal => ItensConsumidos.Sum(item => item.Valor);
    }
}
