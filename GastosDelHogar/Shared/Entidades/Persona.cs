using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GastosDelHogar.Shared.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        [Range(1, int.MaxValue, ErrorMessage = "El monto debe ser mayor que 1"), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal? Ingresos { get; set; }
        public List<Gasto> Gastos { get; set; }
    }
}
