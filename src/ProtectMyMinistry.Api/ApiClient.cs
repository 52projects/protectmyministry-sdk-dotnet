using ProtectMyMinistry.Api.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace ProtectMyMinistry.Api {
    public class ApiClient {
        public string PostUrl { get; set; }
        public bool IsTesting { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string SendOrder(Order order) {
            var orderXml = this.OrderToXml(order);

            var webClient = new WebClient();
            webClient.Encoding = new UTF8Encoding(false);
            webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            //var encodedXml = HttpUtility.UrlEncode(orderXml);
            var nvc = new NameValueCollection();
            nvc.Add("REQUEST", orderXml);

            var responseBytes = webClient.UploadValues(this.PostUrl, "POST", nvc);
            var responseString = HttpUtility.UrlDecode(webClient.Encoding.GetString(responseBytes));

            return responseString;
        }

        private string OrderToXml(Order order) {
            var doc = new XmlDocument();

            XmlElement el = (XmlElement)doc.AppendChild(doc.CreateElement("OrderXML"));

            var methodNode = doc.CreateElement("Method");
            methodNode.InnerText = "SEND ORDER";
            el.AppendChild(methodNode);

            var usernameNode = doc.CreateElement("Username");
            usernameNode.InnerText = this.Username;
            var passwordNode = doc.CreateElement("Password");
            passwordNode.InnerText = this.Password;
            var authenticationNode = doc.CreateElement("Authentication");
            authenticationNode.AppendChild(usernameNode);
            authenticationNode.AppendChild(passwordNode);
            el.AppendChild(authenticationNode);

            if (this.IsTesting) {
                var testingNode = doc.CreateElement("TestMode");
                testingNode.InnerText = this.IsTesting ? "YES" : "NO";
                el.AppendChild(testingNode);
            }

            var returnResultURLNode = doc.CreateElement("ReturnResultURL");
            returnResultURLNode.InnerText =order.ReturnResultUrl;
            el.AppendChild(returnResultURLNode);

            var orderNode = doc.CreateElement("Order");

            var billingReferenceCodeNode = doc.CreateElement("BillingReferenceCode");
            billingReferenceCodeNode.InnerText = order.BillingReference;
            orderNode.AppendChild(billingReferenceCodeNode);

            var subjectNode = order.OrderSubject.ToXml(doc);
            orderNode.AppendChild(subjectNode);

            var packageServiceCodeNode = doc.CreateElement("PackageServiceCode");
            packageServiceCodeNode.InnerText = order.PackageServiceCode;
            packageServiceCodeNode.SetAttribute("orderid", order.ID);
            orderNode.AppendChild(packageServiceCodeNode);

            foreach (var orderDetail in order.OrderDetails) {
                var orderDetailNode = orderDetail.ToXml(doc, order.ID);
                orderNode.AppendChild(orderDetailNode);
            }

            el.AppendChild(orderNode);

            using (var stringWriter = new StringWriterWithEncoding(Encoding.UTF8))
            using (var xmlTextWriter = XmlWriter.Create(stringWriter)) {
                doc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }

        public sealed class StringWriterWithEncoding : StringWriter {
            private readonly Encoding encoding;

            public StringWriterWithEncoding() : this(Encoding.UTF8) { }

            public StringWriterWithEncoding(Encoding encoding) {
                this.encoding = encoding;
            }

            public override Encoding Encoding {
                get { return encoding; }
            }
        }
    }
}