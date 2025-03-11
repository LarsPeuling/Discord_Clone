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
using Discord_Clone.Models;
using Discord_Clone.Forms.Templates;

namespace Discord_Clone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Dictionary<string, UserControl> generatedPages = new Dictionary<string, UserControl>();
        public MainWindow()
        {
            InitializeComponent();
            //ServerFrame.Navigate(new ServerPage());
            ButtonManager.OnNewButtonCreated += AddButton;
        }

        private void AddButton(string btnname)
        {
            generatedPages[btnname] = new PageTemplate(btnname);

            Button btn = new Button
            {
                Content = btnname,
                Width = 48,
                Height = 48
            };

            btn.Click += (s, e) => ServerFrame.Content = generatedPages[btnname];
       
            ButtonContainer.Children.Add(btn);
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
            //this.Close();

        }
    }
}