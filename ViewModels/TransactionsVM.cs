using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class TransactionsVM : AllViewModel<TransactionForView>
    {
        public override void Add()
        {

            var addNewTransactionWindow = new AddNewTransaction();
            var addNewTransactionVM = (AddNewTransactionVM)addNewTransactionWindow.DataContext;
            addNewTransactionWindow.ShowDialog();   

            Load();
        }

        public override void Load()
        {

            List = new ObservableCollection<TransactionForView>(
               from transaction in libraryEntities.Transactions
               select new TransactionForView
               {
                   TransactionID = transaction.TransactionID,
                   BorrowerName = transaction.Members.FirstName + " " + transaction.Members.LastName,
                   BookTitle = transaction.Books.Title,
                   CheckoutDate = transaction.CheckoutDate,
                   DueDate = transaction.DueDate,
                   ReturnDate = transaction.ReturnDate,
                   StatusName = transaction.Statuses.StatusName,
                   StaffName = transaction.Staff.FirstName + " " + transaction.Staff.LastName

               });
        }


        public override void Find()
        {
            Load();
            if (FindField == "Status")
                List = new ObservableCollection<TransactionForView>(List.Where(item => item.StatusName != null && item.StatusName.StartsWith(FindTextBox)));
            if (FindField == "Tytuł")
                List = new ObservableCollection<TransactionForView>(List.Where(item => item.BookTitle != null && item.BookTitle.StartsWith(FindTextBox)));
            if (FindField == "Użytkownik")
                List = new ObservableCollection<TransactionForView>(List.Where(item => item.BorrowerName != null && item.BorrowerName.Contains(FindTextBox)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Status", "Tytuł", "Użytkownik" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Do kiedy", "Oddano", "Od kiedy", "Status", "Tytuł", "Użytkownik" };
        }

        

        public override void Sort()
        {
            if (SortField == "Do kiedy") List = new ObservableCollection<TransactionForView>(List.OrderBy(item => item.CheckoutDate));
            if (SortField == "Oddano") List = new ObservableCollection<TransactionForView>(List.OrderBy(item => item.ReturnDate));
            if (SortField == "Od kiedy") List = new ObservableCollection<TransactionForView>(List.OrderBy(item => item.DueDate));
            if (SortField == "Status") List = new ObservableCollection<TransactionForView>(List.OrderBy(item => item.StatusName));
            if (SortField == "Tytuł") List = new ObservableCollection<TransactionForView>(List.OrderBy(item => item.BookTitle));
            if (SortField == "Użytkownik") List = new ObservableCollection<TransactionForView>(List.OrderBy(item => item.BorrowerName));
        }
    }
}
