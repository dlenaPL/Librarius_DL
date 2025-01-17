using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Utilities.BusinessLogic;
using Librarius_DL.Validators;
using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Windows;

namespace Librarius_DL.ViewModels
{
    public class AddNewBookVM : AddNewItemVM<Books>, IDataErrorInfo
    {



        public AddNewBookVM()
        {
            
            item = new Books();
            item.Description = "Opis książki";
            item.CoverImagePath = "Okładka";
            item.QRCode = null;

            item.PublisherID = 10000;
            item.StatusID = 101;
        }

        // book props

        public string Title
        {
            get => item.Title;
            set
            {
                item.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string ISBN
        {
            get => item.ISBN;
            set
            {
                item.ISBN = value;
                OnPropertyChanged(nameof(ISBN));
            }
        }
        public string PublishedYear
        {
            get => item.PublishedYear;
            set
            {
                item.PublishedYear = value;
                OnPropertyChanged(nameof(PublishedYear));
            }
        }
        public string Description
        {
            get => item.Description;
            set
            {
                item.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string CoverImagePath
        {
            get => item.CoverImagePath;
            set
            {
                item.CoverImagePath = value;
                OnPropertyChanged(nameof(CoverImagePath));
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
        public int? PublisherID
        {
            get => item.PublisherID;
            set
            {
                item.PublisherID = value;
                OnPropertyChanged(nameof(PublisherID));
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

        public IQueryable<KeyAndValue> PublishersList
        {
            get
            {
                return DataBaseClass.GetAllPublishers();
            }
        }



        public Action CloseAction { get; set; }
        public override void Add()
        {

            
            if (IsValid())
            {
                if (string.IsNullOrWhiteSpace(item.Description)) item.Description = "Opis...";
                if (string.IsNullOrWhiteSpace(item.CoverImagePath)) item.CoverImagePath = "Okładka...";

                DataBaseClass.Instance.Books.Add(item);
                DataBaseClass.Instance.SaveChanges();

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

                if (propertyName == nameof(Title)) _validateMessage = Validator.ValidateString(Title);
                if (propertyName == nameof(PublishedYear)) _validateMessage = Validator.ValidateYear(PublishedYear);
                if (propertyName == nameof(ISBN)) _validateMessage = Validator.ValidateISBN(ISBN);
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
