using Librarius_DL.Views;
using System.Collections.Generic;
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

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa") List = new ObservableCollection<Publishers>(List.OrderBy(item => item.PublisherName));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<Publishers>(List.Where(item => item.PublisherName != null && item.PublisherName.StartsWith(FindTextBox)));
        }
    }
}
