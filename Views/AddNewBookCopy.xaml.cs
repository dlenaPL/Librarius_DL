using Librarius_DL.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewBookCopy.xaml
    /// </summary>
    public partial class AddNewBookCopy : AddNewItemViewBase
    {
        public AddNewBookCopy()
        {
            InitializeComponent();
            var viewModel = new AddNewBookCopyVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        
    }
}
