using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Utilities.BusinessLogic;
using System;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class AddNewReservationVM : AddNewItemVM<Reservations>
    {
        public AddNewReservationVM()
        {
            item = new Reservations();
            item.BorrowerID = 10000;
            item.BookID = 10000;
            item.ReservationDate = DateTime.Now.AddDays(1);
            item.StatusID = 102;
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
        public DateTime? ReservationDate
        {
            get => item.ReservationDate;
            set
            {
                item.ReservationDate = value;
                OnPropertyChanged(nameof(ReservationDate));
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



        public IQueryable<KeyAndValue> BorrowersList
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
        public IQueryable<KeyAndValue> StatuseList
        {
            get
            {
                return DataBaseClass.GetAllStatuses();
            }
        }



        public Action CloseAction { get; set; }
        public override void Add()
        {

            DataBaseClass.Instance.Reservations.Add(item);
            DataBaseClass.Instance.SaveChanges();

            CloseAction?.Invoke();
        }
        public override void Cancel()
        {
            CloseAction?.Invoke();
        }

    }
}
