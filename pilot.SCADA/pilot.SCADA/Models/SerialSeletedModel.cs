using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using pilot.SCADA.Common;
using pilot.SCADA.DAL;
using pilot.SCADA.Models;

namespace pilot.SCADA.ViewModels
{
    class SerialSeletedModel : NotificationObject
    {
        IniHelper iniHelper = new IniHelper();

        #region 初始串口参数
        //当前串口号
        private string port;
        public string Port
        {
            get { return port; }
            set
            {
                port = value;
                iniHelper.Write<string>("serial", "Port", value);
                this.RaisePropertyChanged("Port");
            }
        }
        //当前波特率
        private int baudRate;
        public int BaudRate
        {
            get { return baudRate; }
            set
            {
                baudRate = value;
                iniHelper.Write<int>("serial", "BaudRate", value);
                this.RaisePropertyChanged("BaudRate");
            }
        }
        //当前数据位
        private int dataBit;
        public int DataBit
        {
            get { return dataBit; }
            set
            {
                dataBit = value;
                iniHelper.Write<int>("serial", "DataBit", value);
                this.RaisePropertyChanged("DataBit");
            }
        }
        //当前校验位
        private string parity;
        public string Parity
        {
            get { return parity; }
            set
            {
                parity = value;
                iniHelper.Write<string>("serial", "Parity", value);
                this.RaisePropertyChanged("Parity");
            }
        }
        //当前停止位
        private string stopBit;
        public string StopBit
        {
            get { return stopBit; }
            set
            {
                stopBit = value;
                iniHelper.Write<string>("serial", "StopBit", value);
                this.RaisePropertyChanged("StopBit");
            }
        }
        #endregion

        static SerialSeletedModel _instance;

        /// <summary>
        /// CTOR
        /// </summary>
        private SerialSeletedModel()
        {
            try
            {
                this.Port = iniHelper.Read("serial", "Port");
                this.BaudRate = int.Parse(iniHelper.Read("serial", "BaudRate"));
                this.DataBit = int.Parse(iniHelper.Read("serial", "DataBit"));
                this.Parity = iniHelper.Read("serial", "Parity");
                this.StopBit = iniHelper.Read("serial", "StopBit");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static SerialSeletedModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SerialSeletedModel();
            }
            return _instance;
        }



    }

}
