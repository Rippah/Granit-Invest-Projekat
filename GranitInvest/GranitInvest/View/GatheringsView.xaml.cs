using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using GranitInvest.Repository;
using GranitInvest.VIew;

namespace GranitInvest.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class GatheringsView
    {

        private readonly GatheringsRepository _gatheringsRepository = new GatheringsRepository();

        public GatheringsView()
        {
            InitializeComponent();
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
            throw new NotImplementedException();
        }

        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            var drv = (DataRowView)MainDataGrid.SelectedItem;
            var link = _gatheringsRepository.GetByName(drv["Name"].ToString()).Link;
            Process.Start(link);
        }

        private void LogOut_OnClick(object sender, RoutedEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            Close();
        }
    }
}