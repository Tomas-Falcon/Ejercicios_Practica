using Tarea_Curso_Jorge.Context;
using Tarea_Curso_Jorge.Models;
using Tarea_Curso_Jorge.Repository;

namespace Tarea_Curso_Jorge.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        
        public IRepository<Games> _repository { get; }

        public UnitOfWork(AppDbContext appDbContext, IRepository<Games> repository)
        {
            _appDbContext = appDbContext;
            _appDbContext.Database.EnsureCreated();
            _repository = repository;
        }

        void IUnitOfWork.Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
