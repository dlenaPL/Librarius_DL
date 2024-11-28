using Librarius_DL.Views;
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
    }
}
