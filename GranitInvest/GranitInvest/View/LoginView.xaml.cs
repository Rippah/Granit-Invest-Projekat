using System.Windows;
using System.Windows.Input;
using GranitInvest.Model;
using GranitInvest.Repository;
using GranitInvest.View;
using GranitInvest.ViewModel;
using TravelAgency.Model;

namespace GranitInvest.VIew
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private protected UserRepository UserRepository = new UserRepository();
        private protected LoginViewModel LoginViewModel = new LoginViewModel();
        private protected RegistrationView RegistrationView = new RegistrationView();

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUser.Text))
            {
                TxtError.Text = "You haven't entered the username.";
                TxtUser.Focus();
            }

            else if (string.IsNullOrEmpty(TxtPassword.Password.ToString()))
            {
                TxtError.Text = "You haven't entered the password.";
                TxtPassword.Focus();
            }

            else
            {
                var username = TxtUser.Text;
                var password = TxtPassword.Password;

                if (username.Length < 3 || password.Length < 3)
                {
                    TxtError.Text = "Username or password is too short.";
                }
                else
                {
                    TxtError.Text = "";
                    IUserRepository userRepository = new UserRepository();
                    var isValid = userRepository.AuthenticateUser(new System.Net.NetworkCredential(username, password));
                    if (isValid)
                    {
                        CurrentUser.Id = userRepository.GetByUsername(username).Id;
                        CurrentUser.Username = username;
                        CurrentUser.DisplayName = userRepository.GetByUsername(username).Name;

                        var gatheringsView = new GatheringsView();
                        gatheringsView.Show();
                        Close();
                    }
                    else
                    {
                        TxtError.Text = "Incorrect username or password.";
                    }
                }
            }
        }

        private void ButtonRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            RegistrationView.Show();
            Close();
        }
    }
}
