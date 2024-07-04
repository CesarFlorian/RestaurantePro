


using RestauranteMaMonolitica.Web.Data.Entities;
using RestauranteMaMonolitica.Web.Data.Models;
using RestaurantePro.Factura.Persistance.Context;

namespace RestauranteMaMonolitica.Web.Data.Helpers
{

  
    public static class FacturaHelper 
    {
        public static Factura FindFacturaById(RestauranteContext context, int IdFactura)
        {
            var factura = context.Factura.Find(IdFactura);

            if (factura == null)
            {
                throw new FacturaDbException($"No se encontro el departamento con el id {IdFactura}");
            }

            return factura;
        }

        public static FacturaGetModel MapToFacturaModel(Factura factura)
        {
            
            return new FacturaGetModel
            {
                
                IdFactura = factura.IdFactura,
                Fecha = factura.Fecha,
                Total = factura.Total,
                creation_date = factura.creation_date
            };

        }

        public static void MapFacturaSaveModel(FacturaSaveModel saveModel, Factura factura)
        {
        
            factura.Total = saveModel.Total;
            factura.Fecha = saveModel.Fecha;
            factura.creation_date = saveModel.ChangeDate;
            factura.creation_user = saveModel.ChangeUser;
        }

        public static bool IsNullOrWhitespace(object obj, FacturaServiceResult result, string errorMessage)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.ToString()))
            {
                result.Sucess = false;
                result.Message = errorMessage;
                return true;
            }
            return false;
        }

        public static bool IsInvalidDecimalLength(decimal value, FacturaServiceResult result, string errorMessage, int maxIntegerDigits, int maxDecimalDigits)
        {
            string[] parts = value.ToString().Split('.');
            int integerDigits = parts[0].Length;
            int decimalDigits = parts.Length > 1 ? parts[1].Length : 0;

            if (integerDigits + decimalDigits > maxIntegerDigits || decimalDigits > maxDecimalDigits)
            {
                result.Sucess = false;
                result.Message = errorMessage;
                return true;
            }
            return false;
        }
    }

}


    