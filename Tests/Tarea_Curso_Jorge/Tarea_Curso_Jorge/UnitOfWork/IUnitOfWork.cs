using Tarea_Curso_Jorge.Models;
using Tarea_Curso_Jorge.Repository;

namespace Tarea_Curso_Jorge.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Games> _repository { get; }
        public void Save();
    }
}
