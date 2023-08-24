using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Task4_UserApp
{
    internal class Settings
    {
        public string Color { get; set; }
        public int FontSize { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool VisibleButton { get; set; }
        public bool InvisibleButton { get; set; }

        public Settings()
        {
            UpdateWindowSettings();
        }

        public bool UpdateWindowSettings()
        {
            try
            {
                var xmldoc = new XmlDocument();
                xmldoc.Load("SettingsWindow.xml");

                XPathNavigator navigator = xmldoc.CreateNavigator();

                Color = navigator.SelectSingleNode("/Settings/ColorSettings/BackgroundColor").Value;

                Width = int.Parse(navigator.SelectSingleNode("/Settings/SizeSettings/Width").Value);

                Height = int.Parse(navigator.SelectSingleNode("/Settings/SizeSettings/Height").Value);

                FontSize = int.Parse(navigator.SelectSingleNode("/Settings/FontSettings/FontSize").Value);

                VisibleButton = bool.Parse(navigator.SelectSingleNode("/Settings/ButtonVisibility/Button[@name='VisibleButton']").Value);
                InvisibleButton = bool.Parse(navigator.SelectSingleNode("/Settings/ButtonVisibility/Button[@name='InvisibleButton']").Value);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            return false;
        }
    }
}
