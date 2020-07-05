using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rPartidas_Juego.Entidades
{
   public class Jugadores
    {
        [Key]
        public int JugadorId { get; set; }
        public string Nombres { get; set; }
    }
}
