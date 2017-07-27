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
using Persistencia;

namespace View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {   

            InitializeComponent();
            EntradaLogin();
        }

        Modelo.Usuario modeloUser;
        Negocio.Usuario negocioUser = new Negocio.Usuario();
        Modelo.Acesso modeloAcesso = new Modelo.Acesso();
        Negocio.Acessos negocioAcessos = new Negocio.Acessos();

        View.Admin Admin = new View.Admin();
        View.AddMusica Mus = new View.AddMusica();
        View.LognAdmin logadm = new View.LognAdmin();
        
        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            int idAcesso;

            string login = usuario.Text; //recebe
            var s = senha.Password;
            Modelo.Usuario modeloUser = new Modelo.Usuario();
            modeloUser.Nome = login; //bd
            modeloUser.Senha = s;

            
            var status = negocioUser.Select().Where(p => p.Nome == login  && p.Senha == s).Single().Admin;
            var idU = negocioUser.Select().Where(p => p.Nome == login && p.Senha == s).Single().Id;

            Mus.Show();
            Close();
           

        }

        protected void Usuario_(object sender, TextChangedEventArgs e)
        {

        }

        public void EntradaLogin()
        {
            if(negocioUser.Select().Count() < 1)
            {
                modeloUser = new Modelo.Usuario();
                modeloUser.Id += 1;
                modeloUser.Nome = "user";
                modeloUser.Senha = Persistencia.Criptografia.MD5Hash("123");
                modeloUser.Admin = true;
                negocioUser.Insert(modeloUser);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            logadm.Show();
            Close();
        }
    }
}
