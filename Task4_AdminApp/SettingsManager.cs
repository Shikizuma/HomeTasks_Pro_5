using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Task4_AdminApp
{
    internal class SettingsManager
    {
        public string Color { get; set; }
        public int FontSize { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool VisibleButton { get; set; }
        public bool InvisibleButton { get; set; }

        public bool UpdateSettings()
        {
            try
            {
                var xmldoc = new XmlDocument();
                xmldoc.Load("C:\\Users\\myros\\source\\repos\\HomeTasks_Pro_5\\Task4_UserApp\\bin\\Debug\\net6.0-windows\\SettingsWindow.xml");

                XPathNavigator navigator = xmldoc.CreateNavigator();

                XPathExpression expr = navigator.Compile("/Settings/ColorSettings/BackgroundColor");
                XPathNavigator backgroundColorNode = navigator.SelectSingleNode(expr);

                expr = navigator.Compile("/Settings/SizeSettings/Width");
                XPathNavigator widthNode = navigator.SelectSingleNode(expr);

                expr = navigator.Compile("/Settings/SizeSettings/Height");
                XPathNavigator heightNode = navigator.SelectSingleNode(expr);

                expr = navigator.Compile("/Settings/FontSettings/FontSize");
                XPathNavigator fontSizeNode = navigator.SelectSingleNode(expr);

                expr = navigator.Compile("/Settings/ButtonVisibility/Button");
                XPathNavigator visibleButtonNode = navigator.SelectSingleNode("//Button[@name='VisibleButton']");
                XPathNavigator invisibleButtonNode = navigator.SelectSingleNode("//Button[@name='InvisibleButton']");

                if (backgroundColorNode != null &&
                                widthNode != null &&
                                heightNode != null &&
                                fontSizeNode != null &&
                                visibleButtonNode != null &&
                                invisibleButtonNode != null)
                {
                    backgroundColorNode.SetValue(Color);
                    widthNode.SetValue(Width.ToString());
                    heightNode.SetValue(Height.ToString());
                    fontSizeNode.SetValue(FontSize.ToString());
                    visibleButtonNode.SetValue(VisibleButton.ToString());
                    invisibleButtonNode.SetValue(InvisibleButton.ToString());

                    xmldoc.Save("C:\\Users\\myros\\source\\repos\\HomeTasks_Pro_5\\Task4_UserApp\\bin\\Debug\\net6.0-windows\\SettingsWindow.xml");

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            return false;
        }

    }
}
