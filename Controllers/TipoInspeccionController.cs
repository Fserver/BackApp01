using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFrontBack.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoFrontBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoInspeccionController : ControllerBase
    {
        private readonly InspeccionDbContext _context;

        public TipoInspeccionController(InspeccionDbContext context)
        {
            _context = context;
        }

        // GET: api/<TipoInspeccionController>
        [HttpGet]
        public async Task<IEnumerable<TipoInspeccion>> GetAll()
        {
            return (IEnumerable<TipoInspeccion>)await _context.TipoInspeccions.ToListAsync();
        }

        // GET api/<TipoInspeccionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoInspeccion>> GetbyId(int id)
        {
            var inspeccion = await _context.TipoInspeccions.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            return inspeccion;
        }


        // POST api/<TipoInspeccionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoInspeccion inspeccion)
        {
            _context.TipoInspeccions.Add(inspeccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAll", new { id = inspeccion.Id }, inspeccion);
        }

        // PUT api/<TipoInspeccionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoInspeccion inspeccion)
        {
            if (id != inspeccion.Id)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(inspeccion).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!inspeccionExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok();
            }
        }
        // DELETE api/<TipoInspeccionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoInspeccion>> Delete(int id)
        {
            var inspeccion = await _context.TipoInspeccions.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            _context.TipoInspeccions.Remove(inspeccion);
            await _context.SaveChangesAsync();

            return inspeccion;
        }
        private bool inspeccionExists(int id)
        {
            return _context.TipoInspeccions.Any(e => e.Id == id);
        }
    }
}
