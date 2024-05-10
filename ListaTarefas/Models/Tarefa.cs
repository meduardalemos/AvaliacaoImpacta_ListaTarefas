using System.ComponentModel.DataAnnotations;

namespace ListaTarefas.Models;

public class Tarefa
{
    public int TarefaId { get; set; }
    public string Nome { get; set; }
    public Boolean Concluida { get; set; } = false;
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DtInicio { get; set; } = DateTime.Now;
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? DtConclusao { get; set; }

}    
