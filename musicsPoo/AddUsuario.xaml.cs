using System.Windows;
using System.Linq;


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
            var IDultimo = addUser.Select().OrderBy(user => user.Id).OrderByDescending(x => x.Id).Take(1).Single().Id;
            
            try
            {
                modelUser.Id = IDultimo + 1;
                modelUser.Nome = textCadastroLogin.Text;
                modelUser.Senha = Persistencia.Criptografia.MD5Hash(textCadastroLoginSenha.Password);
                addUser.Insert(modelUser);
            }
            catch (System.ArgumentNullException) { }
            catch (System.InvalidOperationException) { }
            MessageBox.Show("Usuário Cadastrado!");
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
