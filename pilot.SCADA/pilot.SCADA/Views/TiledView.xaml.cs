using LiveCharts;
using pilot.SCADA.Global;
using pilot.SCADA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pilot.SCADA.Views
{
    /// <summary>
    /// view1.xaml 的交互逻辑
    /// </summary>
    public partial class TiledView : UserControl
    {
        public TiledView()
        {
            InitializeComponent();

            CreateView();
        }

        private void CreateView()
        {
            //this.WarpPanel.Children.Clear();

            //var SensorList = SensorManagerViewModel.GetInstance().SensorList;

            //if (SensorList == null)
            //    return;

            //for (int i = 0; i < SensorList.Count; i++)
            //{
            //    var view = new TiledCheckView();
            //    var vm = new TiledCheckViewModel(SensorList[i]);

            //    view.DataContext = vm;
                
            //    this.WarpPanel.Children.Add(view);
            //}
        }
    }
}
