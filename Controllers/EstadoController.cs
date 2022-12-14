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
    public class EstadoController : ControllerBase
    {
        private readonly InspeccionDbContext _context;

        public EstadoController(InspeccionDbContext context)
        {
            _context = context;
        }

        // GET: api/<InspeccionController>
        [HttpGet]
        public async Task<IEnumerable<Estado>> GetAll()
        {
            return await _context.Estados.ToListAsync();
        }

        // GET api/<InspeccionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetbyId(int id)
        {
            var inspeccion = await _context.Estados.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            return inspeccion;
        }


        // POST api/<InspeccionController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Estado inspeccion)
        {
            _context.Estados.Add(inspeccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAll", new { id = inspeccion.Id }, inspeccion);
        }

        // PUT api/<InspeccionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Estado inspeccion)
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
        // DELETE api/<InspeccionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Estado>> Delete(int id)
        {
            var inspeccion = await _context.Estados.FindAsync(id);
            if (inspeccion == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(inspeccion);
            await _context.SaveChangesAsync();

            return inspeccion;
        }
        private bool inspeccionExists(int id)
        {
            return _context.Estados.Any(e => e.Id == id);
        }



    }
}
