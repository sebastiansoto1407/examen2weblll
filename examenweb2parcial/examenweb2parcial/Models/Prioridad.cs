namespace examenweb2parcial.Models
{
    public enum NivelPrioridad
    {
        Baja,
        Media,
        Alta
    }

    public class Prioridad
    {
        public int Id { get; set; }
        public NivelPrioridad Nombre { get; set; }
    }
}