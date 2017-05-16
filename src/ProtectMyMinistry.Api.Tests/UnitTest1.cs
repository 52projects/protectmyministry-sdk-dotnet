using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtectMyMinistry.Api.Entity;
using System.Collections.Generic;

namespace ProtectMyMinistry.Api.Tests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            var client = new ApiClient();
            client.PostUrl = this.GetConfigValue("PMM.PostUrl");
            client.Username = this.GetConfigValue("PMM.Username");
            client.Password = this.GetConfigValue("PMM.Password");
            client.IsTesting = (this.GetConfigValue("PMM.IsTesting", false) == "true");

            var order = new Order();
            order.BillingReference = "1234";
            order.ID = "123456";
            order.ReturnResultUrl = "http://google.com";
            order.PackageServiceCode = "PLUS";
            order.OrderSubject = new OrderSubject {
                FirstName = "John",
                MiddleName = "Robert",
                LastName = "Smith",
                Generation = "Jr.",
                DOB = new DateTime(1975,12,31),
                SSN = "123-45-6789",
                Gender = "Male",
                Ethnicity = "Caucasian",
                ApplicantPosition = "appPosition",
                StreetAddress = "222 Any Street",
                City = "Chandler",
                State= "AZ",
                Zipcode = "85224"
            };
            order.OrderDetails = new List<OrderDetail> {
                new ComboOrderDetail(),
                new CountyCriminalOrderDetail() {
                    County = "Maricopa",
                    State = "AZ",
                    YearsToSearch = 7,
                    RequestCourtDocuments = false,
                    RushRequest = false,
                    SpecialInstructions = "Special Instructions"
                }
            };

            var response = client.SendOrder(order);
        }

        public string GetConfigValue(string key, bool failOnNull = true) {
            var configValue = System.Configuration.ConfigurationManager.AppSettings[key];
            if (configValue == null && failOnNull) throw new Exception("Missing Configuration Key: " + key);
            return configValue;
        }
    }
}
