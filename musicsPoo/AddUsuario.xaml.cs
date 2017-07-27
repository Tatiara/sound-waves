using System.Windows;
namespace View
{
    public partial class AddUsuario : Window
    {
        public AddUsuario()
        {
            InitializeComponent();
        }

        Negocio.Usuario addUser = new Negocio.Usuario();
        Modelo.Usuario modelUser = new Modelo.Usuario();

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                modelUser.Nome = textCadastroLogin.Text;
                modelUser.Senha = textCadastroLoginSenha.Password;
                addUser.Insert(modelUser);
            }
            catch (System.ArgumentNullException) { }
            catch (System.InvalidOperationException) { }
        }
        
        private void Canccelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    
        private void SairClick(object sender, RoutedEventArgs e)
        {

        }

        private void AdminUserComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
