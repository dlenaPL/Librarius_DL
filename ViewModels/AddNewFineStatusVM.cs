using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using System;

namespace Librarius_DL.ViewModels
{
    class AddNewFineStatusVM : AddNewItemVM<FineStatuses>
    {

        public AddNewFineStatusVM()
        {
            item = new FineStatuses();
            item.FineStatusName = "Nazwa kary...";
            item.FineStatusDescription = "Opis...";
        }

        public string FineStatusName
        {
            get => item.FineStatusName;
            set
            {
                item.FineStatusName = value;
                OnPropertyChanged(nameof(FineStatusName));
            }
        }

        public string FineStatusDescription
        {
            get => item.FineStatusDescription;
            set
            {
                item.FineStatusDescription = value;
                OnPropertyChanged(nameof(FineStatusDescription));
            }
        }


        public Action CloseAction { get; set; }

        public override void Add()
        {
            if (string.IsNullOrWhiteSpace(item.FineStatusName)) item.FineStatusName = "Tymczasowa nazwa statusu";
            if (string.IsNullOrWhiteSpace(item.FineStatusDescription)) item.FineStatusDescription = "Tymczasowy opis";
            libraryEntities.FineStatuses.Add(item);
            libraryEntities.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }

    }
}
