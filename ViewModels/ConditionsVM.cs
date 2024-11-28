using Librarius_DL.Views;
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
    }
}
