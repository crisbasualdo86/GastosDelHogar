using GastosDelHogar.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace GastosDelHogar.Shared.DTOs
{
    public class HomePageDTO
    {
        public List<Persona> Personas { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal TotalIngresos { get; set; }
    }
}
