using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using GranitInvest.Model;
using GranitInvest.Repository;
using GranitInvest.VIew;

namespace GranitInvest.View
{
    public partial class GatheringsView
    {

        private readonly GatheringsRepository _gatheringsRepository = new GatheringsRepository();

        public GatheringsView()
        {
            InitializeComponent();
            if (!CurrentUser.IsAdmin)
            {
                BtnAddGatherings.Visibility = Visibility.Hidden;
                BtnAddUser.Visibility = Visibility.Hidden;
            }
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

        private void AddGatherings_OnClick(object sender, RoutedEventArgs e)
        {
            var addGatheringsView = new AddGatheringsView();
            addGatheringsView.Show();
            Close();
        }

        private void OnProfileClick(object sender, RoutedEventArgs e)
        {
            var drv = (DataRowView)MainDataGrid.SelectedItem;
            var profile = _gatheringsRepository.GetByName(drv["Name"].ToString()).Profile;
            if (profile != "/")
                Process.Start(profile);
            else
                MessageBox.Show("Nemamo link za Instagram!");
        }

        private void OnLinkClick(object sender, RoutedEventArgs e)
        {
            var drv = (DataRowView)MainDataGrid.SelectedItem;
            var link = _gatheringsRepository.GetByName(drv["Name"].ToString()).Link;
            if (link != "/")
                Process.Start(link);
            else
                MessageBox.Show("Nemamo link za učestvovanje!");
        }

        private void LogOut_OnClick(object sender, RoutedEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            Close();
        }

        private void GatheringsView_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
                Contact_OnClick(sender, e);
            if (e.Key == Key.F2)
                LogOut_OnClick(sender, e);
            if (e.Key == Key.F3 && BtnAddGatherings.Visibility != Visibility.Hidden)
                AddGatherings_OnClick(sender, e); 
            if (e.Key == Key.F4 && BtnAddUser.Visibility != Visibility.Hidden)
                AddUser_OnClick(sender, e);
        }

        private void Contact_OnClick(object sender, RoutedEventArgs e)
        {
            var googleFormsUrl = "https://forms.gle/VaH2cuQZ6DUhnCER9"; 
            Process.Start(new ProcessStartInfo(googleFormsUrl));
            e.Handled = true;
        }

        private void AddUser_OnClick(object sender, RoutedEventArgs e)
        {
            var addUser = new RegistrationView();
            addUser.Show();
            Close();
        }
    }
}