using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Librarius_DL.ViewModels
{
    class AddNewMemberVM : AddNewItemVM<Members>, IDataErrorInfo
    {

        public AddNewMemberVM()
        {
            item = new Members();
            item.MembershipDate = DateTime.Today;
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

            if (IsValid())
            {
                item.QRCode = null;
                libraryEntities.Members.Add(item);
                libraryEntities.SaveChanges();
                MessageBox.Show("Zapisano zmiany.");
                CloseAction?.Invoke();
            }
            else
            {
                MessageBox.Show("Popraw błędy aby zapisać lub wróć do poprzedniego widoku.");
            }

            
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }


        //---------------------------------validation
        #region Validation

        public string Error => string.Empty;

        private string _validateMessage = string.Empty;
        public string this[string propertyName]
        {
            get
            {
                var validateMessage = string.Empty;

                if (propertyName == nameof(FirstName)) _validateMessage = Validator.ValidateString(FirstName);
                if (propertyName == nameof(LastName)) _validateMessage = Validator.ValidateString(LastName);
                if (propertyName == nameof(ContactInfo)) _validateMessage = Validator.ValidatePhoneNumber(ContactInfo);

                return _validateMessage;
            }
        }

        public override bool IsValid()
        {
            return string.IsNullOrEmpty(_validateMessage);
        }

        #endregion
    }
}
