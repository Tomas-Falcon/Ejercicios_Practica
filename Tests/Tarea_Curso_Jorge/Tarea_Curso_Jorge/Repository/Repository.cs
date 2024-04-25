using Microsoft.VisualBasic;
using System;
using System.Linq;
using Tarea_Curso_Jorge.Context;
using Tarea_Curso_Jorge.Models;


namespace Tarea_Curso_Jorge.Repository
{
    public class Repository : IRepository<Games>
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _appDbContext.Database.EnsureCreated();
        }

        public void Insert(Games entity)
        {
            try
            {
                _appDbContext.Juegos.Add(entity);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el juego", ex);
            }
        }

        public bool Delete(Games entity)
        {
            try
            {
                var juego = _appDbContext.Juegos.FirstOrDefault(j => j.Id == entity.Id);
                if (juego != null)
                {
                    _appDbContext.Juegos.Remove(juego);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el juego", ex);
            }
        }

        public IQueryable<Games> FindByCondition(Games entity)
        {
            var nombre = entity.Titulo.ToLower();
            return _appDbContext.Juegos.Where(j => j.Titulo.ToLower() == nombre);
        }

        public IQueryable<Games> GetAll()
        {
            return _appDbContext.Juegos;
        }

        public bool Update(Games entity)
        {

            var juego = _appDbContext.Juegos.FirstOrDefault(j => j.Id == entity.Id);
            if (juego != null)
            {
                juego.Titulo = entity.Titulo;
                juego.Puntuacion = entity.Puntuacion;
                juego.Precio = entity.Precio;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
