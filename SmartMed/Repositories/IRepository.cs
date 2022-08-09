namespace SmartMed.Repositories
{
    public interface IRepository<T>
    {
        T? GetById(Guid entityId);
        ICollection<T> GetAll();
        T Add(T entity);
        void Delete(Guid entityId);
    }
}
