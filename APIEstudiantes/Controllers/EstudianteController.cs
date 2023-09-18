using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using APIEstudiantes.Models;

namespace APIEstudiantes.Controllers;

[ApiController]
[Route("api/estudiantes")]
[Authorize]

public class EstudianteController : ControllerBase
{
    private static List<Estudiantes> estudiantes = new List<Estudiantes>()
    {
        new Estudiantes{
            Id = 1,
            Nombre = "Alejo",
            Date = new DateOnly(2000 , 1 , 1),
            Apellido = "Dominguez",
            Correo = "test@test.com"
        }
    };

    private readonly ILogger<EstudianteController> _logger;

    public EstudianteController(ILogger<EstudianteController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Estudiantes>> GetEstudiantes()
    {
        return estudiantes;
    }

    [HttpPost]
    public ActionResult<Estudiantes> PostEstudiante(Estudiantes estudiante)
    {
        estudiante.Id = estudiantes.Count > 0 ? estudiantes.Max(e => e.Id) + 1 : 1; 
        estudiantes.Add(estudiante);
        return Ok();
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Estudiantes>> GetEstudiantes(int id)
    {
        var estudiante = estudiantes.FirstOrDefault(i => i.Id == id);
        if(estudiante == null){
            return NotFound();
        }
        return Ok(estudiante);
    }
    
    [HttpDelete("{id}")]
    public ActionResult<IEnumerable<Estudiantes>> DeleteEstudiante(int id)
    {
        var estudiante = estudiantes.FirstOrDefault(i => i.Id == id);
        if(estudiante == null){
            return NotFound();
        }
        estudiantes.Remove(estudiante);
        return Ok(estudiante);
    }

    [HttpPut("{id}")]
    public ActionResult<IEnumerable<Estudiantes>> PutEstudiante(int id)
    {
        var estudiante = estudiantes.FirstOrDefault(i => i.Id == id);
        if(estudiante == null){
            return NotFound();
        }
        return Ok(estudiante);
    }
}
