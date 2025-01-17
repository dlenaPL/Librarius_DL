using Librarius_DL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Members = Librarius_DL.Models.Entities.Members;

namespace Librarius_DL.ViewModels
{
    public class MembersVM : Utilities.AllViewModel<Members>
    {
        

        public override void Load()
        {

            List = new ObservableCollection<Members>(libraryEntities.Members.ToList());
            
        }

        public override void Add()
        {
            var addNewMemberWindow = new AddNewMember();
            var addNewMemberVM = (AddNewMemberVM)addNewMemberWindow.DataContext;
            addNewMemberWindow.ShowDialog();

            Load();
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Imię", "Nazwisko", "Od kiedy" };
        }

        public override void Sort()
        {
            if (SortField == "Imię") List = new ObservableCollection<Members>(List.OrderBy(item => item.FirstName));
            if (SortField == "Nazwisko") List = new ObservableCollection<Members>(List.OrderBy(item => item.LastName));
            if (SortField == "Od kiedy") List = new ObservableCollection<Members>(List.OrderBy(item => item.MembershipDate));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię", "Nazwisko" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Imię")
                List = new ObservableCollection<Members>(List.Where(item => item.FirstName != null && item.FirstName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<Members>(List.Where(item => item.LastName != null && item.LastName.StartsWith(FindTextBox, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
