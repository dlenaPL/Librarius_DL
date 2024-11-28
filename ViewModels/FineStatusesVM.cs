using Librarius_DL.Views;
using System.Collections.ObjectModel;
using System.Linq;
using FineStatuses = Librarius_DL.Models.Entities.FineStatuses;

namespace Librarius_DL.ViewModels
{
    class FineStatusesVM : Utilities.AllViewModel<FineStatuses>
    {
        public override void Load()
        {
            List = new ObservableCollection<FineStatuses>(libraryEntities.FineStatuses.ToList());

        }

        public override void Add()
        {

            var addNewFineStatusWindow = new AddNewFineStatus();
            var addNewFineStatusVM = (AddNewFineStatusVM)addNewFineStatusWindow.DataContext;

            addNewFineStatusWindow.ShowDialog();

            Load();
        }
    }
}
