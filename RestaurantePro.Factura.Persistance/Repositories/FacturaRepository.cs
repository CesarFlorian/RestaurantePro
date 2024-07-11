using RestauranteMaMonolitica.Web.Data.Helpers;
using RestaurantePro.Factura.Domain.Entities;
using RestaurantePro.Factura.Domain.Interface;
using RestaurantePro.Factura.Persistance.Context;
using RestauranteSol.Common.Data.Repository;
using System.Linq.Expressions;

namespace RestaurantePro.Factura.Persistance.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly RestauranteContext _context;

        public FacturaRepository(RestauranteContext context)
        {
            _context = context;
        }

        public bool Exist(Expression<Func<Domain.Entities.Factura, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Factura> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Factura GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Factura> GetFactura(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Entities.Factura entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Domain.Entities.Factura entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Entities.Factura entity)
        {
            throw new NotImplementedException();
        }
    }
}
