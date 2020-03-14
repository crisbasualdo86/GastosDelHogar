using GastosDelHogar.Server.Helpers;
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
    public class GastosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public GastosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gasto>>> Get([FromQuery] Paginacion paginacion)
        {
            var queryable = context.Gastos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion)
                .Include(x => x.Persona)
                .Include(x => x.Tipo)
                .OrderByDescending(x => x.Fecha)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gasto>> Get(int id)
        {
            var gasto = await context.Gastos.FirstOrDefaultAsync(x => x.Id == id);

            if (gasto == null)
            {
                return NotFound();
            }

            return gasto;
        }

        //[HttpGet("filtrar")]
        //public async Task<ActionResult<List<Gasto>>> Get([FromQuery] ParametrosBusquedaGastos parametrosBusqueda)
        //{
        //    var gastosQueryable = context.Gastos.AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Nombre))
        //    {
        //        gastosQueryable = gastosQueryable
        //            .Where(x => x.Nombre.ToLower().Contains(parametrosBusqueda.Nombre.ToLower()));
        //    }

        //    if (parametrosBusqueda.Mes != 0)
        //    {
        //        gastosQueryable = gastosQueryable.Where(x => x.Fecha.Value.Month == parametrosBusqueda.Mes);
        //    }

        //    if (parametrosBusqueda.PersonaId != 0)
        //    {
        //        gastosQueryable = gastosQueryable.Where(x => x.PersonaId == parametrosBusqueda.PersonaId);
        //    }

        //    if (parametrosBusqueda.TipoId != 0)
        //    {
        //        gastosQueryable = gastosQueryable.Where(x => x.TipoId == parametrosBusqueda.TipoId);
        //    }

        //    if (parametrosBusqueda.Pagados)
        //    {
        //        gastosQueryable = gastosQueryable.Where(x => x.Pagado);
        //    }

        //    gastosQueryable = gastosQueryable.OrderByDescending(x => x.Fecha);

        //    await HttpContext.InsertarParametrosPaginacionEnRespuesta(gastosQueryable, parametrosBusqueda.CantidadRegistros);

        //    var gastos = await gastosQueryable.Paginar(parametrosBusqueda.Paginacion)
        //        .Include(x => x.Persona)
        //        .Include(x => x.Tipo)
        //        .ToListAsync();

        //    return gastos;
        //}

        [HttpGet("filtrar")]
        public async Task<ActionResult<GastosDTO>> Get([FromQuery] ParametrosBusquedaGastos parametrosBusqueda)
        {
            var gastosQueryable = context.Gastos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(parametrosBusqueda.Nombre))
            {
                gastosQueryable = gastosQueryable
                    .Where(x => x.Nombre.ToLower().Contains(parametrosBusqueda.Nombre.ToLower()));
            }

            if (parametrosBusqueda.Mes != 0)
            {
                gastosQueryable = gastosQueryable.Where(x => x.Fecha.Value.Month == parametrosBusqueda.Mes);
            }

            if (parametrosBusqueda.PersonaId != 0)
            {
                gastosQueryable = gastosQueryable.Where(x => x.PersonaId == parametrosBusqueda.PersonaId);
            }

            if (parametrosBusqueda.TipoId != 0)
            {
                gastosQueryable = gastosQueryable.Where(x => x.TipoId == parametrosBusqueda.TipoId);
            }

            if (parametrosBusqueda.Pagados)
            {
                gastosQueryable = gastosQueryable.Where(x => x.Pagado);
            }

            gastosQueryable = gastosQueryable.OrderByDescending(x => x.Fecha);

            await HttpContext.InsertarParametrosPaginacionEnRespuesta(gastosQueryable, parametrosBusqueda.CantidadRegistros);

            var gastos = new GastosDTO
            {
                totalGastos = gastosQueryable.Sum(x => x.Monto.Value),

                Gastos = await gastosQueryable.Paginar(parametrosBusqueda.Paginacion)
                    .Include(x => x.Persona)
                    .Include(x => x.Tipo)
                    .ToListAsync()
            };

            return gastos;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Gasto gasto)
        {
            context.Add(gasto);
            await context.SaveChangesAsync();
            return gasto.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Gasto gasto)
        {
            context.Attach(gasto).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Gastos.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Gasto { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
