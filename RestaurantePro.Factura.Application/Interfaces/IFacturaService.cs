using RestaurantePro.Factura.Application.Base;
using RestaurantePro.Factura.Application.Dtos;

namespace RestauranteMaMonolitica.Web.BL.Interfaces
{
    public interface IFacturaService
    {
       ServiceResult GetFacturas();

        ServiceResult GetFactura(int id);

        ServiceResult updateFactura(FacturaUpdateDto facturaUpdate);

        ServiceResult removeFactura(FacturaRemoveDto facturaRemove);

        ServiceResult saveFactura(FacturaSaveDto facturaSave);


    }
}
