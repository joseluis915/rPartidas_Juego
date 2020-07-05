using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace rPartidas_Juego.Entidades
{
    public class PartidasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PartidaId { get; set; }
        public int JugadorId { get; set; }

        [ForeignKey("JugadorId")]
        public Jugadores Jugador { get; set; } = new Jugadores();
        public int Posicion { get; set; }
    }
}