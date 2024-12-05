using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class BooksVM : AllViewModel<BooksForView>
    {
        public override void Add()
        {

            var addNewBookWindow = new AddNewBook();
            var addNewBookVM = (AddNewBookVM)addNewBookWindow.DataContext;
            addNewBookWindow.ShowDialog();

            Load();
        }

        public override void Load()
        {
            List = new ObservableCollection<BooksForView>(
               from book in libraryEntities.Books
               select new BooksForView
               {
                   BookID = book.BookID,
                   BookTitle = book.Title,
                   Publishers = book.Publishers.PublisherName,
                   ISBN = book.ISBN,
                   PublishedYear = book.PublishedYear,
                   BookDescription = book.Description,
                   CoverImgPath = book.CoverImagePath,
                   BookStatus = book.Statuses.StatusName,
                   BookQRCode = book.QRCode
               });
        }
    }
}
