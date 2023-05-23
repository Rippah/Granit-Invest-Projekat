using GranitInvest.Repository;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using GranitInvest.Model;

namespace GranitInvest.View
{
    public partial class AddGatheringsView
    {
        public AddGatheringsView()
        {
            InitializeComponent();
            TxtName.Focus();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void ButtonReturnToGatheringsView_OnClick(object sender, RoutedEventArgs e)
        {
            var gatheringsView = new GatheringsView();
            gatheringsView.Show();
            Close();
        }

        protected virtual bool IsValidUrl(string url)
        {
            const string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            var rgx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rgx.IsMatch(url);
        }

        private bool AuthenticateFinalization()
        {
            if (TxtName.Text.Length < 3)
            {
                TxtErrorMessage.Text = "Unesite odgovarajući naziv.";
                TxtName.Focus();
                return false;
            }

            if (!IsValidUrl(TxtProfile.Text))
            {
                if (TxtProfile.Text.Length == 0)
                    TxtProfile.Text = "/";
                else
                {
                    TxtErrorMessage.Text = "Unesite odgovarajući profil.";
                    TxtProfile.Focus();
                    return false;
                }
            }

            if (!IsValidUrl(TxtLink.Text))
            {
                if (TxtLink.Text.Length == 0)
                    TxtLink.Text = "/";
                else
                {
                    TxtErrorMessage.Text = "Unesite odgovarajući link.";
                    TxtLink.Focus();
                    return false;
                }
            }

            if (TxtDate.Text.Length == 0)
            {
                TxtErrorMessage.Text = "Unesite odgovarajući datum.";
                TxtDate.Focus();
                return false;
            }

            return true;
        }

        private void Finalize_Click(object sender, RoutedEventArgs e)
        {
            if (!AuthenticateFinalization()) return;
            var gatheringsRepository = new GatheringsRepository();
            gatheringsRepository.Add(new Gatherings(TxtName.Text, TxtDesc.Text, TxtDate.Text,  TxtLocation.Text,TxtProfile.Text, TxtLink.Text));
            var gatheringsView = new GatheringsView();
            gatheringsView.Show();
            Close();
        }

        private void AddGatheringsView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                var result = MessageBox.Show("Da li ste sigurni da želite da prekinete unos?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                    ButtonReturnToGatheringsView_OnClick(sender, e);
            }
            if (e.Key == Key.Enter)
                Finalize_Click(sender, e);
            if (e.Key == Key.Tab && TxtLink.IsFocused)
            {
                TxtName.Focus();
                e.Handled = true;
            }
        }
    }
}
