using GastosDelHogar.Shared.DTOs;
using GastosDelHogar.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosDelHogar.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            var personas = await context.Personas
                .Include(x => x.Gastos)
                .ToListAsync();

            foreach (var persona in personas)
            {
                persona.Gastos = persona.Gastos.Where(x => x.Fecha.Value.Month == DateTime.Today.Month).ToList();
                persona.Gastos = persona.Gastos.OrderBy(x => x.Fecha.Value).ToList();
            }

            return personas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            var persona = await context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return persona.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Persona persona)
        {
            context.Attach(persona).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Personas.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Persona { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
