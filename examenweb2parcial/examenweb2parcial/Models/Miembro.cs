namespace examenweb2parcial.Models
{
    public enum Rol
    {
        Developer,
        Tester,
        Lider
    }

    public class Miembro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Rol Rol { get; set; }
    }
}