using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GastosDelHogar.Shared.Entidades
{
    public class Gasto
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe elegir una persona")]
        public int PersonaId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe elegir un tipo")]
        public int TipoId { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 30 caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El monto debe ser mayor que 1"), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal? Monto { get; set; }
        [DataType(DataType.Date)]
        [Required (ErrorMessage = "El campo {0} es requerido")]
        public DateTime? Fecha { get; set; }
        public bool Pagado { get; set; } = false;
        public string Descripcion { get; set; }
        public Persona Persona { get; set; }
        public Tipo Tipo { get; set; }
    }
}
