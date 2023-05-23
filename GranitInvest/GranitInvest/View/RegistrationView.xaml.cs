using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using GranitInvest.Model;
using GranitInvest.Repository;
using GranitInvest.ViewModel;

namespace GranitInvest.View
{
    public partial class RegistrationView
    {
        public RegistrationView()
        {
            InitializeComponent();
            DataContext = new RegisterViewModel();
            TxtUser.Focus();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonGatheringsView_Click(object sender, RoutedEventArgs e)
        {
            var gatheringsView = new GatheringsView();
            gatheringsView.Show();
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
                var username = TxtUser.Text;
                var password = TxtPassword.Password;
                var name = TxtIme.Text;
                var surname = TxtPrezime.Text;
                var email = TxtEmail.Text;

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
                        userRepository.Add(new User(1, username, pword, email, name, surname, true));
                        MessageBox.Show("Registracija je uspešna.");
                        var gatheringsView = new GatheringsView();
                        gatheringsView.Show();
                        Close();
                    }
                }
            }
        }

        private void RegistrationView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
                SignUp_Click(sender, e);
            if (e.Key == Key.F1)
                ButtonGatheringsView_Click(sender, e);
            if (e.Key == Key.Tab && TxtPrezime.IsFocused)
            {
                TxtUser.Focus();
                e.Handled = true;
            }
        }
    }
}
