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

namespace View
{
    /// <summary>
    /// Lógica interna para LognAdmin.xaml
    /// </summary>
    public partial class LognAdmin : Window
    {
        public LognAdmin()
        {
            InitializeComponent();
        }

        View.Admin admin = new View.Admin();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            admin.Show();
            Close();
        }
    }
}
