using System;
using System.Collections.Generic;
using System.IO;
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
using System.IO.Compression;
using System.ComponentModel;
using System.Threading;
using System.IO.Packaging;

namespace GDPSLauncher
{
    public partial class Download : Window
    {
        //change the url name to your. Important! The archive should contain the game folder, and already in this folder the files, in no other way
        private readonly string url = "http://example.com/download/GDPS.zip";
        public Download()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, CancelEventArgs e) => e.Cancel = true;
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) { try { this.DragMove(); } catch { } }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //change the path name to your
            if (!Directory.Exists("C:\\Games"))
                //change the path name to your
                Directory.CreateDirectory("C:\\Games");
                WebClient wc = new WebClient();
                wc.DownloadProgressChanged += ProgressChanged;
                wc.DownloadFileCompleted += ZipEncoder;
            try
            {
                //change the path name to your. DON'T EDIT A temp!!!!
                wc.DownloadFileAsync(new Uri(url), "C:\\Games\\temp");
            }
            catch
            {
                MessageBox.Show("We were unable to start downloading GDPS. Most likely there is no internet connection", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(2);
            }
        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (ProgressBar.Value != e.ProgressPercentage)
            {
                ProgressBar.Value = e.ProgressPercentage;
                ProgressLabel.Content = "Downloading GDPS: " + ProgressBar.Value + "%";
            }
        }
        private void ZipEncoder(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error downloading GDPS: " + e.Error + ". Restart application.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(3);
                return;
            }
            if (e.Cancelled)
            {
                MessageBox.Show("Cancel user download", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(4);
                return;
            }
            //change the path name to your. DON'T EDIT A temp!!!!
            if (!File.Exists("C:\\Games\\temp"))
                return;
            new Thread(zip).Start();
        }
        private void zip()
        {
            //change the path name to your. DON'T EDIT A temp!!!!
            if (!File.Exists("C:\\Games\\temp"))
                return;
            this.Dispatcher.Invoke((Action)(() =>
            {
                ProgressLabel.Content = "Unpacking GDPS...";
            }));
            //change the path name to your. DON'T EDIT A temp!!!!
            ZipFile.ExtractToDirectory("C:\\Games\\temp", "C:\\Games");
            //change the path name to your. DON'T EDIT A temp!!!!
            File.Delete("C:\\Games\\temp");
            MessageBox.Show("GDPS download has been completed successfully!", "Completed!", MessageBoxButton.OK, MessageBoxImage.Information);
            Environment.Exit(0);
        }
    }
}
