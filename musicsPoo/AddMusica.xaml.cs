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
    public partial class AddMusica : Window
    {
        public AddMusica()
        {
            InitializeComponent();
        }

        Modelo.Musica modelMusic = new Modelo.Musica();
        Negocio.Musicas negocioMusic = new Negocio.Musicas();

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            var IDultimo = negocioMusic.Select().OrderBy(user => user.Id).OrderByDescending(x => x.Id).Take(1).Single().Id;

            try
            {
                modelMusic.Id = IDultimo + 1;
                modelMusic.Titulo = textTitulo.Text;
                modelMusic.Cantor = textMusic.Text;
                negocioMusic.Insert(modelMusic);
            }
            catch (System.ArgumentNullException) { }
            catch (System.InvalidOperationException) { }
            MessageBox.Show("Música cadastrada!");
        }

        private void Canccelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SairClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}