﻿

using Microsoft.Extensions.Logging;


using RestaurantePro.Factura.Application.Base;
using RestaurantePro.Factura.Application.Dtos;
using RestaurantePro.Factura.Application.Interfaces;
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
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las Facturas";
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
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo la Factura";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;

        }


        public ServiceResult updateFactura(FacturaUpdateDto facturaUpdate) 
        {


            ServiceResult result = new ServiceResult();

            try
            {
                if (facturaUpdate == null)
                {
                    result.Success = false;
                    result.Message = "La Factura no puede ser nula.";
                    return result;
                }


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrio un error Actualizando los Datos.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;

        }

       public ServiceResult removeFactura(FacturaRemoveDto facturaRemove) 
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (facturaRemove == null)
                {
                    result.Success = false;
                    result.Message = "La Factura no puede ser nula.";
                    return result;
                }

                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos de la Factura";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

       public ServiceResult saveFactura(FacturaSaveDto facturaSave) 
        {
            ServiceResult result = new ServiceResult();
           
            try
            {
              if(facturaSave == null) 
                {
                    result.Success = false;
                    result.Message = $"El objeto{nameof(facturaSave)} es requerido.";
                    return result;  
              }

                RestaurantePro.Factura.Domain.Entities.Factura factura = new RestaurantePro.Factura.Domain.Entities.Factura()
                {
                    Total = facturaSave.Total,
                    Fecha = facturaSave.Fecha,
                    creation_date = facturaSave.ChangeDate,
                    creation_user = facturaSave.ChangeUser

                };

                this.FacturaRepository.Save(factura);

               

            }


            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos de la Factura";
                
            }


            return result;








        }

       
    }
}