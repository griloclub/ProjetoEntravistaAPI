namespace ProjetoTesteDev.Dtos
{
    public class MesaResumoDto
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public bool Aberta { get; set; }
        public DateTime HorarioAbertura { get; set; }
        public DateTime? HorarioFechamento { get; set; }
    }
}
