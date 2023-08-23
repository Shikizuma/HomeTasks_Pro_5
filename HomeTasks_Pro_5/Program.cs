using System.Xml;

namespace HomeTasks_Pro_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "test.xml"; 

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                DisplayXmlInfo(xmlDoc.DocumentElement!);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }

        static void DisplayXmlInfo(XmlNode node)
        {
            if (node is XmlElement)
            {
                Console.WriteLine("Елемент: " + node.Name);

                if (node.Attributes != null)
                {
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        Console.WriteLine("  Атрибут: " + attr.Name + " = " + attr.Value);
                    }
                }
            }
            else if (node is XmlText)
            {
                string text = ((XmlText)node).InnerText.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    Console.WriteLine("  Текст: " + text);
                }
            }

            foreach (XmlNode childNode in node.ChildNodes)
            {
                DisplayXmlInfo(childNode);
            }
        }
    }
}