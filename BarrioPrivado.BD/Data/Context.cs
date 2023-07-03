using BarrioPrivado.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrioPrivado.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Residente> Residentes => Set<Residente>();
        public DbSet<Visitante> Visitantes => Set<Visitante>();
        public DbSet<Domicilio> Domicilios => Set<Domicilio>();


        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
