using Librarius_DL.Views;
using System.Collections.Generic;
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

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa") List = new ObservableCollection<FineStatuses>(List.OrderBy(item => item.FineStatusName));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<FineStatuses>(List.Where(item => item.FineStatusName != null && item.FineStatusName.StartsWith(FindTextBox)));
        }
    }
}
