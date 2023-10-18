﻿namespace TaskSystems.Models
{
    public class Tarefas
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public TaskStatus Status { get; set; }

        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}