using System;
using System.IO;
using System.Xml.Serialization;

namespace ComplianceRepository.Service
{
    public class XmlService
    {
        public T Deserialize<T>(string data)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            //formatter.UnknownElement += (obj, e) => Console.WriteLine("Элемент неизвестный " + e.LinePosition + " " + e.LineNumber + " " + e.Element + " " + e.Element.InnerText);
            //formatter.UnknownNode += (obj, e) => Console.WriteLine("Ветка неизвестная " + e.LinePosition + " " + e.LineNumber + " " + e.LocalName);
            //formatter.UnreferencedObject += (obj, e) => Console.WriteLine(e.UnreferencedId);

            using (TextReader reader = new StringReader(data))
            {
                return (T)formatter.Deserialize(reader);
            }
        }
    }
}