using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using rPartidas_Juego.DAL;
using rPartidas_Juego.Entidades;

namespace rPartidas_Juego.BLL
{
    public class JugadoresBLL
    {
        //——————————————————————————————————————————————[ GetList ]——————————————————————————————————————————————
        public static List<Jugadores> GetList()
        {
            List<Jugadores> jugadores = new List<Jugadores>();
            Contexto contexto = new Contexto();

            try
            {
                jugadores = contexto.Jugadores.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return jugadores;
        }
    }
}