using Discord_Clone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord_Clone.MVVM.Models;
using Discord_Clone.Models.Server___Channels;
using Discord_Clone.Core;
using System.Windows;

namespace Discord_Clone.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        /* Why I chose an observablecollection instead of a list
         * Use an ObservableCollection<T> when you need data binding and automatic UI updates.
         * Use a List<T> when you don’t need event notifications and just need a basic collection for general-purpose use.
         */
        public ObservableCollection<Message> Messages { get; set; }
        public ObservableCollection<Participant> Participants { get; set; }
        public ObservableCollection<Server> Servers { get; set; }
        public ObservableCollection<Channel> Channels { get; set; }

        

        public Message m = new Message();
        public Participant p = new Participant();
        public Server s = new Server();
        public Channel c = new Channel();

        /* Commands */
        public RelayCommand SendCommand { get; set; }


        
        private Server _selectedServer;

        public Server SelectedServer
        {
            get { return _selectedServer; }
            set 
            { 
                _selectedServer = value;
                OnPropertyChanged(nameof(SelectedServer));

                if(_selectedServer != null)
                {
                    _selectedServer = s.GetServerByServerName(_selectedServer.Name);
                    OnPropertyChanged(nameof(SelectedServer));

                    
                    foreach (var c in c.GetChannelsByServerId(_selectedServer.Id))
                    {
                        Channels.Add(c);
                    }
                    OnPropertyChanged(nameof(Channels));
                }
            }
        }


        private Channel _selectedChannel;

        public Channel SelectedChannel
        {
            get { return _selectedChannel; }
            set 
            { 
                _selectedChannel = value;
                OnPropertyChanged(nameof(SelectedChannel));

                if(_selectedChannel != null)
                {
                    Messages.Clear();
                    foreach (var m in m.GetMessagesByChannelId(_selectedChannel.Id))
                    {
                        Messages.Add(m);
                    }
                    OnPropertyChanged(nameof(Messages));
                }
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            { 
                _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<Message>();
            Participants = new ObservableCollection<Participant>();
            Servers = new ObservableCollection<Server>();
            Channels = new ObservableCollection<Channel>();


            SendCommand = new RelayCommand(o =>
            {
                if(!string.IsNullOrWhiteSpace(Message) && SelectedChannel != null) 
                {
                    Message newM = new Message 
                    {
                        Text = Message,
                        Sender = p.GetParticipant(2),
                        Time = DateTime.Now,
                        IsNativeOrigin = true,
                        FirstMessage = true,
                        ChannelId = SelectedChannel.Id
                    };

                    m.SendMessage(newM);
                    Messages.Clear() ;
                    var newMessages = m.GetMessagesByChannelId(_selectedChannel.Id);
                    foreach (var msg in newMessages)
                    {
                        Messages.Add(msg);
                    }
                    OnPropertyChanged(nameof(Messages));
                }
                if (_selectedChannel == null)
                {
                    return;
                }
                

                Message = "";
                
            });


            foreach (var s in s.GetServers())
            {
                Servers.Add(s);
            }

            /*foreach(var m in m.GetMessagesByChannelId(_selectedChannel.Id))
            {
                Messages.Add(m);
            }*/

            foreach(var p in p.GetParticipants())
            {
                Participants.Add(p);
            }
            
        }

        public void ShowChannels()
        {
            //Find server based on servername, which should be "SelectedServer"
            Server server = s.GetServerByServerName(SelectedServer.Name);
            foreach (var c in c.GetChannelsByServerId(server.Id))
            {
                Channels.Add(c);
            }
        }
    }
}
