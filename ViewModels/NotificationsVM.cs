using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System;
using System.Collections.Generic;
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

        public override void Find()
        {
            Load();
            if (FindField == "Tytuł")
                List = new ObservableCollection<NotificationsForView>(List.Where(item => item.BookTitle != null && item.BookTitle.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Użytkownik")
                List = new ObservableCollection<NotificationsForView>(List.Where(item => item.BorrowersName != null && item.BorrowersName.IndexOf(FindTextBox, StringComparison.OrdinalIgnoreCase) >= 0));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Tytuł", "Użytkownik" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Użytkownik", "Wysłano" };
        }

       
        public override void Sort()
        {
            if (SortField == "Użytkownik") List = new ObservableCollection<NotificationsForView>(List.OrderBy(item => item.BorrowersName));
            if (SortField == "Wysłano") List = new ObservableCollection<NotificationsForView>(List.OrderBy(item => item.DateSent));
        }
    }
}
