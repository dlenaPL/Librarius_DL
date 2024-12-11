using Librarius_DL.ViewModels;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewTransaction.xaml
    /// </summary>
    public partial class AddNewTransaction : AddNewItemViewBase
    {
        public AddNewTransaction()
        {
            InitializeComponent();
            var viewModel = new AddNewTransactionVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }
    }
}
