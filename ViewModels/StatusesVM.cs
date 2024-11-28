using Librarius_DL.Views;
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
    }
}
