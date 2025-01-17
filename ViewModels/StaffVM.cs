using Librarius_DL.Utilities;
using Librarius_DL.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class StaffVM : AllViewModel<StaffForView>
    {
        public override void Add()
        {

            var addNewStaffWindow = new AddNewStaff();
            var addNewStaffVM = (AddNewStaffVM) addNewStaffWindow.DataContext;
            addNewStaffWindow.ShowDialog();

            Load();
        }

        public override void Load()
        {

            List = new ObservableCollection<StaffForView>(
               from staff in libraryEntities.Staff
               select new StaffForView
               {
                   StaffID = staff.StaffID,
                   FirstName = staff.FirstName,
                   LastName = staff.LastName,
                   RoleName = staff.Roles.RoleName,
                   ContactInfo = staff.ContactInfo

               });
        }

        public override void Find()
        {
            Load();
            if (FindField == "Imię")
                List = new ObservableCollection<StaffForView>(List.Where(item => item.FirstName != null && item.FirstName.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<StaffForView>(List.Where(item => item.LastName != null && item.LastName.StartsWith(FindTextBox)));
            if (FindField == "Rola")
                List = new ObservableCollection<StaffForView>(List.Where(item => item.RoleName != null && item.RoleName.StartsWith(FindTextBox)));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię", "Nazwisko", "Rola" };
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imię", "Nazwisko", "Rola" };
        }

        

        public override void Sort()
        {

            if (SortField == "Imię") List = new ObservableCollection<StaffForView>(List.OrderBy(item => item.FirstName));
            if (SortField == "Nazwisko") List = new ObservableCollection<StaffForView>(List.OrderBy(item => item.LastName));
            if (SortField == "Rola") List = new ObservableCollection<StaffForView>(List.OrderBy(item => item.RoleName));
        }
    }
}
