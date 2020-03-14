using GastosDelHogar.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GastosDelHogar.Server.Helpers
{
    public class ParametrosBusquedaGastos
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
        public Paginacion Paginacion
        {
            get { return new Paginacion() { Pagina = Pagina, CantidadRegistros = CantidadRegistros }; }
        }
        public string Nombre { get; set; }
        public int Mes { get; set; } 
        public int PersonaId { get; set; }
        public int TipoId { get; set; }
        public bool Pagados { get; set; }
    }
}
