using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
