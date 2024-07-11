using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePro.Factura.Application.Base
{
    public class ServiceResult
    {

        public ServiceResult()
        {
            this.Success = true;
        }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }
        public bool Sucess { get; internal set; }
    }
}
  
