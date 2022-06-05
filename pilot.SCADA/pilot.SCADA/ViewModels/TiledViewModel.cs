using CommonServiceLocator;
using GalaSoft.MvvmLight;
using pilot.SCADA.Global;
using pilot.SCADA.Sensor;
using pilot.SCADA.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pilot.SCADA.ViewModels
{
    public class TiledViewModel : ViewModelBase
    {
        public ObservableCollection<TiledCheckView> CheckViewList { get; set; }

        private readonly ISensorManage _sensorManage;

        public TiledViewModel(ISensorManage sensorManage)
        {
            this._sensorManage = sensorManage;

            CheckViewList = new ObservableCollection<TiledCheckView>();

            ServiceLocator.Current.GetInstance<SensorManagerViewModel>();
            int? numOfSensor = _sensorManage.GetSensorNum();

            //无传感器，不创建子元素
            if(numOfSensor==null || numOfSensor <= 0)
            {
                return;
            }

            //元素数量归零
            TiledCheckViewModel.numOfThisView = 0;

            //依次添加
            for (int i = 0; i < numOfSensor; i++)
            {
                var view = new TiledCheckView();

                CheckViewList.Add(view);
            }
        }
    }
}
