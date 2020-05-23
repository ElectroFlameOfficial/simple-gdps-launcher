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
    public partial class SongAdd : Window
    {
        public SongAdd()
        {
            InitializeComponent();
        }
        public void SongAddButton_Click(object sender, RoutedEventArgs e)
        {
            var getURL = urlBox.Text;
            if (getURL == "")
            {
                songID.Content = "You did not provide a link to the track";
            }
            else
            {
                try
                {
                    PostRequest Request = new PostRequest();
                    //change the url name to your
                    string GetSong = Request.POST("http://example.com/database/launcher/songAdd.php", "url=" + getURL);
                    songID.Content = GetSong;
                }
                catch
                {
                }
            }
        }
    }
}
