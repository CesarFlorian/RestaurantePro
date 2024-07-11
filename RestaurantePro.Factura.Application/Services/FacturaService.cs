

using Microsoft.Extensions.Logging;
using RestauranteMaMonolitica.Web.BL.Interfaces;

using RestauranteMaMonolitica.Web.Data.Helpers;
using RestaurantePro.Factura.Application.Base;
using RestaurantePro.Factura.Application.Dtos;
using RestaurantePro.Factura.Domain.Interface;
using System.Reflection.Metadata.Ecma335;
namespace RestauranteMaMonolitica.Web.BL.Services
{
    public class FacturaService : IFacturaService
    {

        private readonly IFacturaRepository FacturaRepository;
        private readonly ILogger<FacturaService> logger;

        public FacturaService (IFacturaRepository FacturaDb, ILogger<FacturaService> logger) 
        { 
             this.FacturaRepository = FacturaDb;
             this.logger = logger;
        }

        public ServiceResult GetFacturas() 
        { 
           ServiceResult result = new ServiceResult();

            try
            {
                result.Data = FacturaRepository.GetAll();
            }
            catch (Exception ex)
            {

                result.Sucess = false;
                result.Message = "Ocurrio un error obteniendo las Facturas";
                this.logger.LogError(result.Message, ex.ToString());    
            }

            return result;
            
        }

           public ServiceResult GetFactura(int id) 
           {
                ServiceResult result = new ServiceResult();

            try
            {
                result.Data = FacturaRepository.GetEntityById(id);

            }
            catch (Exception ex)
            {

                result.Sucess = false;
                result.Message = "Ocurrio un error obteniendo las Facturas";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        
            }


        public ServiceResult updateFactura(FacturaUpdateDto facturaUpdate) 
        {
            

            erviceResult result = new ServiceResult();

            try
            {
                if (FacturaHelper.IsNullOrWhitespace(facturaUpdate, result, "La Factura no puede ser nulo."))
                    return result;

                if (FacturaHelper.IsInvalidDecimalLength(facturaUpdate.Total, result, "La longitud del numero debe ser de 10.", 10, 2))
                    return result;

                this.FacturaRepository.Update();
            }
            catch (Exception ex)
            {
                result.Sucess = false;
                result.Message = "Ocurrio un error Actualizando los Datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
           
        }

       public  ServiceResult removeFactura(FacturaRemoveDto facturaRemove) 
        { 
            ServiceResult result= new ServiceResult();

            try
            {
                if (facturaRemove is null)
                {
                    result.Sucess = false;
                    result.Message = "La Factura no puede ser nulo.";
                    return result;
                }
                this.FacturaRepository.Remove();
            }
            catch (Exception ex)
            {
                result.Sucess = false;
                result.Message = ("Ocurrio un error removiendo los datos.");
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

       public ServiceResult saveFactura(FacturaSaveDto facturaSave) 
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (FacturaHelper.IsNullOrWhitespace(facturaSave, result, "La Factura no puede ser nulo."))
                    return result;

                if (FacturaHelper.IsInvalidDecimalLength(facturaSave.Total, result, "La longitud del numero debe ser de 10.", 10, 2))
                    return result;

                this.FacturaRepository.Save(facturaSave);
            }
            catch (Exception ex)
            {
                result.Sucess = false;
                result.Message = "Ocurrio un error Actualizando los Datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result; 
        }

       
    }
}
