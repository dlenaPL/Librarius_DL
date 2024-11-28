using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using System;
using System.CodeDom;

namespace Librarius_DL.ViewModels
{
    class AddNewStatusVM : AddNewItemVM<Statuses>
    {

        public AddNewStatusVM()
        {
            item = new Statuses();
            item.StatusName = "Nazwa...";
            item.StatusDescription = "Krotki opis...";
            
        }


        public string StatusName
        {
            get => item.StatusName;
            set
            {
                item.StatusName = value;
                OnPropertyChanged(nameof(StatusName));
            }
        }

        public string StatusDescription
        {
            get => item.StatusDescription;
            set
            {
                item.StatusDescription = value;
                OnPropertyChanged(nameof(StatusDescription));
            }
        }

        public Action CloseAction { get; set; }

        public override void Add()
        {
            if (string.IsNullOrWhiteSpace(item.StatusName)) item.StatusName = "Tymczasowa nazwa statusu";
            if (string.IsNullOrWhiteSpace(item.StatusDescription)) item.StatusDescription = "Tymczasowy opis";
            libraryEntities.Statuses.Add(item);
            libraryEntities.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }

    }
}
