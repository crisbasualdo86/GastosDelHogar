using GastosDelHogar.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GastosDelHogar.Shared.DTOs
{
    public class GastosDTO
    {
        public List<Gasto> Gastos { get; set; }
        public decimal totalGastos { get; set; }
    }
}
