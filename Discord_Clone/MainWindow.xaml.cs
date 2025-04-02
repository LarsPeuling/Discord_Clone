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
using Discord_Clone.Forms.Templates;
using Discord_Clone.Models;
using Discord_Clone.MVVM.Models;
using Discord_Clone.MVVM.ViewModel;

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
            this.DataContext = new MainViewModel();
            //ServerFrame.Navigate(new ServerPage());
            //ButtonManager.OnNewButtonCreated += AddButton;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Message m = new Message();
        }




        /* private void AddButton(string btnname)
         {
             generatedPages[btnname] = new PageTemplate(btnname);

             Button btn = new Button
             {
                 Content = btnname,
                 Width = 47,
                 Height = 47,
                 Margin = new Thickness(0,2,0,2)
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

         }*/
    }
}