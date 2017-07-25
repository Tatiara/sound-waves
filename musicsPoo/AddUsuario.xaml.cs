using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace musicsPoo
{
    /// <summary>
    /// Lógica interna para AddUsuario.xaml
    /// </summary>
    public partial class AddUsuario : Window
    {
        Negocio.Usuario negocioUsuario = new Negocio.Usuario();
        Modelo.Usuario modeloUsuario = new Modelo.Usuario();

        public AddUsuario()
        {
            InitializeComponent();
            addComboBOX();
            addAdmPrincipal();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        public void addAdmPrincipal()
        {
            try
            {
                modeloUsuario.Id = 1;
                modeloUsuario.Nome = "admin";
                modeloUsuario.Senha = Persistencia.Criptografia.MD5Hash("admin");
                modeloUsuario.Admin = true;
                negocioUsuario.Insert(modeloUsuario);
            }
            catch (ArgumentNullException) { }
            catch (InvalidOperationException) { }
        }

        private void Canccelar_Click(object sender, RoutedEventArgs e)
        {

            Hide();

        }
        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            var IDultimo = negocioUsuario.Select().OrderBy(user => user.Id).OrderByDescending(x => x.Id).Take(1).Single().Id;

            try
            {
                modeloUsuario.Id = IDultimo + 1;
                modeloUsuario.Nome = textCadastroLogin.Text;
                modeloUsuario.Senha = Persistencia.Criptografia.MD5Hash(textCadastroLoginSenha.Text);
                var opcao = admAddUserComboBox.Text;
                modeloUsuario.Admin = Boolean.Parse(opcao);
                negocioUsuario.Insert(modeloUsuario);

                MessageBox.Show("Salvo com sucesso!");

            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Dados nao informados!");
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Usuario ja cadastrado!");
            }
            catch (FormatException)
            {
                MessageBox.Show("o usuario necessita ter status (verdadeiro ou falso) de administrador!!! ");
            }

        }
        private void SairClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }


    }
}
