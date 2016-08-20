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
using WpfApplication4.Model;
using WpfApplication4.ViewModel;

namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();

            this.PointInputResource.ItemsSource = this.GetData();
            this.PointIncept.ItemsSource = this.GetData();
            this.PointCommand.ItemsSource = this.GetData();
            this.PointProcess.ItemsSource = this.GetData();
        }

        private List<string> GetData()
        {
            List<string> list = new List<string>();
            for(int i = 0; i < 20; i++)
            {
                list.Add(i.ToString());
            }
            return list;
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var arrays = Enum.GetValues(typeof(EnumPoliceNavigatePoint));
            var verticalOffset = this.scrollViewer.VerticalOffset;
            if(verticalOffset > 0)
            {
                double scrollOffset = 0.0;
                foreach (var child in this.AnchorPointPanel.Children)
                {
                    if (child is FrameworkElement)
                    {
                        FrameworkElement element = child as FrameworkElement;

                        if (element == null) return;

                        scrollOffset += element.ActualHeight;
                        if(scrollOffset > verticalOffset)
                        {
                            string elementName = Convert.ToString(element.GetValue(FrameworkElement.NameProperty));
                            foreach (EnumPoliceNavigatePoint point in arrays)
                            {
                                if (elementName.Equals(point.ToString()))
                                {
                                    var vm = this.DataContext as MainViewModel;
                                    vm.SetPoint(point);
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = this.AnchorListBox.SelectedItem;
            if (selectedItem == null) return;

            Vector v = new Vector(0, 0);
            switch ((selectedItem as AnchorInfo).AnchorName)
            {
                case EnumPoliceNavigatePoint.PointInputResource:
                    v = VisualTreeHelper.GetOffset(this.PointInputResource);
                    break;
                case EnumPoliceNavigatePoint.PointIncept:
                    v = VisualTreeHelper.GetOffset(this.PointIncept);
                    break;
                case EnumPoliceNavigatePoint.PointCommand:
                    v = VisualTreeHelper.GetOffset(this.PointCommand);
                    break;
                case EnumPoliceNavigatePoint.PointProcess:
                    v = VisualTreeHelper.GetOffset(this.PointProcess);
                    break;
                default:
                    break;
            }
            this.scrollViewer.ScrollToVerticalOffset(v.Y);
        }
    }
}
