using System;
using System.Collections.Generic;
using System.Linq;
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

namespace UrhoTestApp
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
            this.Unloaded += UserControl2_Unloaded;
        }

        private void UserControl2_Unloaded(object sender, RoutedEventArgs e)
        {
            // This row does not make any difference for the UrhoSurface, it will still 
            // be kept in memory. (But the user control will be garbage collected...)
            Grid1.Children.Remove(Urho1);
            this.Unloaded -= UserControl2_Unloaded;
        }
    }
}
