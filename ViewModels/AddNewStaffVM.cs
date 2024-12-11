using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Utilities.BusinessLogic;
using System;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class AddNewStaffVM : AddNewItemVM<Staff>
    {
        public AddNewStaffVM()
        {
            item = new Staff();
            item.FirstName = "Imię...";
            item.LastName = "Nazwisko...";
            item.ContactInfo = "Kontakt...";
            item.RoleID = 104;
        }

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
        public int? RoleID
        {
            get => item.RoleID;
            set
            {
                item.RoleID = value;
                OnPropertyChanged(nameof(RoleID));
            }
        }


        public IQueryable<KeyAndValue> RoleNamesList
        {
            get
            {
                return DataBaseClass.GetAllRoles();
            }
        }


        public Action CloseAction { get; set; }
        public override void Add()
        {

            DataBaseClass.Instance.Staff.Add(item);
            DataBaseClass.Instance.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
