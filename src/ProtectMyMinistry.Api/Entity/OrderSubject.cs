using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProtectMyMinistry.Api.Entity {
    public class OrderSubject {
        /// <summary>
        /// This is an optional field. You may provide the position the applicant is applying for in this report.
        /// </summary>
        public string ApplicantPosition { get; set; }

        /// <summary>
        /// First name of applicant.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Middle name of applicant if available. Will not return this element if data is not available.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Last name of applicant.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Generation of applicant.
        /// </summary>
        public string Generation { get; set; }

        /// <summary>
        /// Applicant's Date of Birth.
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Social Security Number of applicant. Required for all packages in which auto populate is performed, SSN Trace orders and driving history.
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// Gender of applicant. Required for Driving History only but good to have for criminal searches as well.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Ethnicity of applicant.
        /// </summary>
        public string Ethnicity { get; set; }

        /// <summary>
        /// Driver's license number. Driving History Only.
        /// </summary>
        public string DLNumber { get; set; }

        /// <summary>
        /// Email address. Required.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Current street address for applicant.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Current address city for applicant.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Current address state for applicant.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Current address zipcode for applicant.
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        /// Convert the OrderSubject into the appropriate xml
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <returns>Subject XmlElement</returns>
        public XmlElement ToXml(XmlDocument doc) {
            var subjectNode = doc.CreateElement("Subject");

            var firstNameNode = doc.CreateElement("Firstname");
            firstNameNode.InnerText = this.FirstName;
            subjectNode.AppendChild(firstNameNode);

            var middleNameNode = doc.CreateElement("Middlename");
            middleNameNode.InnerText = this.MiddleName;
            subjectNode.AppendChild(middleNameNode);

            var lastNameNode = doc.CreateElement("Lastname");
            lastNameNode.InnerText = this.LastName;
            subjectNode.AppendChild(lastNameNode);

            var generationNode = doc.CreateElement("Generation");
            generationNode.InnerText = this.Generation;
            subjectNode.AppendChild(generationNode);

            var dobNode = doc.CreateElement("DOB");
            dobNode.InnerText = this.DOB.ToString("MM/dd/yyyy");
            subjectNode.AppendChild(dobNode);

            var ssnNode = doc.CreateElement("SSN");
            ssnNode.InnerText = this.SSN;
            subjectNode.AppendChild(ssnNode);

            var genderNode = doc.CreateElement("Gender");
            genderNode.InnerText = this.Gender;
            subjectNode.AppendChild(genderNode);

            var ethnicityNode = doc.CreateElement("Ethnicity");
            ethnicityNode.InnerText = this.Ethnicity;
            subjectNode.AppendChild(ethnicityNode);

            var applicantPositionNode = doc.CreateElement("ApplicantPosition");
            applicantPositionNode.InnerText = this.ApplicantPosition;
            subjectNode.AppendChild(applicantPositionNode);

            var emailAddressNode = doc.CreateElement("EmailAddress");
            emailAddressNode.InnerText = this.EmailAddress;
            subjectNode.AppendChild(emailAddressNode);

            var currentAddressNode = doc.CreateElement("CurrentAddress");

            var streetAddressNode = doc.CreateElement("StreetAddress");
            streetAddressNode.InnerText = this.StreetAddress;
            currentAddressNode.AppendChild(streetAddressNode);

            var cityNode = doc.CreateElement("City");
            cityNode.InnerText = this.City;
            currentAddressNode.AppendChild(cityNode);

            var stateNode = doc.CreateElement("State");
            stateNode.InnerText = this.State;
            currentAddressNode.AppendChild(stateNode);

            var zipNode = doc.CreateElement("Zipcode");
            zipNode.InnerText = this.Zipcode;
            currentAddressNode.AppendChild(zipNode);

            subjectNode.AppendChild(currentAddressNode);

            return subjectNode;
        }
    }
}
