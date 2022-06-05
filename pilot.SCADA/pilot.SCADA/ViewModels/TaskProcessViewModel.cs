
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pilot.SCADA.ViewModels
{
    class TaskProcessViewModel : ViewModelBase
    {
        //选中显示的传感器索引
        private int _sensorIndex;
        public int SensorIndex
        {
            get { return _sensorIndex; }
            set
            {
                _sensorIndex = value;
                this.RaisePropertyChanged("SensorIndex");
            }
        }

        private readonly SensorManagerViewModel _sensorManagerViewModel;

        /// <summary>
        /// ctor
        /// </summary>
        public TaskProcessViewModel(SensorManagerViewModel sensorManagerViewModel)
        {
            this._sensorManagerViewModel = sensorManagerViewModel;

            SensorIndex = 0;
        }

        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 刷新视图 的命令
        /// </summary>
        public RelayCommand<object> RefreshCommand
        {
            get
            {
                return _myCommand1 ?? (_myCommand1 = new RelayCommand<object>(Refresh));
            }
        }
        private void Refresh(object param)
        {
            try
            {
                WrapPanel wrapPanel = param as WrapPanel;
                wrapPanel.Children.Clear();//先清除

                var whichSensor = _sensorManagerViewModel.SensorList[SensorIndex];

                var taskList = whichSensor.TaskList;

                foreach (var item in taskList)
                {
                    Assembly assembly = Assembly.LoadFile(item.Path);
                    Type type = assembly.GetType("Info.ModuleInfo");

                    BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static;

                    var NameSpace = type.GetProperty("NameSpace", bindingFlags).GetValue(this) as string;
                    var ViewClassName = type.GetProperty("ViewClassName", bindingFlags).GetValue(this) as string;
                    var ViewModelClassName = type.GetProperty("ViewModelClassName", bindingFlags).GetValue(this) as string;

                    Type ViewType = assembly.GetType(NameSpace + "." + ViewClassName);
                    Type ViewModelType = assembly.GetType(NameSpace + "." + ViewModelClassName);

                    object ViewInstance = Activator.CreateInstance(ViewType);
                    object ViewModelInstance = Activator.CreateInstance(ViewModelType);

                    

                    wrapPanel.Children.Add(ViewInstance as UIElement);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        #endregion
    }
}
