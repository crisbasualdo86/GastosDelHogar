using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GastosDelHogar.Shared.Entidades
{
    public class Tipo
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Gasto> Gastos { get; set; }
    }
}
