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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (usuario.Text == "" || senha.Text == "") {
                MessageBox.Show("Preencha todos os campos");
            }
            if (usuario.Text=="adim"&& senha.Text=="adim")
            {
                
            }
        }
        Negocio.Usuario negocioUsuario = new Negocio.Usuario();
        Modelo.Usuario modeloUsuario = new Modelo.Usuario();
        Modelo.Acesso modeloAcesso = new Modelo.Acesso();
        Negocio.Acessos negocioAcesso = new Negocio.Acessos();

        LogUsuario admJanela = new LogUsuario();
        WindowUsuario userJanela = new WindowUsuario();

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {

            var idAcesso = 0;

            string nome = txtLogin.Text;
            string senha = Persistencia.Criptografia.MD5Hash(txtSenha.Password.ToString());

            var adminStatus = negocioUsuario.Select().Where(person => person.Nome == nome && person.Senha == senha).Single().Admin;
            var idUser = negocioUsuario.Select().Where(person => person.Nome == nome && person.Senha == senha).Single().Id;

            try
            {
                idAcesso = negocioAcesso.Select().OrderBy(a => a.Id).OrderByDescending(x => x.Id).Take(1).Single().Id;
            }
            catch (InvalidOperationException)
            {
                idAcesso = 1;
            }
            modeloUsuario.Nome = nome;
            modeloUsuario.Senha = senha;

            try
            {
                if (adminStatus == true)
                {
                    admJanela.ShowDialog();
                }
                else if (adminStatus == false)
                {
                    userJanela.ShowDialog();

                    modeloAcesso.Id = idAcesso;
                    modeloAcesso.IdUsuario = modeloUsuario.Id;
                    modeloAcesso.Data = DateTime.Now;
                    negocioAcesso.Insert(modeloAcesso);

                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("usuario nao cadastrado!");
            }
        }
    }
}