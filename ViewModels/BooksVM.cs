using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System;
using System.Collections.Generic;
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

        public override void Find()
        {
            Load();
            if (FindField == "Tytuł")
                List = new ObservableCollection<BooksForView>(List.Where(item => item.BookTitle != null && item.BookTitle.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "ISBN")
                List = new ObservableCollection<BooksForView>(List.Where(item => item.ISBN != null && item.ISBN.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Tytuł", "ISBN" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Tytuł", "Rok wydania"};
        }

        public override void Sort()
        {
            if (SortField == "Tytuł") List = new ObservableCollection<BooksForView>(List.OrderBy(item => item.BookTitle));
            if (SortField == "Rok wydania") List = new ObservableCollection<BooksForView>(List.OrderBy(item => item.PublishedYear));
            
        }
    }
}
