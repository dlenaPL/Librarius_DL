

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Librarius_DL.Views.CustomControls
{
    /// <summary>
    /// Interaction logic for CustomTextBoxWithClearBtn.xaml
    /// </summary>
    public partial class CustomTextBoxWithClearBtn : UserControl, INotifyPropertyChanged
    {
        public CustomTextBoxWithClearBtn()
        {
            //DataContext = this;
            InitializeComponent();
            txtInput.TextChanged += (s, e) =>
            {
                Text = txtInput.Text; // Update the dependency property
            };
        }

        private string _placeholder;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Placeholder
        {
            get { return _placeholder; }
            set
            {
                _placeholder = value;
                OnPropertyChanged();
            }
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
                tbPlaceholder.Visibility = Visibility.Visible;
            else
                tbPlaceholder.Visibility = Visibility.Hidden;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
    nameof(Text),
    typeof(string),
    typeof(CustomTextBoxWithClearBtn),
    new FrameworkPropertyMetadata(string.Empty,
        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
        OnTextChanged));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CustomTextBoxWithClearBtn;
            if (control != null && control.txtInput.Text != (string)e.NewValue)
            {
                control.txtInput.Text = (string)e.NewValue;
            }
        }

    }
}