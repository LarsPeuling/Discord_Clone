using Discord_Clone.Models;
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

namespace Discord_Clone.Forms.Templates
{
    /// <summary>
    /// Interaction logic for PageTemplate.xaml
    /// </summary>
    public partial class PageTemplate : UserControl
    {
        public PageTemplate(string servername)
        {
            InitializeComponent();
            tbServerName.Text = servername;
            cbChannelList.Items.Add("general");
            var participantList = new List<Participant>();
            foreach (var participant in participantList)
            {
                lbParticipants.Items.Add(participant);
            }
        }

        private void cbChannelList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
