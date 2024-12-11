using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Utilities.BusinessLogic;
using System;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class AddNewNotificationVM: AddNewItemVM<Notifications>
    {
        public AddNewNotificationVM()
        {
            item = new Notifications();
            item.BorrowerID = 10000;
            item.BookID = 10000;
            item.Message = "Wiadomość";
            item.DateSent = DateTime.Now;
            item.IsRead = true;
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
        public string Message
        {
            get => item.Message;
            set
            {
                item.Message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        public DateTime? DateSent
        {
            get => item.DateSent;
            set
            {
                item.DateSent = value;
                OnPropertyChanged(nameof(DateSent));
            }
        }
        public bool? IsRead
        {
            get => item.IsRead;
            set
            {
                item.IsRead = value;
                OnPropertyChanged(nameof(IsRead));
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



        public Action CloseAction { get; set; }
        public override void Add()
        {

            DataBaseClass.Instance.Notifications.Add(item);
            DataBaseClass.Instance.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
