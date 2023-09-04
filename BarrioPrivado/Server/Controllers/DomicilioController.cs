using Microsoft.AspNetCore.Mvc;
using BarrioPrivado.BD.Data;
using BarrioPrivado.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BarrioPrivado.Server.Controllers
{
    [ApiController]
    [Route("api/Domicilios")]

    public class DomicilioController : ControllerBase
    {
        private readonly Context context;

        public DomicilioController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Domicilio>>> Get()
        {
            return await context.Domicilios.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Domicilio>> Get(int id)
        {
            var existe = await context.Domicilios.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El Domicilio {id} no existe");
            }
            return await context.Domicilios.FirstOrDefaultAsync(x => x.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Domicilio domicilio)
        {
            //return BadRequest("ERROR DE PRUEBA");
            context.Add(domicilio);
            await context.SaveChangesAsync();
            return domicilio.id;
        }

        [HttpPut("{id:int}")] // api/roles/2
        public async Task<ActionResult> Put(Domicilio domicilio, int id)
        {
            if (id != domicilio.id)
            {
                return BadRequest("El id del domicilio no corresponde");
            }

            var existe = await context.Domicilios.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El domicilio de id={id} no existe");
            }

            context.Update(domicilio);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Domicilios.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El domicilio de id={id} no existe");
            }

            context.Remove(new Domicilio() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
