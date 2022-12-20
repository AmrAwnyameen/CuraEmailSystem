using EmailServices.Hubs;
using EmailServices.Models;
using Services.InterFaces.ICoreService.IUser;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmailServices.Helpers.Hub
{
    public class HupRepository
    {

        #region Ctor
        readonly string _connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private readonly IUserService _userService;
        #endregion
        #region Services
        public HupRepository(IUserService userService)
        {
            _userService = userService;
        }
        public IEnumerable<Messages> GetAllMessages()
        {
            var cuurentUser = _userService.FirstOrDefault(s => s.Email.Equals(System.Web.HttpContext.Current.User.Identity.Name));
            var messages = new List<Messages>();
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();
                //   [Id],[Date],[Content],[Subject] FROM[Inbox].[MailInbox] where[ToUserId] = '{cuurentUser.Id}' and MailTypeId = 2", connection))
                using (var command = new SqlCommand($@"SELECT
                        [Id],[Date],[Content],[Subject] FROM [Inbox].[MailInbox] where [ToUserId] = '{cuurentUser.Id}' and MailTypeId =2", connection))
                {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        messages.Add(item:
                            new Messages
                            {
                                MessageID = 1,
                                Message = "",
                                EmptyMessage = "",
                                MessageDate = DateTime.Now
                            });
                    }
                }

            }
            return messages;


        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                MessagesHub.SendMessages();
            }
        }
        #endregion

    }
}