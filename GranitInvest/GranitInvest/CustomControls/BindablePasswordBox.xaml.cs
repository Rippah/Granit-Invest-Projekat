using System.Security;
using System.Windows;


namespace GranitInvest.CustomControls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox
    {
        
        public static readonly DependencyProperty PasswordProperty = 
            DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox));

        public SecureString Password { get => (SecureString)GetValue(PasswordProperty); set => SetValue(PasswordProperty, value); }

        public BindablePasswordBox()
        {
            InitializeComponent();
            TxtPassword.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = TxtPassword.SecurePassword;
        }
    }
}
