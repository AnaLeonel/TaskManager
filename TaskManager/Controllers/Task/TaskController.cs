using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models.Task;

namespace TaskManager.Controllers.Task
{
    public class TaskController : Controller
    {
        // lista estática pra simular um db
        private static List<TaskViewModel> tickets = new List<TaskViewModel>
        {
            new TaskViewModel { Id = 1, Title = "Erro no Sistema", Description = "Erro ao acessar o módulo de vendas.", Priority = "Alta", Status = "Aberto", DateOpened = System.DateTime.Now }
        };

        // listar tickets
        public ActionResult Index()
        {
            return View(tickets);
        }

        // pagina de detalhes
        public ActionResult Details(int id)
        {
            var ticket = tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null) return HttpNotFound();
            return View(ticket);
        }

        // criar novo ticket (GET)
        public ActionResult Create()
        {
            return View();
        }

        // criar novo ticket (POST)
        [HttpPost]
        public ActionResult Create(TaskViewModel ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Id = tickets.Count > 0 ? tickets.Max(t => t.Id) + 1 : 1;
                ticket.DateOpened = System.DateTime.Now;
                tickets.Add(ticket);
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // editar ticket (GET)
        public ActionResult Edit(int id)
        {
            var ticket = tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null) return HttpNotFound();
            return View(ticket);
        }

        // editar ticket (POST)
        [HttpPost]
        public ActionResult Edit(TaskViewModel ticket)
        {
            var existingTicket = tickets.FirstOrDefault(t => t.Id == ticket.Id);
            if (existingTicket == null) return HttpNotFound();

            if (ModelState.IsValid)
            {
                existingTicket.Title = ticket.Title;
                existingTicket.Description = ticket.Description;
                existingTicket.Priority = ticket.Priority;
                existingTicket.Status = ticket.Status;
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // excluir ticket (GET)
        public ActionResult Delete(int id)
        {
            var ticket = tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null) return HttpNotFound();
            return View(ticket);
        }

        // excluir ticket (POST)
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var ticket = tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null) return HttpNotFound();
            tickets.Remove(ticket);
            return RedirectToAction("Index");
        }
    }
}