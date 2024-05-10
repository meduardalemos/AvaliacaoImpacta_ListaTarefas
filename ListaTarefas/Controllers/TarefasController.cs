using ListaTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefas.Controllers
{
    public class TarefasController : Controller
    {
        private static List<Tarefa> _tarefas = new List<Tarefa>
        {
            new Tarefa {TarefaId = 1, Nome = "Responder questionário"},
            new Tarefa {TarefaId = 2, Nome = "Entregar projeto de lista de tarefas"},
            new Tarefa {TarefaId = 3, Nome = "1:1 com professor para feedback"},
        };

        public IActionResult Index()
        {
            return View(_tarefas);
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa == null)
                return NotFound();
            _tarefas.Remove(tarefa);
            return RedirectToAction("Index");
        }

        // Chama o form de cadastro
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Recebe os dados do form
        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefa.TarefaId = _tarefas.Count() > 0 ? _tarefas.Max(t => t.TarefaId + 1) : 1;
                _tarefas.Add(tarefa);
            }
            return RedirectToAction("Index");
        }


    }
}
