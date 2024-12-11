using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Utilities.BusinessLogic;
using System;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class AddNewFineVM : AddNewItemVM<Fines>
    {
        public AddNewFineVM()
        {
            item = new Fines();
            item.TransactionID = 10000;
            item.Amount = 0;
            item.PaidDate = null;
            item.FineStatusID = 1;

        }

        public int? TransactionID
        {
            get => item.TransactionID;
            set
            {
                item.TransactionID = value;
                OnPropertyChanged(nameof(TransactionID));
            }
        }
        public decimal Amount
        {
            get => item.Amount;
            set
            {
                item.Amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public DateTime? PaidDate
        {
            get => item.PaidDate;
            set
            {
                item.PaidDate = value;
                OnPropertyChanged(nameof(PaidDate));
            }
        }
        public int FineStatusID
        {
            get => item.FineStatusID;
            set
            {
                item.FineStatusID = value;
                OnPropertyChanged(nameof(FineStatusID));
            }
        }
        public IQueryable<KeyAndValue> TransactionsList
        {
            get
            {
                return DataBaseClass.GetAllTransactions();
            }
        }
        public IQueryable<KeyAndValue> FineStatusesList
        {
            get
            {
                return DataBaseClass.GetAllFineStatuses();
            }
        }




        public Action CloseAction { get; set; }
        public override void Add()
        {

            DataBaseClass.Instance.Fines.Add(item);
            DataBaseClass.Instance.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }

    }
}
