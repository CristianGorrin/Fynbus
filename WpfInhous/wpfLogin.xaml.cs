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
using System.ServiceModel;

namespace WpfInhous
{
    /// <summary>
    /// Interaction logic for wpfLogin.xaml
    /// </summary>
    public partial class wpfLogin : Window
    {
        private string token;

        public wpfLogin()
        {
            InitializeComponent();
            this.OK = false;
        }


        public string Acc { get { return this.txtAcc.Text; } }
        public string Pass { get { return this.pasPass.Password; } }
        public string Token { get { return this.token; } }
        public bool OK { get; private set; }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var login = new ServiceLogin.LoginClient("NetTcpBinding_ILogin");

                this.token = login.LoginServices(this.txtAcc.Text, this.pasPass.Password);

                if (token.Length != 450)
                {
                    MessageBox.Show(token);
                }
                else
                {
                    login.Close();
                    this.OK = true;
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kan ikke login...");
            }
        }
    }
}
