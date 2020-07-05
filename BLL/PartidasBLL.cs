using System;
using System.Collections.Generic;
using System.Text;
//Añadí estos using
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using rPartidas_Juego.DAL;
using rPartidas_Juego.Entidades;

namespace rPartidas_Juego.BLL
{
    public class PartidasBLL
    {
        //——————————————————————————————————————————————[ GUARDAR ]——————————————————————————————————————————————
        public static bool Guardar(Partidas partidas)
        {
            bool paso;

            if (!Existe(partidas.PartidaId))
                paso = Insertar(partidas);
            else
                paso = Modificar(partidas);

            return paso;
        }
        //——————————————————————————————————————————————[ INSERTAR ]——————————————————————————————————————————————
        public static bool Insertar(Partidas partidas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Partidas.Add(partidas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        //——————————————————————————————————————————————[ MODIFICAR ]——————————————————————————————————————————————
        public static bool Modificar(Partidas partidas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                //Borrar el detalle anterior.
                contexto.Database.ExecuteSqlRaw($"Delete From PartidasDetalle Where PartidaId={partidas.PartidaId}");

                foreach (var item in partidas.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Entry(partidas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        //——————————————————————————————————————————————[ ELIMINAR ]——————————————————————————————————————————————
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var partidas = contexto.Partidas.Find(id);
                if (partidas != null)
                {
                    contexto.Partidas.Remove(partidas);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        //——————————————————————————————————————————————[ GETLIST ]——————————————————————————————————————————————
        public static List<Partidas> GetList(Expression<Func<Partidas, bool>> criterio)
        {
            List<Partidas> lista = new List<Partidas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Partidas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        //——————————————————————————————————————————————[ EXISTE ]——————————————————————————————————————————————
        public static bool Existe(int id)
        {
            bool encontrado = false;
            Contexto contexto = new Contexto();

            try
            {
                encontrado = contexto.Partidas.Any(p => p.PartidaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
        //——————————————————————————————————————————————[ BUSCAR ]——————————————————————————————————————————————
        public static Partidas Buscar(int id)
        {
            Partidas partidas = new Partidas();
            Contexto contexto = new Contexto();

            try
            {
                partidas = contexto.Partidas
                    .Where(p => p.PartidaId == id)
                    .Include(p => p.Detalle).ThenInclude(d => d.Jugador)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return partidas;
        }
    }
}