
using RestauranteMaMonolitica.Web.Data.Models;
using RestaurantePro.Factura.Domain.Entities;
using RestaurantePro.Factura.Domain.Interface;
using RestaurantePro.Factura.Persistance.Context;
using RestauranteSol.Common.Data.Repository;
using System.Linq.Expressions;
using System.Numerics;

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
            return _context.Factura.Any(filter);
        }

        public List<Domain.Entities.Factura> GetAll()
        {
            return _context.Factura.ToList();
        }

        public Domain.Entities.Factura GetEntityById(int Id)
        {
            return _context.Factura.Find(Id);
        }

        public List<Domain.Entities.Factura> GetFactura(int id)
        {
            return _context.Factura.Where(f => f.id == id).ToList();
        }

        public void Remove(Domain.Entities.Factura entity)
        {
            _context.Factura.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(Domain.Entities.Factura entity)
        {
         
            _context.Add(entity);
            _context.SaveChanges();

        }

        public void Update(Domain.Entities.Factura entity)
        {
            _context.Factura.Update(entity);
            _context.SaveChanges();
        }
    }
}
