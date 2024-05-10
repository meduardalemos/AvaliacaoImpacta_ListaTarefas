using ListaTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private List<Tarefa> _tarefas = new List<Tarefa>
        {
            new Tarefa("Responder questionário"),
            new Tarefa("Entregar projeto de lista de tarefas"),
            new Tarefa("1:1 com professor")
        };

        public IActionResult Index()
        {
            return View(_tarefas);
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
