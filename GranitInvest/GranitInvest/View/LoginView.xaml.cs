using System.Windows;
using System.Windows.Input;
using GranitInvest.Model;
using GranitInvest.Repository;
using GranitInvest.View;
using GranitInvest.ViewModel;

namespace GranitInvest.VIew
{
    public partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            TxtUser.Text = "gost";
            TxtUser.CaretIndex = TxtUser.Text.Length;
            TxtUser.Focus();
        }

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

            else
            {
                var username = TxtUser.Text;
                var password = TxtPassword.Password;

                if (username.Length < 3)
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
                        CurrentUser.IsAdmin = userRepository.GetByUsername(username).IsAdmin;

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

        private void LoginView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BtnLogin_Click(sender, e);
        }
    }
}
