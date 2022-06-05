using CommonServiceLocator;
using GalaSoft.MvvmLight;
using LiveCharts;
using pilot.Comms.DataBuffer;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using pilot.SCADA.Sensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace pilot.SCADA.ViewModels
{
    public class TiledCheckViewModel : ViewModelBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public TiledCheckViewModel(IDataBuffer dataBuffer, ISensorManage sensorManage)
        {
            this._dataBuffer = dataBuffer;
            this._sensorManage = sensorManage;

            Values = new ChartValues<double>();

            currentVal = 0;

            SensorModel = _sensorManage.GetSensorByIndex(numOfThisView);
            numOfThisView++;

            timer.Interval = 1000;
            timer.Elapsed += Update;
            timer.Start();
        }


        #region 属性
        //这个view的总数
        public static int numOfThisView = 0;

        //定时更新 定时器
        private readonly Timer timer = new Timer();

        //modbus数据获取接口
        private readonly IDataBuffer _dataBuffer;

        //传感器信息获取接口
        private readonly ISensorManage _sensorManage;

        private ChartValues<double> values;
        /// <summary>
        /// myVar
        /// </summary>
        public ChartValues<double> Values
        {
            get { return values; }
            set
            {
                if (values == value) { return; }
                values = value;
                RaisePropertyChanged(() => Values);
            }
        }

        private double currentVal;
        /// <summary>
        /// 该传感器当前值
        /// </summary>
        public double CurrentVal
        {
            get { return currentVal; }
            set
            {
                if (currentVal == value) { return; }
                currentVal = value;
                RaisePropertyChanged(() => CurrentVal);
            }
        }

        private SensorModel sensorModel;
        /// <summary>
        /// SensorModel
        /// </summary>
        public SensorModel SensorModel
        {
            get { return sensorModel; }
            set
            {
                if (sensorModel == value) { return; }
                sensorModel = value;
                RaisePropertyChanged(() => SensorModel);
            }
        }
        #endregion


        #region 方法
        private async void Update(object sender, ElapsedEventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    if (sensorModel.IsEnable == false)
                        return;

                    var currentValue = _dataBuffer.GetDataByAddr((ushort)SensorModel.DataSourceIndex);

                    if (currentValue != null)
                    {

                        this.CurrentVal = currentValue.value;

                        Values.Add(CurrentVal);

                        if (this.Values.Count >= 6)
                        {
                            Values.RemoveAt(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            });
        }


        #endregion
    }
}
