using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Utilities.BusinessLogic;
using System;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class AddNewTransactionVM : AddNewItemVM<Transactions>
    {
        public AddNewTransactionVM()
        {
            item = new Transactions();
            item.BorrowerID = 10007;
            item.BookID = 10000;
            item.CheckoutDate = DateTime.Now;
            item.DueDate = DateTime.Now.AddDays(14);
            item.ReturnDate = null;
            item.StatusID = 104;
            item.StaffID = 1001;

        }


        public int? BorrowerID
        {
            get => item.BorrowerID;
            set
            {
                item.BorrowerID = value;
                OnPropertyChanged(nameof(BorrowerID));
            }
        }
        public int? BookID
        {
            get => item.BookID;
            set
            {
                item.BookID = value;
                OnPropertyChanged(nameof(BookID));
            }
        }
        public DateTime? CheckoutDate
        {
            get => item.CheckoutDate;
            set
            {
                item.CheckoutDate = value;
                OnPropertyChanged(nameof(CheckoutDate));
            }
        }
        public DateTime? DueDate
        {
            get => item.DueDate;
            set
            {
                item.DueDate = value;
                OnPropertyChanged(nameof(DueDate));
            }
        }
        public DateTime? ReturnDate
        {
            get => item.ReturnDate;
            set
            {
                item.ReturnDate = value;
                OnPropertyChanged(nameof(ReturnDate));
            }
        }
        public int? StatusID
        {
            get => item.StatusID;
            set
            {
                item.StatusID = value;
                OnPropertyChanged(nameof(StatusID));
            }
        }
        public int? StaffID
        {
            get => item.StaffID;
            set
            {
                item.StaffID = value;
                OnPropertyChanged(nameof(StaffID));
            }
        }


        public IQueryable<KeyAndValue> MembersList
        {
            get
            {
                return DataBaseClass.GetAllMembers();
            }
        }
        public IQueryable<KeyAndValue> BooksList
        {
            get
            {
                return DataBaseClass.GetAllBooks();
            }
        }
        public IQueryable<KeyAndValue> StatusesList
        {
            get
            {
                return DataBaseClass.GetAllStatuses();
            }
        }
        public IQueryable<KeyAndValue> StaffList
        {
            get
            {
                return DataBaseClass.GetAllStaff();
            }
        }

        public Action CloseAction { get; set; }
        public override void Add()
        {

            DataBaseClass.Instance.Transactions.Add(item);
            DataBaseClass.Instance.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }

    }
}
