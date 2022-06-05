using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pilot.SCADA.Common;

namespace pilot.SCADA.Models
{
    //串口的初始化参数类 ComParameter
    public class SerialParamModel : NotificationObject
    {
        //端口号
        private ObservableCollection<string> port = new ObservableCollection<string>() { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10", "COM11", "COM12" };
        public ObservableCollection<string> Port
        {
            get { return port; }
            set
            {
                port = value;
                this.RaisePropertyChanged("Port");
            }
        }

        //波特率
        private ObservableCollection<int> baudRate = new ObservableCollection<int>() { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400 };
        public ObservableCollection<int> BaudRate
        {
            get { return baudRate; }
            set
            {
                baudRate = value;
                this.RaisePropertyChanged("BaudRate");
            }
        }

        //数据位
        private ObservableCollection<int> dataBit = new ObservableCollection<int>() { 6, 7, 8 };
        public ObservableCollection<int> DataBit
        {
            get { return dataBit; }
            set
            {
                dataBit = value;
                this.RaisePropertyChanged("DataBit");
            }
        }

        //校验位
        private ObservableCollection<string> parity = new ObservableCollection<string>() { "无", "偶校验", "奇校验" };
        public ObservableCollection<string> Parity
        {
            get { return parity; }
            set
            {
                parity = value;
                this.RaisePropertyChanged("Parity");
            }
        }

        //停止位
        private ObservableCollection<string> stopBit = new ObservableCollection<string>() { "1", "1.5", "2" };
        public ObservableCollection<string> StopBit
        {
            get { return stopBit; }
            set
            {
                stopBit = value;
                this.RaisePropertyChanged("StopBit");
            }
        }


        public SerialParamModel()
        {
            ScanCom();
        }

        /// <summary>
        /// 扫描可用串口
        /// </summary>
        public void ScanCom()
        {
            string[] enablePorts = SerialPort.GetPortNames();

            this.Port.Clear();

            foreach (var item in enablePorts)
            {
                this.port.Add(item);
            }
        }
    }
}
