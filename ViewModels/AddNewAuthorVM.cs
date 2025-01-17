using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Validators;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace Librarius_DL.ViewModels
{
    class AddNewAuthorVM : AddNewItemVM<Authors>, IDataErrorInfo
    {
        public AddNewAuthorVM()
        {
            item = new Authors();
            item.Bio = "";

        }


        //Authors Props Region
        #region Authors Props

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

        public string Bio
        {
            get => item.Bio;
            set
            {
                item.Bio = value;
                OnPropertyChanged(nameof(Bio));
            }
        }

        #endregion


        public Action CloseAction { get; set; }

        public override void Add()
        {

            if(IsValid())
            {
                MessageBox.Show("Zapisano zmiany.");
                libraryEntities.Authors.Add(item);
                libraryEntities.SaveChanges();

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

        #region Validation

        public string Error => string.Empty;

        private string _validateMessage = string.Empty;
        public string this[string propertyName]
        {
            get
            {
                var validateMessage = string.Empty;

                if (propertyName == nameof(FirstName)) 
                {
                    _validateMessage =  Validator.ValidateString(FirstName);
                }

                if (propertyName == nameof(LastName))
                {
                    _validateMessage = Validator.ValidateString(LastName);
                }

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
