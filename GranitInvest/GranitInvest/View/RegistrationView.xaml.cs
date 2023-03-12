using System.ComponentModel;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using GranitInvest.Model;
using GranitInvest.Repository;
using GranitInvest.VIew;

namespace GranitInvest.View
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonLoginPage_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    loginView.Close();
                }
            };
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (TxtEmail.Text.Length == 0)
            {
                TxtErrorMessage.Text = "* Unesite e-mail.";
                TxtEmail.Focus();
            }
            else if (!Regex.IsMatch(TxtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                TxtErrorMessage.Text = "* Unesite validan e-mail.";
                TxtEmail.Select(0, TxtEmail.Text.Length);
                TxtEmail.Focus();
            }
            else
            {
                string username = TxtUser.Text;
                SecureString password = TxtPassword.Password;
                string name = TxtIme.Text;
                string surname = TxtPrezime.Text;
                string email = TxtEmail.Text;

                if (password == null)
                {
                    TxtErrorMessage.Text = "* Unesite lozinku.";
                    TxtPassword.Focus();
                }
                else if (TxtPasswordConfirm.Password == null)
                {
                    TxtErrorMessage.Text = "* Potvrdite lozinku.";
                    TxtPasswordConfirm.Focus();
                }
                else if (!TxtPassword.Password.ToString().Equals(TxtPasswordConfirm.Password.ToString()))
                {
                    TxtErrorMessage.Text = "* Lozinke nisu iste!";
                    TxtPasswordConfirm.Focus();
                }
                else
                {
                    if (TxtUser.Text.Length == 0)
                    {
                        TxtErrorMessage.Text = "* Unesite korisničko ime";
                        TxtUser.Focus();
                    }
                    else if (username.Length < 3 || password.Length < 3)
                    {
                        TxtErrorMessage.Text = "* Treba Vam veće korisničko ime/lozinka";
                    }
                    else
                    {
                        TxtErrorMessage.Text = "";
                        string pword = new System.Net.NetworkCredential(string.Empty, password).Password;
                        IUserRepository userRepository = new UserRepository();
                        userRepository.Add(new UserModel(1, username, pword, email, name, surname));
                        LoginView loginView = new LoginView();
                        loginView.Show();
                        loginView.TxtError.Text = "Registracija je uspešna!";
                        loginView.IsVisibleChanged += (s, ev) =>
                        {
                            if (loginView.IsVisible == false && loginView.IsLoaded)
                            {
                                loginView.TxtError.Text = "";
                                var mainView = new MainView();
                                mainView.Show();
                                loginView.Close();
                            }
                        };
                        Close();
                    }
                }
            }
        }
    }
}
