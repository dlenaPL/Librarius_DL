using Librarius_DL.Views;
using System.Collections.Generic;
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

        public override List<string> GetComboboxSortList()
        {
            return new List<string> {"Nazwa"};
        }

        public override void Sort()
        {
            if (SortField == "Imię") List = new ObservableCollection<Authors>(List.OrderBy(item => item.FirstName));
            if (SortField == "Nazwisko") List = new ObservableCollection<Authors>(List.OrderBy(item => item.LastName));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię", "Nazwisko" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Imię") 
                List = new ObservableCollection<Authors>(List.Where(item=>item.FirstName != null && item.FirstName.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<Authors>(List.Where(item => item.LastName != null && item.LastName.StartsWith(FindTextBox)));
        }
    }
}
