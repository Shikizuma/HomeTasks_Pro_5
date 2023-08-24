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

namespace Task4_UserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings settings = new Settings();
        public MainWindow()
        {
            InitializeComponent(); 
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetWindowProperty();
            SetVisibility();
            SetLabelFontSizes();
            SetValues();
        }

        private void SetValues()
        {
            ValueHeightLabel.Content = settings.Height;
            ValueWidthLabel.Content = settings.Width;
            ValueColorLabel.Content = settings.Color;
            ValueFontSizeLabel.Content = settings.FontSize;
            ValueButtVisbleLabel.Content = settings.VisibleButton + " | " + settings.InvisibleButton;
        }

        private void SetWindowProperty()
        {
            Color color = (Color)ColorConverter.ConvertFromString(settings.Color);
            SolidColorBrush brush = new SolidColorBrush(color);
            Background = brush;
            Height = settings.Height;
            Width = settings.Width;
        }

        private void SetLabelFontSizes()
        {
            var labels = FindVisualChildren<Label>(this);

            foreach (var label in labels)
            {
                label.FontSize = settings.FontSize;
            }
        }

        private void SetVisibility()
        {
            if (settings.VisibleButton)
                VisibleButton.Visibility = Visibility.Visible;
            else
                VisibleButton.Visibility = Visibility.Hidden;

            if (settings.InvisibleButton)
                InvisibleButton.Visibility = Visibility.Visible;
            else
                InvisibleButton.Visibility = Visibility.Hidden;
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            settings = new Settings();
            SetWindowProperty();
            SetVisibility();
            SetLabelFontSizes();
            SetValues();
        }
    }
}
