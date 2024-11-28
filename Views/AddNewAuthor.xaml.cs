using Librarius_DL.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Librarius_DL.Views
{

    public partial class AddNewAuthor : AddNewItemViewBase
    {
        public AddNewAuthor()
        {
            InitializeComponent();

            var viewModel = new AddNewAuthorVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewAuthorVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbAuthorName":
                        viewModel.FirstName = string.Empty;
                        break;
                    case "tbAuthorLastName":
                        viewModel.LastName = string.Empty;
                        break;
                    case "tbAuthorBio":
                        viewModel.Bio = string.Empty;
                        break;
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }

    }
}
