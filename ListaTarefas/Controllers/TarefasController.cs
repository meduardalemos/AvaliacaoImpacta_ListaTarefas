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

        public IActionResult Create()
        {

            return RedirectToAction("Index");
        }

        public IActionResult Concluidas() 
        {
            return View();
        }

        public IActionResult PorFazer()
        {
            return View();
        }

        public IActionResult Concluir()
        {

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
                return NotFound();
            _tarefas.Remove(tarefa);
            return RedirectToAction("Index");
        }
    }
}
