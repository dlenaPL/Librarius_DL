using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Utilities.BusinessLogic;
using System;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class AddNewBookCopyVM : AddNewItemVM<BookCopies>
    {

        public AddNewBookCopyVM()
        {
            item = new BookCopies();
            item.BookID = 10000;
            item.QRCode = null;
            item.ConditionID = 1;
            item.StatusID = 100;

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
        public int? ConditionID
        {
            get => item.ConditionID;
            set
            {
                item.ConditionID = value;
                OnPropertyChanged(nameof(ConditionID));
            }
        }
        public byte[] QRCode
        {
            get => item.QRCode;
            set
            {
                item.QRCode = value;
                OnPropertyChanged(nameof(QRCode));
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


        //comboboxy
        public IQueryable<KeyAndValue> BookStatusesList
        {
            get
            {
                return DataBaseClass.GetAllStatuses();
            }
        }

        public IQueryable<KeyAndValue> BookConditionsList
        {
            get
            {
                return DataBaseClass.GetAllConditions();
            }
        }

        public IQueryable<KeyAndValue> BookTitlesList
        {
            get
            {
                return DataBaseClass.GetAllBooks();
            }
        }


        public Action CloseAction { get; set; }
        public override void Add()
        {

            DataBaseClass.Instance.BookCopies.Add(item);
            DataBaseClass.Instance.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
