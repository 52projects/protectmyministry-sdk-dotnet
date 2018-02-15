using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtectMyMinistry.Api.Entity {
    public class CountyCriminalOrderDetail : OrderDetail {
        public string County { get; set; }
        public string State { get; set; }
        public string JurisdictionCode { get; set; }
        public int? YearsToSearch { get; set; }
        public bool RequestCourtDocuments { get; set; }
        public bool RushRequest { get; set; }
        public string SpecialInstructions { get; set; }

        public CountyCriminalOrderDetail() : base() {
            this.ServiceCode = "CountyCrim";
        }

        public override XmlElement ToXml(XmlDocument doc, string orderID) {
            var orderDetailNode = base.ToXml(doc, orderID);

            var countyNode = doc.CreateElement("County");
            countyNode.InnerText = this.County;
            orderDetailNode.AppendChild(countyNode);

            var stateNode = doc.CreateElement("State");
            stateNode.InnerText = this.State;
            orderDetailNode.AppendChild(stateNode);

            var yearsToSearchNode = doc.CreateElement("YearsToSearch");
            yearsToSearchNode.InnerText = this.YearsToSearch.GetValueOrDefault(7).ToString();
            orderDetailNode.AppendChild(yearsToSearchNode);

            var courtDocRequestedNode = doc.CreateElement("CourtDocsRequested");
            courtDocRequestedNode.InnerText = this.RequestCourtDocuments ? "YES" : "NO";
            orderDetailNode.AppendChild(courtDocRequestedNode);

            var rushRequestedNode = doc.CreateElement("RushRequested");
            rushRequestedNode.InnerText = this.RushRequest ? "YES" : "NO";
            orderDetailNode.AppendChild(rushRequestedNode);

            var specialInstructionsNode = doc.CreateElement("SpecialInstructions");
            specialInstructionsNode.InnerText = this.SpecialInstructions;
            orderDetailNode.AppendChild(specialInstructionsNode);

            if (!string.IsNullOrEmpty(JurisdictionCode)) {
                var jurisdictionCodeNode = doc.CreateElement("JurisdictionCode");
                jurisdictionCodeNode.InnerText = this.JurisdictionCode;
                orderDetailNode.AppendChild(jurisdictionCodeNode);
            }

            return orderDetailNode;
        }
    }
}
