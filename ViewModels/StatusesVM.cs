using Librarius_DL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Statuses = Librarius_DL.Models.Entities.Statuses;

namespace Librarius_DL.ViewModels
{
    public class StatusesVM : Utilities.AllViewModel<Statuses>
    {

        public override void Load()
        {
            List = new ObservableCollection<Statuses>(libraryEntities.Statuses.ToList());

        }

        public override void Add()
        {

            var addNewStatusWindow = new AddNewStatus();
            var addNewStatusVM = (AddNewStatusVM)addNewStatusWindow.DataContext;

            addNewStatusWindow.ShowDialog();


            Load();
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa") List = new ObservableCollection<Statuses>(List.OrderBy(item => item.StatusName));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<Statuses>(List.Where(item => item.StatusName != null && item.StatusName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
