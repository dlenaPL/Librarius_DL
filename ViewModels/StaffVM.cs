using Librarius_DL.Utilities;
using Librarius_DL.Views;
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
    }
}
