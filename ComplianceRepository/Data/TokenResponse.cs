using System.Xml.Serialization;

namespace ComplianceRepository.Data
{
    [XmlRoot(ElementName = "response")]
    public class TokenResponse
    {

        [XmlElement(ElementName = "token")]
        public string Token { get; set; }

        // [XmlAttribute(AttributeName = "noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        // public string NoNamespaceSchemaLocation { get; set; }
        // [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        // public string Xsi { get; set; }
    }
}