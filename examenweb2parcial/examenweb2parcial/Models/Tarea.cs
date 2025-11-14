using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace examenweb2parcial.Models
{
    public enum EstadoTarea
    {
        Todo,
        InProgress,
        Done
    }

    public class Tarea
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public EstadoTarea Estado { get; set; }
        [ForeignKey("Miembro")]
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; }
        public Prioridad Prioridad { get; set; }
    }
}