namespace CiccioGest.Infrastructure.DomainBase
{
    public interface IEntityRepository<TEntity, TId> where TEntity : Entity<TId>
    {
        TEntity GetById(TId id);
        TId Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TId id);
    }
}
