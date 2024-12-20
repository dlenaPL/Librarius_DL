﻿using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class NotificationsVM : AllViewModel<NotificationsForView>
    {
        public override void Add()
        {

            var addNewNotificationWindow = new AddNewNotification();
            var addNewNotificationVM = (AddNewNotificationVM) addNewNotificationWindow.DataContext;
            addNewNotificationWindow.ShowDialog();

            Load();
        }

        public override void Load()
        {
            List = new ObservableCollection<NotificationsForView>(
               from mes in libraryEntities.Notifications
               select new NotificationsForView
               {
                   NotificationID = mes.NotificationID,
                   BorrowersName = mes.Members.FirstName + " " + mes.Members.LastName,
                   BookTitle = mes.Books.Title,
                   Message = mes.Message,
                   DateSent = mes.DateSent,
                   IsRead = mes.IsRead

               });
        }
    }
}
