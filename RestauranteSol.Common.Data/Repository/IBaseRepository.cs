

using System.Linq.Expressions;

namespace RestauranteSol.Common.Data.Repository
{
    public interface IBaseRepository <TEntity, TType> where TEntity : class
    {
      

        void Save(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);



        List<TEntity> GetAll();

        TEntity GetEntityById(TType Id);

        bool Exist(Expression<Func<TEntity, bool>> filter);


    }
}
