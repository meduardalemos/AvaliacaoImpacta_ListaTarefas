using ListaTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefas.Controllers;

public class TarefasController : Controller
{
    private static List<Tarefa> _tarefas = new List<Tarefa>
    {
        new Tarefa {TarefaId = 1, Nome = "Estudar projetos MVC", DtInicio = DateTime.Parse("08/05/2024"),Concluida = true, DtConclusao = DateTime.Parse("09/05/2024")},
        new Tarefa {TarefaId = 2, Nome = "Estudar Azure", DtInicio = DateTime.Parse("09/05/2024"),  Concluida = true, DtConclusao = DateTime.Parse("10/05/2024")},
        new Tarefa {TarefaId = 3, Nome = "Responder questionário"},
        new Tarefa {TarefaId = 4, Nome = "Entregar projeto de lista de tarefas"},
        new Tarefa {TarefaId = 5, Nome = "1:1 com professor para feedback"}
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

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

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

    public IActionResult Edit(int id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
        if (tarefa == null)
        {
            return NotFound();
        }

        return View(tarefa);
    }

    [HttpPost]
    public IActionResult Edit(Tarefa tarefa)
    {
        if (ModelState.IsValid)
        {
            var existingTarefa = _tarefas.FirstOrDefault(t => t.TarefaId == tarefa.TarefaId);
            if (existingTarefa != null)
            {
                existingTarefa.Nome = tarefa.Nome;
            }
            return RedirectToAction("Index");
        }
        return View(tarefa);
    }

    public IActionResult Concluidas()
    {
        var _tarefasConcluidas = _tarefas.Where(t => t.Concluida == true).ToList();

        return View(_tarefasConcluidas);
    }

    public IActionResult PorFazer()
    {
        var _tarefasPorFazer = _tarefas.Where(t => t.Concluida == false).ToList();

        return View(_tarefasPorFazer);
    }

}
