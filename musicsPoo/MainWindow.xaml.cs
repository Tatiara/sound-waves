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

        protected void Button_Click(object sender, RoutedEventArgs e)
        {
            if (usuario.Text == "user" && senha.Password == "123")
            {
                AddMusica w = new AddMusica();//prox pasta
                w.Show();
                Close();
            }
            else
                MessageBox.Show("Usuário ou Senha Inválidos");
           
        }

        protected void Usuario_(object sender, TextChangedEventArgs e)
        {

        }

        public void EntradaLogin()
        {
            modeloUser.Id = 1;
            modeloUser.Nome = "Tati";
            modeloUser.Senha = Persistencia.Criptografia.MD5Hash("1502");
            modeloUser.Admin = true;
            negocioUser.Insert(modeloUser);
        }
    }
}
