using pilot.SlaveComputerEmulator.Models;
using pilot.SCADA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using pilot.SCADA.Common;
using System.Windows;
using System.Timers;
using System.Windows.Controls;

namespace pilot.SlaveComputerEmulator.ViewModels
{
    class MainViewModel : NotificationObject
    {
        //model
        private MainModel _mainModel;
        public MainModel MainModel
        {
            get { return _mainModel; }
            set
            {
                _mainModel = value;
                this.RaisePropertyChanged("MainModel");
            }
        }

        private readonly JsonSerialize JsonSerialize = new JsonSerialize(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cfg.json"));

        #region SerialPort
        private SerialPort serialPort = new SerialPort()
        {
            BaudRate = 9600,
            DataBits = 8,
            Parity = Parity.None,
            StopBits = StopBits.One
        };
        public void OpenPort()
        {
            try
            {
                if (serialPort.IsOpen == true)
                {
                    serialPort.Close();
                }

                serialPort.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public void ClosePort()
        {
            try
            {
                if (serialPort.IsOpen == true)
                {
                    serialPort.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        ModbusSlaveViewModel ModbusSlaveViewModel = new ModbusSlaveViewModel();

        //ctor
        public MainViewModel()
        {
            MainModel = JsonSerialize.DeserializeRead<MainModel>() ?? new MainModel();

            MainModel.ComList = SerialPort.GetPortNames().ToList();

            StartCommand.ExecuteAction = new Action<object>(Start);
            StartCommand.CanExecuteFunc = new Func<object, bool>(o => true);

            StopCommand.ExecuteAction = new Action<object>(Stop);
            StopCommand.CanExecuteFunc = new Func<object, bool>(o => true);

            timer.Elapsed += UpdateData;
        }


        private bool HasSettedSlave = false;//是否已经设置过slave，保证设置slave方法只运行一次
        /// <summary>
        /// 设置slave
        /// </summary>
        private void SetSlave()
        {
            ModbusSlaveViewModel.AddSlave(serialPort, MainModel.SlaveId);//添加slave
            ModbusSlaveViewModel.StartListen();//开启监听

            HasSettedSlave = true;
        }

        //随机数生产
        Random Random = new Random();
        //更新数据用计时器
        Timer timer = new Timer();
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateData(object sender, ElapsedEventArgs e)
        {
            for (int i = 0; i < MainModel.SensorNum; i++)
            {
                ModbusSlaveViewModel.Storage.InputRegisters[(ushort)i] = (ushort)Random.Next(MainModel.DownValue, MainModel.UpValue);
            }
        }


        //开始停止 命令
        public DelegateCommand StartCommand { get; set; } = new DelegateCommand();
        private void Start(object param)
        {
            try
            {
                if (HasSettedSlave == false)
                {
                    ClosePort();

                    serialPort.PortName = MainModel.Com;//设置端口

                    OpenPort();
                    SetSlave();
                }

                timer.Interval = 1000/MainModel.Freq;
                timer.Start();

                (param as Button).IsEnabled = false;

                JsonSerialize.SerializeWrite(MainModel);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DelegateCommand StopCommand { get; set; } = new DelegateCommand();
        private void Stop(object param)
        {
            try
            {
                timer.Stop();

                (param as Button).IsEnabled = true;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
