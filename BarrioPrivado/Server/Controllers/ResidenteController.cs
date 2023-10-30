using Microsoft.AspNetCore.Mvc;
using BarrioPrivado.BD.Data;
using BarrioPrivado.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using BarrioPrivado.Shared.DTO;

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
            var lista = await context.Residentes.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay residentes cargados.");
            }

            return lista;
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
        public async Task<ActionResult<int>> Post(ResidenteDTO residenteDTO)
        {

            Residente pepe = new Residente();

            pepe.nombre = residenteDTO.nombre;
            pepe.apellido = residenteDTO.apellido;
            pepe.DNI = residenteDTO.DNI;
            pepe.codigoDomicilio = residenteDTO.codigoDomicilio;

            //var existe = await context.Domicilios.AnyAsync(x => x.codigoDomicilio == );
            //if (existe)
            //{
            //    return BadRequest($"El Domicilio {cod} ya existe");
            //}

            //Profesion pepe = new() 
            //{ 
            //    CodProfesion = profesion.CodProfesion,
            //    Titulo = profesion.Titulo
            //};

            await context.AddAsync(pepe);
            await context.SaveChangesAsync();
            return Ok("Se cargo correctamente el Residente.");
        }

        [HttpPut("{id:int}")] // api/residentes/2
        public async Task<ActionResult> Put(Residente residente, int id)
        {
            if (id != residente.id)
            {
                return BadRequest("El id del residente no corresponde.");
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
