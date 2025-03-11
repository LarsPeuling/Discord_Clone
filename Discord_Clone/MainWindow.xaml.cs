using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Discord_Clone.Forms;
using Discord_Clone.Forms.CreateServer;

namespace Discord_Clone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ServerFrame.Navigate(new ServerPage());
        }

        
        private void OpenChat(ChatPage chat)
        {
            ChatContent.Visibility = Visibility.Visible;
            ChatContent.Content = chat;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void ServerFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddServer_Click(object sender, RoutedEventArgs e)
        {
            CreateServerWindow csw = new CreateServerWindow();
            csw.Show();
            this.Close();

        }
    }
}