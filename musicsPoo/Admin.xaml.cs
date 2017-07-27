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
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        View.AddUsuario user = new View.AddUsuario();
        View.Window1 acesso = new View.Window1();
        View.AddMusica music = new View.AddMusica();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            user.Show();
            Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            acesso.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            music.Show();
            Close();
        }
    }
}
