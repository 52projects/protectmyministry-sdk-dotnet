using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtectMyMinistry.Api.Entity {
    public abstract class OrderDetail {
        public string ServiceCode { get; set; }

        public OrderDetail() {}

        public virtual XmlElement ToXml(XmlDocument doc, string orderID) {
            var orderDetailNode = doc.CreateElement("OrderDetail");
            orderDetailNode.SetAttribute("orderID", orderID);
            orderDetailNode.SetAttribute("serviceCode", ServiceCode);
            return orderDetailNode;
        }
    }
}
