using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BarrioPrivado.Shared.DTO
{
    public class DomicilioDTO
    {
        [Required(ErrorMessage = "El NOMBRE es Obligatorio")]
        [MaxLength(1, ErrorMessage = "Solo se aceptan hasta 1 caracter en el LOTE")]
        public string lote { get; set; }

        [Required(ErrorMessage = "LA MANZANA es Obligatoria")]
        [MaxLength(3, ErrorMessage = "Solo se aceptan hasta 3 caracteres en la MANZANA")]
        public string manzana { get; set; }

    }
}
