using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class FinesVM : AllViewModel<FinesForView>
    {
        public override void Add()
        {

            var addNewFineWindow = new AddNewFine();
            var addNewFineVM = (AddNewFineVM) addNewFineWindow.DataContext;
            addNewFineWindow.ShowDialog();

            Load();
        }

        public override void Load()
        {
            List = new ObservableCollection<FinesForView>(
               from fine in libraryEntities.Fines
               select new FinesForView
               {
                   FineID = fine.FineID,
                   TransactionID = fine.TransactionID,
                   FineAmount = fine.Amount,
                   PaidDate = fine.PaidDate,
                   FineStatusName = fine.FineStatuses.FineStatusName
               });
        }


        public override void Find()
        {
            Load();
            if (FindField == "Status")
                List = new ObservableCollection<FinesForView>(List.Where(item => item.FineStatusName != null && item.FineStatusName.StartsWith(FindTextBox)));
            if (FindField == "Transakcja")
                List = new ObservableCollection<FinesForView>(List.Where(item => item.TransactionID != null && item.TransactionID.ToString().StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Status", "Transakcja" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Kwota", "Status", "Data" };
        }

     
        public override void Sort()
        {
            if (SortField == "Kwota") List = new ObservableCollection<FinesForView>(List.OrderBy(item => item.FineAmount));
            if (SortField == "Status") List = new ObservableCollection<FinesForView>(List.OrderBy(item => item.FineStatusName));
            if (SortField == "Data") List = new ObservableCollection<FinesForView>(List.OrderBy(item => item.PaidDate));
        }
    }
}
