using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class TransactionsVM : AllViewModel<TransactionForView>
    {
        public override void Add()
        {

            //var addNewStaffWindow = new AddNewStaff();
            //var addNewStaffVM = (AddNewStaffVM)addNewStaffWindow.DataContext;
            //addNewStaffWindow.ShowDialog();

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
    }
}
