using Librarius_DL.ViewModels;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewReservation.xaml
    /// </summary>
    public partial class AddNewReservation : AddNewItemViewBase
    {
        public AddNewReservation()
        {
            InitializeComponent();
            var viewModel = new AddNewReservationVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }
    }
}
