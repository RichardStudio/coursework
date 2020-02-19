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
using Library;

namespace Interface
{
    delegate string Output(int number);
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Prime prime = new Prime();
        Output output;
        public MainWindow()
        {
            InitializeComponent();
        }

        void VisibilityOfObjects()
        {
            InputBox.Visibility = Visibility.Visible;
            StartButton.Visibility = Visibility.Visible;
            OutputBlock.Visibility = Visibility.Visible;
        }

        void ClearObjects()
        {
            InputBox.Text = "";
            OutputBlock.Text = "";
        }

        private void TreeViewItem_OnSelected(object sender, RoutedEventArgs e)
        {
            ClearObjects();
            VisibilityOfObjects();
            switch (((TreeViewItem)sender).Name)
            {
                case "AllPrimesUpTo":
                    output = num => string.Join(", ", prime.AllPrimesUpTo(num));
                    break;
                case "PrimeUpTo":
                    output = num => prime.PrimeUpTo(num).ToString();
                    break;
                case "IsPrime":
                    output = num => prime.IsPrime(num).ToString();
                    break;
                case "Factorization":
                    output = num => string.Join(", ", prime.Factorization(num));
                    break;
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(InputBox.Text);
            OutputBlock.Text = output?.Invoke(num);
        }
    }
}
