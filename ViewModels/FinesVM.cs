using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class FinesVM : AllViewModel<FinesForView>
    {
        public override void Add()
        {

            var addNewFineWindow = new AddNewFine();
            var addNewFineVM = (AddNewFineVM) addNewFineWindow.DataContext;
            addNewFineWindow.ShowDialog();

            Load();
        }

        public override void Load()
        {
            List = new ObservableCollection<FinesForView>(
               from fine in libraryEntities.Fines
               select new FinesForView
               {
                   FineID = fine.FineID,
                   TransactionID = fine.TransactionID,
                   FineAmount = fine.Amount,
                   PaidDate = fine.PaidDate,
                   FineStatusName = fine.FineStatuses.FineStatusName
               });
        }
    }
}
