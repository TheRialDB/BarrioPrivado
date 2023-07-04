using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BarrioPrivado.BD.Data.Entity
{
    [Index(nameof(ResidenteId), Name = "Domicilio_ResidenteId_UQ", IsUnique = true)]
    public class Domicilio
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el NOMBRE")]
        public int lote { get; set; }

        [Required(ErrorMessage = "LA MANZANA es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en LA MANZANA")]
        public int manzana { get; set; }

        [Required(ErrorMessage = "El Residente del domicilio es Obligatorio")]
        public int ResidenteId { get; set; }
        public Residente Residente { get; set; }
    }
}
