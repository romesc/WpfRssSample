using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Syndication; // add this
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
using System.Xml;

namespace WpfRssSample
{
    /// <summary>
    /// Interaction logic for Mainwindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // http://www.thomaslevesque.com/2009/02/13/build-an-rss-reader-in-5-minutes/
        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            using (XmlReader reader = XmlReader.Create(txtUrl.Text))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                lstFeedItems.ItemsSource = feed.Items;
            }
        }

        private void frmContents_ContentRendered(object sender, EventArgs e)
        {
            // http://www.rhizohm.net/irhetoric/post/2008/11/12/0a-WPF-WebBrowser-Control-and-the-Document-Object0a-.aspx
            // Add Reference MS HTML Object Library
            if (frmContents.Content.GetType() == typeof(WebBrowser))
            {
                WebBrowser browser = (WebBrowser)frmContents.Content;
                mshtml.HTMLDocument dom = (mshtml.HTMLDocument)browser.Document;
                if (browser == null || browser.Document == null)
                    return;

                dynamic document = browser.Document;

                //if (document.readyState != "complete") // is this needed?
                //    return;

                dynamic script = document.createElement("script");
                script.type = @"text/javascript";
                script.text = @"window.onerror = function(msg,url,line){return true;}";
                document.head.appendChild(script);
            }
        }
    }
}
