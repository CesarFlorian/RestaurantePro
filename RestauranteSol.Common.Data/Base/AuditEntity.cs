using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteSol.Common.Data.Base
{
    public abstract class AuditEntity<TType> : BaseEntity<TType>
     {  
        public int creation_user { get; set; }

        public DateTime creation_date { get; set; }

        public DateTime? modify_date { get; set; }


        public int? modify_user { get; set; }
        public int? delete_user { get; set; }
        public DateTime? delete_date { get; set; }

        public bool? deleted { get; set; }

       }
}
