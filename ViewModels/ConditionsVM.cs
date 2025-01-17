using Librarius_DL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Conditions = Librarius_DL.Models.Entities.Conditions;

namespace Librarius_DL.ViewModels
{
    class ConditionsVM : Utilities.AllViewModel<Conditions>
    {
        public override void Load()
        {
            List = new ObservableCollection<Conditions>(libraryEntities.Conditions.ToList());

        }

        public override void Add()
        {

            var addNewConditionWindow = new AddNewCondition();
            var addNewConditionVM = (AddNewConditionVM)addNewConditionWindow.DataContext;

            addNewConditionWindow.ShowDialog();

            Load();
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa") List = new ObservableCollection<Conditions>(List.OrderBy(item => item.ConditionName));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<Conditions>(List.Where(item => item.ConditionName != null && item.ConditionName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
