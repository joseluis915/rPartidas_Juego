using System;
using System.Collections.Generic;
using System.Text;
//Añadí estos using
using Microsoft.EntityFrameworkCore;
using rPartidas_Juego.Entidades;

namespace rPartidas_Juego.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Jugadores> Jugadores { get; set; }
        public DbSet<Partidas> Partidas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Ctrl + . + GenerateOverrrides + Seleccionar (OnConfiguring)
        {
            optionsBuilder.UseSqlite(@"Data Source= Data\PartidaJuego_DB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Ctrl + . + GenerateOverrrides + Seleccionar (OnModelCreating)
        {
            //Crear 4 jugadores
            modelBuilder.Entity<Jugadores>().HasData(new Jugadores { JugadorId = 1, Nombres = "Jose" });
            modelBuilder.Entity<Jugadores>().HasData(new Jugadores { JugadorId = 2, Nombres = "Luis" });
            modelBuilder.Entity<Jugadores>().HasData(new Jugadores { JugadorId = 3, Nombres = "Burgos" });
            modelBuilder.Entity<Jugadores>().HasData(new Jugadores { JugadorId = 4, Nombres = "Hernandez" });

            //Crear una partida
            //var partida = new Partidas();
            //partida.PartidaId = 1;
            //partida.Descripcion = "Ejemplo Descripcion";

            //partida.Detalle.Add(new PartidasDetalle { Id = 1, PartidaId = 1, JudadorId = 1, Prosicion = 1 });
            //partida.Detalle.Add(new PartidasDetalle { Id = 1, PartidaId = 1, JudadorId = 2, Prosicion = 2 });
            //partida.Detalle.Add(new PartidasDetalle { Id = 1, PartidaId = 1, JudadorId = 3, Prosicion = 3 });
            //partida.Detalle.Add(new PartidasDetalle { Id = 1, PartidaId = 1, JudadorId = 4, Prosicion = 4 });

            //modelBuilder.Entity<Partidas>().HasData(partida);
        }
    }
}