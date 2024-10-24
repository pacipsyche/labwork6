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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateCloseButtonState();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCloseButtonState();
        }

        private void UpdateCloseButtonState()
        {
            CloseButton.IsEnabled = string.IsNullOrWhiteSpace(TextBox1.Text) && string.IsNullOrWhiteSpace(TextBox2.Text);
        }

        private void FontStyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontStyleComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedStyle = selectedItem.Content.ToString();

                switch (selectedStyle)
                {
                    case "Стиль 1":
                        ApplyTextStyle("Arial", 14, Brushes.Black);
                        break;
                    case "Стиль 2":
                        ApplyTextStyle("Times New Roman", 16, Brushes.Blue);
                        break;
                    case "Стиль 3":
                        ApplyTextStyle("Calibri", 18, Brushes.Green);
                        break;
                }
            }
        }

        private void ApplyTextStyle(string fontFamily, double fontSize, Brush foreground)
        {
            TextBox1.FontFamily = new FontFamily(fontFamily);
            TextBox2.FontFamily = new FontFamily(fontFamily);
            TextBox1.FontSize = fontSize;
            TextBox2.FontSize = fontSize;
            TextBox1.Foreground = foreground;
            TextBox2.Foreground = foreground;
        }
    }
}
