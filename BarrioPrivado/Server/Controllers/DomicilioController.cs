using Microsoft.AspNetCore.Mvc;
using BarrioPrivado.BD.Data;
using BarrioPrivado.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using BarrioPrivado.Shared.DTO;
using System.Runtime.Intrinsics.Arm;

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
            var lista = await context.Domicilios.ToListAsync();
            if (lista == null || lista.Count == 0)
            {
                return BadRequest("No hay domicilios cargados.");
            }

            return lista;
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

        //[HttpPost]
        //public async Task<ActionResult> Post(DomicilioDTO domicilioDTO)
        //{
        //    try
        //    {
        //        Domicilio entidad = new Domicilio();
        //        entidad.lote = domicilioDTO.lote;
        //        entidad.manzana = domicilioDTO.manzana;

        //        await context.AddAsync(entidad);
        //        await context.SaveChangesAsync();
        //        return Ok("Se cargo correctamente el Domicilio.");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult<int>> Post(DomicilioDTO domicilioDTO)
        {

            Domicilio pepe = new Domicilio();

            pepe.lote = domicilioDTO.lote;
            pepe.manzana = domicilioDTO.manzana;
            string cod = domicilioDTO.lote + domicilioDTO.manzana;
            pepe.codigoDomicilio = cod;

            var existe = await context.Domicilios.AnyAsync(x => x.codigoDomicilio == cod);
            if (existe)
            {
                return BadRequest($"El Domicilio {cod} ya existe");
            }

            //Profesion pepe = new() 
            //{ 
            //    CodProfesion = profesion.CodProfesion,
            //    Titulo = profesion.Titulo
            //};

            await context.AddAsync(pepe);
            await context.SaveChangesAsync();
            return Ok("Se cargo correctamente el Domicilio.");
        }

        //[HttpPost]
        //public async Task<ActionResult<int>> Post(Domicilio domicilio)
        //{
        //    //return BadRequest("ERROR DE PRUEBA");
        //    context.Add(domicilio);
        //    await context.SaveChangesAsync();
        //    return domicilio.id;
        //}

        //[HttpPut("{id:int}")] 
        //public async Task<ActionResult> Put(Domicilio domicilio, int id)
        //{
        //    if (id != domicilio.id)
        //    {
        //        return BadRequest("El id del domicilio no corresponde");
        //    }

        //    var existe = await context.Domicilios.AnyAsync(x => x.id == id);
        //    if (!existe)
        //    {
        //        return NotFound($"El domicilio de id={id} no existe");
        //    }

        //    context.Update(domicilio);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}
        [HttpPut("{id:int}")] // api/domicilios/2
        public async Task<ActionResult> Put(Domicilio domicilio, int id)
        {
            if (id != domicilio.id)
            {
                return BadRequest("El id del domicilio no corresponde.");
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
