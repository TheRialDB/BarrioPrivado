﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrioPrivado.BD.Data.Entity
{
    [Index(nameof(DNI), Name = "Residente_DNI_UQ", IsUnique = true)]
    public class Residente
    {

        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El NOMBRE es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "El APELLIDO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el APELLIDO")]
        public string apellido { get; set; }

        [Required(ErrorMessage = "El DNI es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el DNI")]
        public string DNI { get; set; }

        public List<Visitante> Visitantes { get; set; } = new List<Visitante>();
        
        [Required(ErrorMessage = "El Codigo del domicilio es Obligatorio")]
        [MaxLength(4, ErrorMessage = "Solo se aceptan hasta 4 caracteres en el CODIGO")]
        public string codigoDomicilio { get; set; }
        
    }
}
