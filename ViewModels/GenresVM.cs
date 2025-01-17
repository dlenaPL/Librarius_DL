using Librarius_DL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Genres = Librarius_DL.Models.Entities.Genres;

namespace Librarius_DL.ViewModels
{
    public class GenresVM : Utilities.AllViewModel<Genres>
    {

        public override void Load()
        {
            List = new ObservableCollection<Genres>(libraryEntities.Genres.ToList());

        }

        public override void Add()
        {
            var addNewGenreWindow = new AddNewGenre();
            var addNewGenreVM = (AddNewGenreVM)addNewGenreWindow.DataContext;

            addNewGenreWindow.ShowDialog();

            Load();
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa") List = new ObservableCollection<Genres>(List.OrderBy(item => item.GenreName));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<Genres>(List.Where(item => item.GenreName != null && item.GenreName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
