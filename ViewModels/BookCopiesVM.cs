using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System.Collections.Generic;
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

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Tytuł", "Status", "Stan" };
        }

        public override void Sort()
        {
            if (SortField == "Tytuł") List = new ObservableCollection<BookCopiesForView>(List.OrderBy(item => item.BookTitle));
            if (SortField == "Status") List = new ObservableCollection<BookCopiesForView>(List.OrderBy(item => item.CopyStatus));
            if (SortField == "Stan") List = new ObservableCollection<BookCopiesForView>(List.OrderBy(item => item.CopyCondition));
           
           
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Tytuł", "Stan" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Tytuł")
                List = new ObservableCollection<BookCopiesForView>(List.Where(item=> item.BookTitle != null && item.BookTitle.StartsWith(FindTextBox)));
            if (FindField == "Stan")
                List = new ObservableCollection<BookCopiesForView>(List.Where(item => item.CopyCondition != null && item.CopyCondition.StartsWith(FindTextBox)));

        }

    }
}
