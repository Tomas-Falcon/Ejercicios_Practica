namespace Tarea_Curso_Jorge.Repository
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(T entity);
        void Insert(T entity);
        Boolean Update(T entity);
        Boolean Delete(T entity);
    }
}
