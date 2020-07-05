using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace rPartidas_Juego.Entidades
{
    public class Partidas
    {
        [Key]
        public int PartidaId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }

        [ForeignKey("PartidaId")]
        public virtual List<PartidasDetalle> Detalle { get; set; } = new List<PartidasDetalle>();
    }
}