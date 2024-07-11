using RestaurantePro.Factura.Application.Base;
using RestaurantePro.Factura.Application.Dtos;

namespace RestaurantePro.Factura.Application.Interfaces
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
