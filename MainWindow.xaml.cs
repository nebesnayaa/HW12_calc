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

namespace HW12_calc
{
    public partial class MainWindow : Window
    {
        public CalculatorModel CalculatorModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CalculatorModel = new CalculatorModel();
            DataContext = CalculatorModel;

            PreviewLostKeyboardFocus += MainWindow_PreviewLostKeyboardFocus;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == "0")
            {
                textBox.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
            }
            CalculatorModel.UpdateResult();
        }
        private void MainWindow_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            CalculatorModel.UpdateResult();
        }
    }
}
