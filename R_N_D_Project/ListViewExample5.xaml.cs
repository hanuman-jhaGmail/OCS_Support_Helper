using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace R_N_D_Project
{
    /// <summary>
    /// Interaction logic for ListViewExample5.xaml
    /// </summary>
    public partial class ListViewExample5 : Window
    {
        public ListViewExample5()
        {
            InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User() { Name = "John Doe", Age = 42, Sex = SexType.Male });
            items.Add(new User() { Name = "Jane Doe", Age = 39, Sex = SexType.Female });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Sex = SexType.Male });
            items.Add(new User() { Name = "Donna Doe", Age = 13, Sex = SexType.Male });
            lvUsers.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Sex");
            view.GroupDescriptions.Add(groupDescription);
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
        }
    }
}
