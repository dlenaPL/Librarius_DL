using Librarius_DL.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewBook.xaml
    /// </summary>
    public partial class AddNewBook : AddNewItemViewBase
    {
        public AddNewBook()
        {
            InitializeComponent();
            var viewModel = new AddNewBookVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewBookVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbBookTitle":
                        viewModel.Title = string.Empty;
                        break;
                    case "tbISBN":
                        viewModel.ISBN = string.Empty;
                        break;
                    case "tbBookPublishedYear":
                        viewModel.PublishedYear = string.Empty;
                        break;
                    case "tbBookDescription":
                        viewModel.Description = string.Empty;
                        break;
                    case "tbBookCoverPath":
                        viewModel.CoverImagePath = string.Empty;
                        break;
                    
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
