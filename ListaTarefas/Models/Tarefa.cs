namespace ListaTarefas.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public Boolean Concluida { get; set; } = false;
        public DateTime DtInicio { get; set; } = DateTime.Now;
        public DateTime? DtConclusao { get; set; }

    }    
}
