
using examenweb2parcial.Data;
using examenweb2parcial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace examenweb2parcial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TareasController(AppDbContext context)
        {
            _context = context;
        }

        // 1 - Listar tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            return await _context.Tareas.Include(t => t.Miembro).Include(t => t.Prioridad).ToListAsync();
        }

        // 2 - Crear tarea
        [HttpPost]
        public async Task<ActionResult<Tarea>> CrearTarea(Tarea tarea)
        {
            tarea.FechaCreacion = DateTime.Now;
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTareaPorId), new { id = tarea.Id }, tarea);
        }

        // 3 - Editar tarea
        [HttpPut("{id}")]
        public async Task<ActionResult> EditarTarea(int id, Tarea tarea)
        {
            if (id != tarea.Id) return BadRequest();
            _context.Entry(tarea).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 4 - Eliminar tarea
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null) return NotFound();
            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> GetTareaPorId(int id)
        {
            var tarea = await _context.Tareas.Include(t => t.Miembro).Include(t => t.Prioridad).FirstOrDefaultAsync(t => t.Id == id);
            if (tarea == null) return NotFound();
            return tarea;
        }

        // 5 Ordenar por prioridad
        [HttpGet("ordenar-por-prioridad")]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareasPorPrioridad()
        {
            return await _context.Tareas.OrderBy(t => t.Prioridad.Nombre).ToListAsync();
        }

        // 6 - Buscar por titulo
        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<Tarea>>> BuscarPorTitulo([FromQuery] string titulo)
        {
            return await _context.Tareas.Where(t => t.Titulo.Contains(titulo)).ToListAsync();
        }

        // 7 - Listar tareas asignadas por miembro
        [HttpGet("por-miembro/{miembroId}")]
        public async Task<ActionResult<IEnumerable<Tarea>>> ListarPorMiembro(int miembroId)
        {
            return await _context.Tareas.Where(t => t.MiembroId == miembroId).ToListAsync();
        }
    }
}