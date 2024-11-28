using Librarius_DL.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewCondition.xaml
    /// </summary>
    public partial class AddNewCondition : AddNewItemViewBase
    {
        public AddNewCondition()
        {
            InitializeComponent();
            var viewModel = new AddNewConditionVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewConditionVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbConditionName":
                        viewModel.ConditionName = string.Empty;
                        break;
                    case "tbConditionDescription":
                        viewModel.ConditionDescription = string.Empty;
                        break;
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
