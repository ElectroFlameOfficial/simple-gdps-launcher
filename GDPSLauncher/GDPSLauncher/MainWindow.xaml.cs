using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GDPSLauncher
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                PostRequest Request = new PostRequest();
                //change the url to your
                string GetTop = Request.POST("http://example.com/database/getGJScores.php", "gameVersion=21&binaryVersion=35&gdw=0&udid=S15213841620718139357824138723181161001&uuid=11&type=top&count=100&secret=Wmfd2893gb7");
                string[] topPlayer = GetTop.Split(new char[] { '|' });
                for (int i = 0; i != topPlayer.Length; i++)
                {
                    StackPanel SPanel = new StackPanel();
                    Label Stars = new Label();
                    Label UserCoins = new Label();
                    Label Demons = new Label();
                    Label CPs = new Label();
                    Label PlayerName = new Label();
                    Label StarsCount = new Label();
                    Label TopNumber = new Label();
                    Label DemonsCount = new Label();
                    Label CoinCount = new Label();
                    Label UserCoinCount = new Label();
                    Label CpCount = new Label();
                    PlayerName.Foreground = new SolidColorBrush(Colors.White);
                    UserCoinCount.Foreground = new SolidColorBrush(Colors.White);
                    UserCoins.Foreground = new SolidColorBrush(Colors.White);
                    StarsCount.Foreground = new SolidColorBrush(Colors.White);
                    Stars.Foreground = new SolidColorBrush(Colors.White);
                    TopNumber.Foreground = new SolidColorBrush(Colors.White);
                    DemonsCount.Foreground = new SolidColorBrush(Colors.White);
                    Demons.Foreground = new SolidColorBrush(Colors.White);
                    CpCount.Foreground = new SolidColorBrush(Colors.White);
                    CPs.Foreground = new SolidColorBrush(Colors.White);
                    String[] Playerdata;
                    Playerdata = topPlayer[i].Split(new char[] { ':' });
                    PlayerName.Content = Playerdata[1] + "  |";
                    StarsCount.Content = Playerdata[23];
                    Stars.Content = "Stars:";
                    DemonsCount.Content = Playerdata[27];
                    Demons.Content = "Demons:";
                    UserCoinCount.Content = Playerdata[7];
                    UserCoins.Content = "User Coins:";
                    CpCount.Content = Playerdata[25];
                    CPs.Content = "Creator Points:";
                    TopNumber.Content = i + 1;
                    SPanel.Orientation = Orientation.Horizontal;
                    SPanel.Children.Add(TopNumber);
                    SPanel.Children.Add(PlayerName);
                    SPanel.Children.Add(Stars);
                    SPanel.Children.Add(StarsCount);
                    SPanel.Children.Add(Demons);
                    SPanel.Children.Add(DemonsCount);
                    SPanel.Children.Add(UserCoins);
                    SPanel.Children.Add(UserCoinCount);
                    if (Playerdata[25] != "0")
                    {
                        SPanel.Children.Add(CPs);
                        SPanel.Children.Add(CpCount);
                    }
                    TopList.Items.Add(SPanel);
                }
            }
            catch
            {
            }
        }
        public void Game_Click(object sender, RoutedEventArgs e)
        {
            //change the path to your
            string dir = "C:\\Games\\GDPS\\";
            //change the exe name to your
            if (File.Exists(dir + "GeometryDash.exe"))
            {
                Directory.SetCurrentDirectory(dir);
                //change the exe name to your
                Process.Start("GeometryDash.exe");
            }
            else if (Directory.Exists(dir))
            {
                Directory.SetCurrentDirectory(dir);
                //change the exe name to your
                Process.Start("GeometryDash.exe");
            }
            else
            {
                game.IsEnabled = false;
                game.Content = "Downloading GDPS";
                string message = "GDPS was not installed on your PC. After clicking on the \"OK\" button, downloading will begin";
                string caption = "Error!";
                MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
                Download Download = new Download();
                Download.Show();
            }
        }
        public void SongAddButton_Click(object sender, RoutedEventArgs e)
        {
            SongAdd SongAddWindow = new SongAdd();
            SongAddWindow.Show();
        }
    }
}
