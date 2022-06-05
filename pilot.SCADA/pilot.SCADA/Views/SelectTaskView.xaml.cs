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
using System.Windows.Shapes;
using pilot.SCADA.ViewModels;

namespace pilot.SCADA.Views
{
    /// <summary>
    /// SelectTaskView.xaml 的交互逻辑
    /// </summary>
    public partial class SelectTaskView : Window
    {
        public SelectTaskView()
        {
            InitializeComponent();

            SetAllBindings();
        }

        private void SetAllBindings()
        {
            this.DataContext = new SelectTaskViewModel();

            //this.list_task_loaded.ItemsSource = TaskFlowManageViewModel.GetInstance().TaskList;
        }
    }
}
