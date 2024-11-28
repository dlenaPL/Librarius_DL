using Librarius_DL.Views;
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
    }
}
