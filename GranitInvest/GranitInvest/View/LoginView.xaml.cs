using System.Windows;
using System.Windows.Input;
using GranitInvest.View;

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

        private protected RegistrationView registrationView = new RegistrationView();

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

        }

        private void ButtonRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            registrationView.Show();
            Close();
        }
    }
}
