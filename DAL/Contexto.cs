using System;
using System.Collections.Generic;
using System.Text;
using PuntosExtras.Entidades;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PuntosExtras.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data\PersonasDB");
        }


    }
}
