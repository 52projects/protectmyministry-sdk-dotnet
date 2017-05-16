using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectMyMinistry.Api.Entity {
    public class Order {
        public string ID { get; set; }
        public string ReturnResultUrl { get; set; }
        public OrderSubject OrderSubject { get; set; }
        public string PackageServiceCode { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }
        public string BillingReference { get; set; }
    }
}
