using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LiveCharts;
using LiveCharts.Wpf;
using pilot.Comms.DataBuffer;
using pilot.SCADA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;

namespace pilot.SCADA.ViewModels
{
    public class DataCheckViewModel : ViewModelBase
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public DataCheckViewModel(IDataBuffer dataBuffer)
        {
            this._dataBuffer = dataBuffer;

            DataCheckModel = new DataCheckModel()
            {
                SeriesCollection = new SeriesCollection(),
                XLabels = new List<string>(),
                SelectDispIndex = 0,
                AxisXLength = 10,
                UpdateFreq = 1,
                IsOnCheck = false
            };

            DataCheckModel.SeriesCollection.Add(new LineSeries()
            {
                Title = "Temp",
                LineSmoothness = 0,
                PointGeometry = null,
                Values = new ChartValues<double>()
            });

            timer.Interval = 1000 / DataCheckModel.UpdateFreq;
            timer.Elapsed += Update;
            timer.Start();
        }

        //定时更新 定时器
        private readonly Timer timer = new Timer();
        //虽然不知道为什么，但给series.value幅值时，先用此字段接受一下，再把此字段给value.add(...)，这样不会报转换错误
        private double _trend;

        /// <summary>
        /// 数据缓冲区 读写接口
        /// </summary>
        private readonly IDataBuffer _dataBuffer;

        #region 属性
        private DataCheckModel _dataCheckModel;
        /// <summary>
        /// 模型
        /// </summary>
        public DataCheckModel DataCheckModel
        {
            get { return _dataCheckModel; }
            set
            {
                if (_dataCheckModel == value) { return; }
                _dataCheckModel = value;
                RaisePropertyChanged(() => DataCheckModel);
            }
        }

        private List<ushort> valueList = new List<ushort>();
        /// <summary>
        /// 值列表
        /// </summary>
        public List<ushort> ValueList
        {
            get { return valueList; }
            set
            {
                if (valueList == value) { return; }
                valueList = value;
                RaisePropertyChanged(() => ValueList);
            }
        }

        private List<ushort> addrList = new List<ushort>();
        /// <summary>
        /// 地址列表
        /// </summary>
        public List<ushort> AddrList
        {
            get { return addrList; }
            set
            {
                if (addrList == value) { return; }
                addrList = value;
                RaisePropertyChanged(() => AddrList);
            }
        }

        #endregion


        #region 方法
        public void InitAxis()
        {
            //XLabels = new List<string>() { "0:00:00", "0:00:01", "0:00:02", "0:00:03", "0:00:04" };
            //_trend = 0;
            //SeriesCollection[0].Values.Add(_trend);
            //SeriesCollection[0].Values.Add(_trend);
            //SeriesCollection[0].Values.Add(_trend);
            //SeriesCollection[0].Values.Add(_trend);
            //SeriesCollection[0].Values.Add(_trend);
            //SeriesCollection[0].Values.Add(_trend);
        }

        private void UpdatePoint(string label, double value)
        {
            _trend = value;

            DataCheckModel.XLabels.Add(label);
            DataCheckModel.SeriesCollection[0].Values.Add(_trend);

            if (DataCheckModel.XLabels.Count > DataCheckModel.AxisXLength)
            {
                DataCheckModel.XLabels.RemoveAt(0);
                DataCheckModel.SeriesCollection[0].Values.RemoveAt(0);
            }
        }

        private async void Update(object sender, ElapsedEventArgs e)
        {
            await Task.Run(() =>
            {
                if (DataCheckModel.IsOnCheck == false)
                    return;

                var tem = _dataBuffer.GetAllData();

                AddrList = tem[0];
                ValueList = tem[1];


                var dataPoint = _dataBuffer.GetDataByAddr((ushort)DataCheckModel.SelectDispIndex);

                if (dataPoint == null)
                    return;

                this.UpdatePoint(dataPoint.time.ToString("T"), dataPoint.value);

                //if (DataStorage.GetInstance().NumOfSource <= 0 || DataCheckModel.SelectDispIndex == -1)
                //    return;

                //var data = DataStorage.GetInstance().RealTimeDataList[DataCheckModel.SelectDispIndex];

                //var label = data.TimeStamp.ToString("T");//转换为 短时间
                //var val = data.Value;

                //this.UpdatePoint(label, val);
            });
        }


        #endregion


        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 开关点击 的命令
        /// </summary>
        public RelayCommand<object> SwitchCommand
        {
            get
            {
                return _myCommand1 ?? (_myCommand1 = new RelayCommand<object>(Switch));
            }
        }
        private void Switch(object param)
        {
            bool isChecked = (bool)param;

            if(isChecked)
            {
                this.timer.Interval = 1000 / DataCheckModel.UpdateFreq;
                this.timer.Start();
            }
            else
            {
                this.timer.Stop();
            }
        }
    }
}
