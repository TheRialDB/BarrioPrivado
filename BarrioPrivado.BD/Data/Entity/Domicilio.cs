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
    //[Index(nameof(ResidenteId), Name = "Domicilio_ResidenteId_UQ", IsUnique = true)]
    //[Index(nameof(codigoDomicilio), Name = "Codigo_Domicilio_UQ", IsUnique = true)]
    public class Domicilio
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El LOTE es Obligatorio")]
        [MaxLength(1, ErrorMessage = "Solo se aceptan hasta 1 caracter en el LOTE")]
        public string lote { get; set; }

        [Required(ErrorMessage = "LA MANZANA es Obligatorio")]
        [MaxLength(3, ErrorMessage = "Solo se aceptan hasta 3 caracteres en la MANZANA")]
        public string manzana { get; set; }

        //[Required(ErrorMessage = "El CODIGO es Obligatorio")]
        public string codigoDomicilio { get; set; }


        //[Required(ErrorMessage = "El Residente del domicilio es Obligatorio")]
        //public int ResidenteId { get; set; }
        //public Residente Residente { get; set; }
    }
}
