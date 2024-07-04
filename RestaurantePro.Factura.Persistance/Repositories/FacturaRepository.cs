

using RestauranteMaMonolitica.Web.Data.Helpers;
using RestaurantePro.Factura.Domain.Interface;
using RestaurantePro.Factura.Persistance.Context;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace RestaurantePro.Factura.Persistance.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly RestauranteContext context;
        public FacturaRepository(RestauranteContext context) 
        { 
             this.context = context;
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
            return context.Factura.Select(factura => FacturaHelper.MapToFacturaModel(factura)).ToList();
        }

        public void Remove(Domain.Entities.Factura entity)
        {
            Factura facturaToDelete = FacturaHelper.FindFacturaById(context, facturaRemove.IdFactura);

            facturaToDelete.deleted = facturaRemove.deleted;
            facturaToDelete.delete_date = facturaRemove.delete_date;
            facturaToDelete.delete_user = facturaRemove.delete_user;

            context.Factura.Update(facturaToDelete);
            context.SaveChanges();
        }

        public void Save(Domain.Entities.Factura entity)
        {
            Factura factura = new Factura();
            FacturaHelper.MapFacturaSaveModel(facturaSave, factura);

            context.Factura.Add(factura);
            context.SaveChanges();
        }

        public void Update(Domain.Entities.Factura entity)
        {
            Factura facturaToUpdate = FacturaHelper.FindFacturaById(context, updateModel.IdFactura);

            facturaToUpdate.modify_date = updateModel.ChangeDate;
            facturaToUpdate.modify_user = updateModel.ChangeUser;
            facturaToUpdate.Fecha = updateModel.Fecha;
            facturaToUpdate.Total = updateModel.Total;

            context.Factura.Update(facturaToUpdate);
            context.SaveChanges();
        }
    }
}
