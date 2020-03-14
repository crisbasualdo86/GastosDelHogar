using System;
using System.Collections.Generic;
using System.Text;

namespace GastosDelHogar.Shared.DTOs
{
    public class Paginacion
    {
        public int Pagina { get; set; }
        public int CantidadRegistros { get; set; }

        public Paginacion()
        {
            Pagina = 1;
            CantidadRegistros = 10;
        }
    }
}
