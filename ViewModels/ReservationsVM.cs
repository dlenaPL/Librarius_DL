using Librarius_DL.Utilities;
using Librarius_DL.Views;
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
    }
}
