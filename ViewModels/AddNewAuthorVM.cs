using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using System;

namespace Librarius_DL.ViewModels
{
    class AddNewAuthorVM : AddNewItemVM<Authors>
    {
        public AddNewAuthorVM()
        {
            item = new Authors();
            item.FirstName = "Imie...";
            item.LastName = "Nazwisko....";
            item.Bio = "Krotka biografia....";

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
            if (string.IsNullOrWhiteSpace(item.FirstName)) item.FirstName = "Imię Tymczasowe";
            if (string.IsNullOrWhiteSpace(item.LastName)) item.LastName = "Nazwisko Tymczasowe";
            if (string.IsNullOrWhiteSpace(item.Bio)) item.Bio = "Biografia Tymczasowa";
            libraryEntities.Authors.Add(item);
            libraryEntities.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }


    }
}
