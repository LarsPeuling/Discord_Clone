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
using System.Windows.Shapes;

namespace Discord_Clone.Forms.CreateServer
{
    /// <summary>
    /// Interaction logic for CreateServerWindow.xaml
    /// </summary>
    public partial class CreateServerWindow : Window
    {
        //CreateServerPage csp = new CreateServerPage();
        public CreateServerWindow()
        {
            InitializeComponent();
            CreateServerFrame.Navigate(new CreateServerPage());
        }

        private void CreateServerFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
