namespace APIEstudiantes.Models;

public class Estudiantes
{
    public DateOnly? Date { get; set; }

    public int? Id { get; set; }

    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Correo {get; set;}
}
