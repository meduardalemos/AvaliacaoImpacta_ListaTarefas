namespace ListaTarefas.Models
{
    public class Tarefa
    {
        private static int _idCounter = 1;
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public Boolean Concluida { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime? DtConclusao { get; set; }

        public Tarefa(string nome)
        {
            Nome = nome;
            TarefaId = _idCounter++;
            DtInicio = DateTime.Now;
            Concluida = false;
            DtConclusao = null;
        }

        public void ConcluirTarefa()
        {
            if (!Concluida)
            {
                Concluida = true;
                DtConclusao = DateTime.Now;
            }
        }
    }    
}
