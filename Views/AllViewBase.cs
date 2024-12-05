using System.Windows;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
  
    public class AllViewBase : UserControl
    {
        static AllViewBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AllViewBase), new FrameworkPropertyMetadata(typeof(AllViewBase)));
        }
    }
}
