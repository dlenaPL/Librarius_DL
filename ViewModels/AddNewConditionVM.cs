using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using System;

namespace Librarius_DL.ViewModels
{
    class AddNewConditionVM : AddNewItemVM<Conditions>
    {
        public AddNewConditionVM()
        {
            item = new Conditions();
            item.ConditionName = "Nazwa stanu...";
            item.ConditionDescription = "Krótki opis";
        }

        public string ConditionName
        {
            get => item.ConditionName;
            set
            {
                item.ConditionName = value;
                OnPropertyChanged(nameof(ConditionName));
            }
        }

        public string ConditionDescription
        {
            get => item.ConditionDescription;
            set
            {
                item.ConditionDescription = value;
                OnPropertyChanged(nameof(ConditionDescription));
            }
        }


        public Action CloseAction { get; set; }

        public override void Add()
        {
            if (string.IsNullOrWhiteSpace(item.ConditionName)) item.ConditionName = "Tymczasowa nazwa stanu";
            if (string.IsNullOrWhiteSpace(item.ConditionDescription)) item.ConditionDescription = "Tymczasowy opis";
            libraryEntities.Conditions.Add(item);
            libraryEntities.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
