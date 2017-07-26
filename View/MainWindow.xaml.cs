using System.Windows;
using System.Windows.Controls;
using Persistencia;

namespace musicsPoo
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

        Modelo.Usuario modeloUser = new Modelo.Usuario();
        Negocio.Usuario negocioUser = new Negocio.Usuario();
        Modelo.Acesso modeloAcesso = new Modelo.Acesso();
        Negocio.Acessos negocioAcessos = new Negocio.Acessos();

        View.Admin Admin = new View.Admin();
        View.AddMusica Mus = new View.AddMusica();
        
        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            int idAcesso;
            
            if (modeloUser.Admin == true)
            {
                Admin.Show();
                Close();
            }
            else if(modeloUser.Admin == false)
            {
                if (negocioUser.Find(modeloUser.Id) != null)
                {
                    Mus.Show();
                    Close();
                }
                else
                    MessageBox.Show("Usuário ou Senha Inválidos");
            }
            
           
        }

        protected void Usuario_(object sender, TextChangedEventArgs e)
        {

        }

        public void EntradaLogin()
        {
            modeloUser.Id = 1;
            modeloUser.Nome = "user";
            modeloUser.Senha = Persistencia.Criptografia.MD5Hash("123");
            modeloUser.Admin = true;
            negocioUser.Insert(modeloUser);
        }
    }
}
