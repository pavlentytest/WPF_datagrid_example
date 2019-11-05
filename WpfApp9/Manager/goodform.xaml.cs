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

namespace WpfApp9.Manager
{
    /// <summary>
    /// Interaction logic for addgood.xaml
    /// </summary>
    public partial class goodform : Window
    {
        public goodform()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // вернем флажок, для кнопки Ok
            this.DialogResult = true;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            // вернем флажок, со значение false, для кнопки Cancel
            // необходимо для передачи значения в manager
            this.DialogResult = false;
        }
    }
}
