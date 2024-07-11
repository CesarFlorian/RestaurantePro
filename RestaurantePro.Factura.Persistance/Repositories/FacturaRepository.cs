
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
            Domain.Entities.Factura facturaRemove = this.GetEntityById(entity.id);
            if (facturaRemove == null)
            {
                throw new ArgumentNullException("El curso que desea Actualizar no se Encuentra Registrado");
            }
            
            facturaRemove .id = entity.id;
            facturaRemove.deleted =entity.deleted;
            facturaRemove.delete_date = entity.delete_date;
            facturaRemove.delete_user = entity.delete_user;

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
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("la entidad esta nula");
                }

                Domain.Entities.Factura facturaToUpdate = this._context.Factura.Find(entity.id);
                if (facturaToUpdate == null)
                {
                    throw new ArgumentNullException("El curso que desea Actualizar no se Encuentra Registrado");
                }
                 facturaToUpdate.Total = entity.Total;
                 facturaToUpdate.Fecha = entity.Fecha;
                 facturaToUpdate.modify_date = entity.modify_date;
                 facturaToUpdate.modify_user = entity.modify_user;

                _context.Factura.Update(facturaToUpdate);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            { 
              throw ex;
            }
        }
            
        }
    }

