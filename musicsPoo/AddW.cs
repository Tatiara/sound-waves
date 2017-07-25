using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;


namespace musicsPoo
{
    /// <summary>
    /// Lógica interna para LogUsuario.xaml
    /// </summary>
    public partial class LogUsuario : Window //admWindowns
    {
        public LogUsuario()
        {
            InitializeComponent(); updateGrid();
            InitializeWindow();

            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }

        public void InitializeWindow()
        {
            admLoginLabelEditar.Visibility = System.Windows.Visibility.Collapsed;
            admSenhaLabelEditar.Visibility = System.Windows.Visibility.Collapsed;
            admAddLabelEditar.Visibility = System.Windows.Visibility.Collapsed;
            textLoginEditar.Visibility = System.Windows.Visibility.Collapsed;
            textSenhaEditar.Visibility = System.Windows.Visibility.Collapsed;
            admUserComboBoxEditar.Visibility = System.Windows.Visibility.Collapsed;
            btn_Atualizar.Visibility = System.Windows.Visibility.Collapsed;
            btn_Fechar.Visibility = System.Windows.Visibility.Collapsed;
            gridVisualizacaoAdm.Margin = new Thickness(20, 20, 20, 20);
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

        public void updateGrid()
        {
            gridVisualizacaoAdm.ItemsSource = null;
            gridVisualizacaoAdm.ItemsSource = negocioUsuario.Select();
            DataContext = this;
        }

        Negocio.Usuario negocioUsuario = new Negocio.Usuario();
        Modelo.Usuario modeloUsuario = new Modelo.Usuario();
        AddUsuario adicionarUser = new AddUsuario();
        Window1 acessosLog = new Window1(); //windowacesso



        private void AcessosClick(object sender, RoutedEventArgs e)
        {
            acessosLog.ShowDialog();
        }

        private void AdicionarClick(object sender, RoutedEventArgs e)
        {
            adicionarUser.ShowDialog();
        }

        private void SairClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            updateGrid();
        }

        private void ApagarUsuarioClick(object sender, RoutedEventArgs e)
        {
            modeloUsuario = gridVisualizacaoAdm.SelectedItem as Modelo.Usuario;

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja realmente DELETAR esse usuário?", "Confirmação", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                negocioUsuario.Delete(modeloUsuario);
            }

            updateGrid();
        }

        private void EditarUsuarioClick(object sender, RoutedEventArgs e)
        {
            /*
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja realmente EDITAR esse usuário?", 
               "Confirmação", System.Windows.MessageBoxButton.YesNo);

            modeloUsuario = gridVisualizacaoAdm.SelectedItem as Model.Usuario;
            int idUser = modeloUsuario.Id;
            */

            admLoginLabelEditar.Visibility = System.Windows.Visibility.Visible;
            admSenhaLabelEditar.Visibility = System.Windows.Visibility.Visible;
            admAddLabelEditar.Visibility = System.Windows.Visibility.Visible;
            textLoginEditar.Visibility = System.Windows.Visibility.Visible;
            textSenhaEditar.Visibility = System.Windows.Visibility.Visible;
            admUserComboBoxEditar.Visibility = System.Windows.Visibility.Visible;
            btn_Atualizar.Visibility = System.Windows.Visibility.Visible;
            btn_Fechar.Visibility = System.Windows.Visibility.Visible;
            gridVisualizacaoAdm.Margin = new Thickness(20, 20, 20, 20);

        }
    }
}
