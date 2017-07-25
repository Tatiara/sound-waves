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
    /// Lógica interna para WindowUsuario.xaml
    /// </summary>
    public partial class WindowUsuario : Window
    {
        public WindowUsuario()
        
        {
            InitializeComponent();

            optionsComboBOX();

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

        private void optionsComboBOX()
        {
            userPesquisaContatoComboBox.Items.Add("Escolher");
            userPesquisaContatoComboBox.Items.Add("Nome da música");
            userPesquisaContatoComboBox.Items.Add("Cantor");
            userPesquisaContatoComboBox.SelectedItem = "Escolher";
        }

        private void SairClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addContatoClick(object sender, RoutedEventArgs e)//musica
        {
            // adicionar
        }

        private void userPesquisaContatoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // comboBox userPesquisaContato
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // pesquisar contato
        }
    }
}
