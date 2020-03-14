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
    public class TiposController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TiposController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tipo>>> Get() {
            return await context.Tipos.ToListAsync();
        }
    }
}
