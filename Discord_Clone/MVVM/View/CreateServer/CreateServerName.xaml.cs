using Discord_Clone.MVVM.Models;
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

namespace Discord_Clone.Forms.CreateServer
{
    /// <summary>
    /// Interaction logic for CreateServerName.xaml
    /// </summary>
    public partial class CreateServerName : Page
    {
        ButtonManager btnManager = new ButtonManager();
        public CreateServerName()
        {
            InitializeComponent();
            
        }

        

        private void btnCreateServer_Click(object sender, RoutedEventArgs e)
        {
            ButtonManager.AddButton(tbServerName.Text);
            NavigationService.GoBack();
            
        }
    }
}
