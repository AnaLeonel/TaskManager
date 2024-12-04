using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models.Task
{
    public class TaskViewModel
    {
        public int Id { get; set; } // identificador único
        public string Title { get; set; } // titulo do ticket
        public string Description { get; set; } // descrição do problema relacionado
        public string Priority { get; set; } // prioridade (baixa, média, alta)
        public string Status { get; set; } // status (aberto, em Andamento, fechado)
        public DateTime DateOpened { get; set; } // data de abertura do ticket
    }
}