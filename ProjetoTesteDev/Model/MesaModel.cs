namespace ProjetoTesteDev.Model
{
    public class MesaModel
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public bool Aberta { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime? HorarioFechamento { get; set; }
        public List<ItemConsumidoModel> ItensConsumidos { get; set; } = new();
    }
}
