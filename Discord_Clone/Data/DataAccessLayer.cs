using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord_Clone.Models;
using Discord_Clone.Models.User___Roles;
using System.Windows.Documents;
using Discord_Clone.Models.Server___Channels;

namespace Discord_Clone.Data
{
    public class DataAccessLayer
    {

        public string conString = "Data Source=.;Initial Catalog=Discord_Clone;Integrated Security=True;TrustServerCertificate=True";
        
        public SqlConnection cnn;
        public DataAccessLayer()
        {
            SqlConnection sqlConnection = new SqlConnection(conString);
        }

        public List<Participant> GetParticipants()
        {
            List<Participant> participants = new List<Participant>();

            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "SELECT * FROM Participant";

                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Participant p = new Participant(); 
                        p.Id = reader.GetInt32(0);

                        var pUser = GetUserById(p.Id);  
                        if (pUser != null)
                        {
                            p.User = pUser;
                            p.UserName = pUser.Name;
                        }

                        var pRole = GetRoleByParticipantId(p.Id);  
                        if (pRole != null)
                        {
                            p.Role = pRole;
                        }

                        participants.Add(p);  
                    }
                }
            }

            return participants;
        }

        public Participant GetParticipant(int id)
        {
            Participant p = new Participant();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = $"select * from Participant where Id = {id}";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        p.Id = reader.GetInt32(0);
                        var u = GetUsers();
                        p.User = u.Find(x => x.Id == p.Id);

                        var r = GetRoles();
                        p.Role = r.Find(x => x.Id == p.Id);

                    }
                }
                return p;

            }
        }

        public User GetUserById(int userId)
        {
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "SELECT * FROM [User] WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@Id", userId);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = userId,
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Avatar = reader.GetString(3),
                            Status = reader.GetString(4),

                            Friends = GetFriendsOnUserId(userId),

                            Tag = reader.GetString(6)
                        };
                    }
                }
            }
            return null;
        }

       /* public User GetUserById(int id) 
        { 
            User u = new User();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = $"select * from [User] where Id = {id}";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        u.Id = reader.GetInt32(0);
                        u.Name = reader.GetString(1);
                        u.Email = reader.GetString(2);
                        u.Avatar = reader.GetString(3);
                        u.Status = reader.GetString(4);

                        u.Friends = GetFriendsOnUserId(u.Id);

                        u.Tag = reader.GetString(6);
                    }
                    return u;
                }
            }
        }*/

        public List<User> GetUsers()
        {
            List<User> list = new List<User>();
            User u = new User();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "select * from [User]";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        u.Id = reader.GetInt32(0);
                        u.Name = reader.GetString(1);
                        u.Email = reader.GetString(2);
                        u.Avatar = reader.GetString(3);
                        u.Status = reader.GetString(4);

                        u.Friends = GetFriendsOnUserId(u.Id);

                        u.Tag = reader.GetString(6);

                        
                    }
                    list.Add(u);
                }
                return list ;

            }
        }



        public List<User> GetFriendsOnUserId(int userId)
        {
            User f = new User();
            List<User> list = new List<User>();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = $"select * from [User] where Id = {userId} ";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        f.Id = reader.GetInt32(0);
                        f.Name = reader.GetString(1);
                        f.Avatar = reader.GetString(3);
                        f.Status = reader.GetString(4);
                        f.Tag = reader.GetString(6);

                    }


                }
                list.Add(f);
                return list;
            }
        }

        public Role GetRoleByParticipantId(int participantId)
        {
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "SELECT Role.* FROM Role " +
                               "JOIN ParticipantRole ON Role.Id = ParticipantRole.RoleId " +
                               "WHERE ParticipantRole.ParticipantId = @ParticipantId";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@ParticipantId", participantId);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Role
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Color = reader.GetString(2),
                            ViewChannel = reader.GetBoolean(3),
                            ManageChannel = reader.GetBoolean(4),
                            ManageRole = reader.GetBoolean(5),
                            ViewAuditLog = reader.GetBoolean(6),
                            ManageServer = reader.GetBoolean(7),
                            CreateInvite = reader.GetBoolean(8),
                            ChangeNickname = reader.GetBoolean(9),
                            ManageNickname = reader.GetBoolean(10),
                            KickMember = reader.GetBoolean(11),
                            BanMember = reader.GetBoolean(12),
                            MentionAllRole = reader.GetBoolean(13),
                            ManageMessage = reader.GetBoolean(14)
                        };
                    }
                }
            }
            return null;
        }

        public Role GetRoleByRoleId(int roleId) 
        {
            Role r = new Role();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = $"select * from Role where Id = {roleId}";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        r.Id = reader.GetInt32(0);
                        r.Name = reader.GetString(1);
                        r.Color = reader.GetString(2);
                        r.ViewChannel = reader.GetBoolean(3);
                        r.ManageChannel = reader.GetBoolean(4);
                        r.ManageRole = reader.GetBoolean(5);
                        r.ViewAuditLog = reader.GetBoolean(6);
                        r.ManageServer = reader.GetBoolean(7);
                        r.CreateInvite = reader.GetBoolean(8);
                        r.ChangeNickname = reader.GetBoolean(9);
                        r.ManageNickname = reader.GetBoolean(10);
                        r.KickMember = reader.GetBoolean(11);
                        r.BanMember = reader.GetBoolean(12);
                        r.MentionAllRole = reader.GetBoolean(13);
                        r.ManageMessage = reader.GetBoolean(14);
                    }
                    return r;

                }
            }
        }

        /*public Role GetRoleByParticipantId(int participantId)
        {
            Role r = new Role();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = $"select * from ParticipantRole where ParticipantId = {participantId}";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        r.Id = reader.GetInt32(0);
                        r.Name = reader.GetString(1);
                        r.Color = reader.GetString(2);
                        r.ViewChannel = reader.GetBoolean(3);
                        r.ManageChannel = reader.GetBoolean(4);
                        r.ManageRole = reader.GetBoolean(5);
                        r.ViewAuditLog = reader.GetBoolean(6);
                        r.ManageServer = reader.GetBoolean(7);
                        r.CreateInvite = reader.GetBoolean(8);
                        r.ChangeNickname = reader.GetBoolean(9);
                        r.ManageNickname = reader.GetBoolean(10);
                        r.KickMember = reader.GetBoolean(11);
                        r.BanMember = reader.GetBoolean(12);
                        r.MentionAllRole = reader.GetBoolean(13);
                        r.ManageMessage = reader.GetBoolean(14);
                    }
                    return r;

                }
            }
        }*/

        public List<Role> GetRoles()
        {
            Role r = new Role();
            List<Role> list = new List<Role>();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "select * from Role";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        r.Id = reader.GetInt32(0);
                        r.Name = reader.GetString(1);
                        r.Color = reader.GetString(2);
                        r.ViewChannel = reader.GetBoolean(3);
                        r.ManageChannel = reader.GetBoolean(4);
                        r.ManageRole = reader.GetBoolean(5);
                        r.ViewAuditLog = reader.GetBoolean(6);
                        r.ManageServer = reader.GetBoolean(7);
                        r.CreateInvite = reader.GetBoolean(8);
                        r.ChangeNickname = reader.GetBoolean(9);
                        r.ManageNickname = reader.GetBoolean(10);
                        r.KickMember = reader.GetBoolean(11);
                        r.BanMember = reader.GetBoolean(12);
                        r.MentionAllRole = reader.GetBoolean(13);
                        r.ManageMessage = reader.GetBoolean(14);
                    }


                }
                list.Add(r);
                return list;
            }
        }

        public List<Message> GetMessagesByChannelId(int ChannelId)
        {
           
            List<Message> list = new List<Message>();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "select * from Message where ChannelId = @channelId";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@channelId", ChannelId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Message m = new Message();
                        m.Id = reader.GetInt32(0);
                        m.Text = reader.GetString(1);
                        
                        int pId = reader.GetInt32(2);
                        m.Sender = GetParticipant(pId);
                        
                        m.Time = reader.GetDateTime(3);
                        m.IsNativeOrigin = reader.GetBoolean(4);
                        m.FirstMessage = reader.GetBoolean(5);
                        m.ChannelId = reader.GetInt32(6);
                        list.Add(m);
                    }


                }
                
                return list;
            }
        }

        public void SendMessage(Message message)
        {
            using (SqlConnection cnn = new SqlConnection(conString)) 
            {
                cnn.Open();
                string query = "insert into Message (Text, ParticipantId, Time, IsNativeOrigin, FirstMessage, ChannelId) " +
                    "values (@text, @participantId, @time, @isNativeOrigin, @firstMessage, @channelId)";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@text",message.Text);
                    cmd.Parameters.AddWithValue("@participantId",message.Sender.Id);
                    cmd.Parameters.AddWithValue("@time",message.Time);
                    cmd.Parameters.AddWithValue("@isNativeOrigin",message.IsNativeOrigin);
                    cmd.Parameters.AddWithValue("@firstMessage",message.FirstMessage);
                    cmd.Parameters.AddWithValue("@channelId",message.ChannelId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Server GetServerByServerName(string serverName)
        {
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "select * from Server where Name = @name";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", serverName);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Server
                        {
                            Id = reader.GetInt32(0),
                            Name = serverName,
                            Channels = GetChannelsByServerId(reader.GetInt32(0))
                        };
                    }
                }
            }
            return null;
        }


        public List<Server> GetServers()
        {
            List<Server> list = new List<Server>();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "select * from Server";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Server s = new Server();
                        s.Id = reader.GetInt32(0);
                        s.Name = reader.GetString(1);
                        s.Channels = GetChannelsByServerId(s.Id);


                        list.Add(s);
                    }


                }
                
                return list;
            }
        }

        public List<Channel> GetChannelsByServerId(int serverId)
        {
            List<Channel> list = new List<Channel>();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "select * from Channel where ServerId = @serverId";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@serverId", serverId);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Channel c = new Channel();
                        c.Id = reader.GetInt32(0);
                        c.Name = reader.GetString(1);
                        c.Description = reader.GetString(3);

                        list.Add(c);
                    }
                    return list;
                }
            }
        }


        /*public List<Channel> GetChannels()
        {
            List<Channel> list = new List<Channel>();
            using (SqlConnection cnn = new SqlConnection(conString))
            {
                cnn.Open();
                string query = "select * from channel";
            }
        }*/
    }
}
