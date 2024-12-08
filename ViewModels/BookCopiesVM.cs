using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class BookCopiesVM : AllViewModel<BookCopiesForView>
    {
        public override void Add()
        {


            var addNewBookCopyWindow = new AddNewBookCopy();
            var addNewBookCopyVM = (AddNewBookCopyVM) addNewBookCopyWindow.DataContext;
            addNewBookCopyWindow.ShowDialog();

            Load();
        }

        public override void Load()
        {
            List = new ObservableCollection<BookCopiesForView>(
               from bookCopy in libraryEntities.BookCopies
               select new BookCopiesForView
               {
                  BookCopyID = bookCopy.CopyID,
                  BookTitle = bookCopy.Books.Title,
                  QRCode = bookCopy.QRCode,
                  CopyStatus = bookCopy.Statuses.StatusName,
                  CopyCondition = bookCopy.Conditions.ConditionName
               });
        }

    }
}
