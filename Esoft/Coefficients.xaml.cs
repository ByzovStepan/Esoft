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
using System.Windows.Shapes;

namespace Esoft
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Coefficients : Window
    {
        public int id = -1;

        public Coefficients()
        {
           
            InitializeComponent();
        }

        public void ForTest(string temp)
        {
            Test.Text = temp;
        }

        public void TestHandler(object sender, RoutedEventArgs a)
        {
            MessageBox.Show("Тест: " + id.ToString());
        }
    }
}
