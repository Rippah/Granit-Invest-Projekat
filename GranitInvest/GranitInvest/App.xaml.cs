using System.Net;
using System.Windows;
namespace GranitInvest
{
    public partial class App
    {
        private const string DatabasePath = "user_data.sqlite3";
        private const string DriveLink = "https://drive.google.com/uc?export=download&id=1B745Nf1f7t5Orkrtyxrl0jlFnnVrG_w9";

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            using var client = new WebClient();
            client.DownloadFile(DriveLink, DatabasePath);
        }
    }
}
