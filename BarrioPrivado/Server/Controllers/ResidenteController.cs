using Microsoft.AspNetCore.Mvc;
using BarrioPrivado.BD.Data;
using BarrioPrivado.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BarrioPrivado.Server.Controllers
{
    [ApiController]
    [Route("api/Residentes")]

    public class ResidenteController : ControllerBase
    {
        private readonly Context context;

        public ResidenteController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Residente>>> Get()
        {
            return await context.Residentes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Residente>> Get(int id)
        {
            var existe = await context.Residentes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El Residente {id} no existe");
            }
            return await context.Residentes.FirstOrDefaultAsync(x => x.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Residente residente)
        {
            //return BadRequest("ERROR DE PRUEBA");
            context.Add(residente);
            await context.SaveChangesAsync();
            return residente.id;
        }

        [HttpPut("{id:int}")] // api/roles/2
        public async Task<ActionResult> Put(Residente residente, int id)
        {
            if (id != residente.id)
            {
                return BadRequest("El id del residente no corresponde");
            }

            var existe = await context.Residentes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El residente de id={id} no existe");
            }

            context.Update(residente);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Residentes.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El residente de id={id} no existe");
            }

            context.Remove(new Residente() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
