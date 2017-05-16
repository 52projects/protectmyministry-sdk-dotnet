using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtectMyMinistry.Api.Entity {
    public class ComboOrderDetail : OrderDetail {
        public ComboOrderDetail() : base() {
            this.ServiceCode = "combo";
        }
    }
}
