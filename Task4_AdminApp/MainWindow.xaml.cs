using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace Task4_AdminApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SettingsManager settingsManager = new SettingsManager();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue.HasValue)
            {
                Color selectedColor = e.NewValue.Value;
                settingsManager.Color = $"#{selectedColor.R:X2}{selectedColor.G:X2}{selectedColor.B:X2}";
            }
        }

        private void ConfirmSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(HeightTextBox.Text, out int height))
            {
                settingsManager.Height = height;
            } 

            if (int.TryParse(WidthTextBox.Text, out int width))
            {
                settingsManager.Width = width;
            }

            if (int.TryParse(FontSizeTextBox.Text, out int fontSize))
            {
                settingsManager.FontSize = fontSize;
            }

            settingsManager.InvisibleButton = InvisibleCheckBox.IsChecked.GetValueOrDefault();
            settingsManager.VisibleButton = VisibleCheckBox.IsChecked.GetValueOrDefault();

            settingsManager.UpdateSettings();
            System.Windows.MessageBox.Show("Операція успішна!");
        }
    }
}
