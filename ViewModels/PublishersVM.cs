using Librarius_DL.Views;
using System.Collections.ObjectModel;
using System.Linq;
using Publishers = Librarius_DL.Models.Entities.Publishers;

namespace Librarius_DL.ViewModels
{
    public class PublishersVM : Utilities.AllViewModel<Publishers>
    {
        public override void Load()
        {
            List = new ObservableCollection<Publishers>(libraryEntities.Publishers.ToList());

        }

        public override void Add()
        {

            var addNewPublisherWindow = new AddNewPublisher();
            var addNewPublisherVM = (AddNewPublisherVM)addNewPublisherWindow.DataContext;

            addNewPublisherWindow.ShowDialog();

            Load();
        }
    }
}
