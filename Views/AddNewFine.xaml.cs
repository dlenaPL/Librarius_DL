using Librarius_DL.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewFine.xaml
    /// </summary>
    public partial class AddNewFine : AddNewItemViewBase
    {
        public AddNewFine()
        {
            InitializeComponent();
            var viewModel = new AddNewFineVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewFineVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbFineAmount":
                        viewModel.Amount = 0;
                        break;
                   

                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
