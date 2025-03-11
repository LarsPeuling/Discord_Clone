using System;
using System.Collections.Generic;
using System.Linq;
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
using Discord_Clone.Forms.CreateServer;

namespace Discord_Clone.Forms
{
    /// <summary>
    /// Interaction logic for CreateServerPage.xaml
    /// </summary>
    public partial class CreateServerPage : Page
    {
        CreateServerWindow csw = new CreateServerWindow();
        public CreateServerPage()
        {
            InitializeComponent();
        }

        private void btnCreateServer_Click(object sender, RoutedEventArgs e)
        {
            CreateServerName createServerName = new CreateServerName();
            createServerName.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
            csw.CreateServerFrame.Navigate(createServerName);
            
        }
    }
}
