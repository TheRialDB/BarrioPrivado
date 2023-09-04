using Microsoft.AspNetCore.Mvc;
using BarrioPrivado.BD.Data;
using BarrioPrivado.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BarrioPrivado.Server.Controllers
{
    [ApiController]
    [Route("api/Visitantes")]

    public class VisitanteController : ControllerBase
    {
        private readonly Context context;

        public VisitanteController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Visitante>>> Get()
        {
            return await context.Visitantes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Visitante>> Get(int id)
        {
            var existe = await context.Visitantes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El Visitante {id} no existe");
            }
            return await context.Visitantes.FirstOrDefaultAsync(x => x.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Visitante visitante)
        {
            //return BadRequest("ERROR DE PRUEBA");
            context.Add(visitante);
            await context.SaveChangesAsync();
            return visitante.id;
        }

        [HttpPut("{id:int}")] // api/roles/2
        public async Task<ActionResult> Put(Visitante visitante, int id)
        {
            if (id != visitante.id)
            {
                return BadRequest("El id del visitante no corresponde");
            }

            var existe = await context.Visitantes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El visitante de id={id} no existe");
            }

            context.Update(visitante);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Visitantes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El visitante de id={id} no existe");
            }

            context.Remove(new Visitante() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
