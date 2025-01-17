using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class ReservationsVM : AllViewModel<ReservationsForView>
    {
        public override void Add()
        {

            var addNewReservationWindow = new AddNewReservation();
            var addNewReservationVM = (AddNewReservationVM)addNewReservationWindow.DataContext;
            addNewReservationWindow.ShowDialog();

            Load();
        }

        public override void Load()
        {
            List = new ObservableCollection<ReservationsForView>(
               from res in libraryEntities.Reservations
               select new ReservationsForView
               {
                   ReservationID = res.ReservationID,
                   BorrowerName = res.Members.FirstName + " " + res.Members.LastName,
                   BookTitle = res.Books.Title,
                   ReservationDate = res.ReservationDate,
                   StatusName = res.Statuses.StatusName

               });
        }

        public override void Find()
        {
            Load();
            if (FindField == "Status")
                List = new ObservableCollection<ReservationsForView>(List.Where(item => item.StatusName != null && item.StatusName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Tytuł")
                List = new ObservableCollection<ReservationsForView>(List.Where(item => item.BookTitle != null && item.BookTitle.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Użytkownik")
                List = new ObservableCollection<ReservationsForView>(List.Where(item => item.BorrowerName != null && item.BorrowerName.IndexOf(FindTextBox, StringComparison.OrdinalIgnoreCase) >= 0));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Status", "Tytuł", "Użytkownik" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data", "Status", "Tytuł", "Użytkownik" };
        }

        public override void Sort()
        {
            if (SortField == "Data") List = new ObservableCollection<ReservationsForView>(List.OrderBy(item => item.ReservationDate));
            if (SortField == "Status") List = new ObservableCollection<ReservationsForView>(List.OrderBy(item => item.StatusName));
            if (SortField == "Tytuł") List = new ObservableCollection<ReservationsForView>(List.OrderBy(item => item.BookTitle));
            if (SortField == "Użytkownik") List = new ObservableCollection<ReservationsForView>(List.OrderBy(item => item.BorrowerName));
        }
    }
}
