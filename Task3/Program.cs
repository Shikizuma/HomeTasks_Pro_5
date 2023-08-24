using System.Xml;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayAttribute("TelephoneBook.xml");

            //string filePath = "TelephoneBook.xml";

            //try
            //{
            //    XmlDocument xmlDoc = new XmlDocument();
            //    xmlDoc.Load(filePath);
            //    DisplayAttribute(xmlDoc.DocumentElement!);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Помилка: " + ex.Message);
            //}
        }

        static void DisplayAttribute(string xml)
        {

            var reader = new XmlTextReader(xml);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                { 
                    if (reader.Name.Equals("Name"))   
                    {
                        Console.WriteLine(reader.GetAttribute("number"));
                    }
                }
            }
            //if (node is XmlElement)
            //{
            //    if (node.Attributes != null)
            //    {
            //        foreach (XmlAttribute attr in node.Attributes)
            //        {
            //            Console.WriteLine("  Атрибут: " + attr.Name + " = " + attr.Value);
            //        }
            //    }
            //}

            //foreach (XmlNode childNode in node.ChildNodes)
            //{
            //    DisplayAttribute(childNode);
            //}
        }
    }
}