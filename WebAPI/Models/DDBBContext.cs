using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class DDBBContext :DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Mercado> Mercados { get; set; }

        public DDBBContext()
        {

        }

        public DDBBContext(DbContextOptions options)
        : base(options)
        {
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=efddbb;Uid=root;Pwd=''; SslMode = none");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Evento>().HasData(new Evento(1, "Madrid", "Barcelona", 2));
            modelBuilder.Entity<Evento>().HasData(new Evento(2, "Valencia", "Betis", 2));
            modelBuilder.Entity<Evento>().HasData(new Evento(3, "Sevilla", "Deportivo", 3));

            modelBuilder.Entity<Usuario>().HasData(new Usuario(1, "paco@gmail.com", "paco", "garcia", 21));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(2, "pepe@gmail.com", "pepe", "fernandez", 27));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(3, "pedro@gmail.com", "pedro", "martinez", 32));
            
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, 1, 2, 1, 1, 2.5, 50));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(2, 3, 3, 2, 0, 1.5, 100));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(3, 2, 1, 3, 1, 3.5, 150));
            
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 1.5, 1.43, 2.85, 100, 50, 1));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2, 2.5, 1.9, 1.9, 100, 100, 2));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(3, 3.5, 2.85, 1.43, 50, 100, 3));
            */



        }
    }
}