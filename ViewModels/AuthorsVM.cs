using Librarius_DL.Views;
using System.Collections.ObjectModel;
using System.Linq;
using Authors = Librarius_DL.Models.Entities.Authors;

namespace Librarius_DL.ViewModels
{
    class AuthorsVM : Utilities.AllViewModel<Authors>
    {


        public override void Load()
        {
            List = new ObservableCollection<Authors>(libraryEntities.Authors.ToList());

        }

        public override void Add()
        {
            var addNewAuthorWindow = new AddNewAuthor();
            var addNewAuthorVM = (AddNewAuthorVM)addNewAuthorWindow.DataContext;

            addNewAuthorWindow.ShowDialog();
            Load();
        }
    }
}
