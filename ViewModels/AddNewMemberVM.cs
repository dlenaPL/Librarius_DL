using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarius_DL.ViewModels
{
    class AddNewMemberVM : AddNewItemVM<Members>
    {

        public AddNewMemberVM()
        {
            item = new Members();
            item.FirstName = "Imie...";
            item.LastName = "Nazwisko....";
            item.ContactInfo = "Nr telefonu...";
            item.MembershipDate =DateTime.Today;
            item.QRCode = null;

        }
        public Action CloseAction { get; set; }

        //------------------------- Members props
        #region Members Props

        public string FirstName
        {
            get => item.FirstName;
            set
            {
                item.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => item.LastName;
            set
            {
                item.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string ContactInfo
        {
            get => item.ContactInfo;
            set
            {
                item.ContactInfo = value;
                OnPropertyChanged(nameof(ContactInfo));
            }
        }

        public DateTime? MembershipDate
        {
            get => item.MembershipDate;
            set
            {
                item.MembershipDate = value;
                OnPropertyChanged(nameof(MembershipDate));
            }
        }

        public byte[]  QRCode
        {
            get => item.QRCode;
            set
            {
                item.QRCode = value;
                OnPropertyChanged(nameof(QRCode));
            }
        }



        #endregion

        public override void Add()
        {
            if (string.IsNullOrWhiteSpace(item.FirstName)) item.FirstName = "Imię Tymczasowe";
            if (string.IsNullOrWhiteSpace(item.LastName)) item.LastName = "Nazwisko Tymczasowe";
            if (string.IsNullOrWhiteSpace(item.ContactInfo)) item.ContactInfo = "Tymczasowy nr telefonu";
            if (!item.MembershipDate.HasValue) item.MembershipDate = DateTime.Now;
            item.QRCode = null;
            libraryEntities.Members.Add(item);
            libraryEntities.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
