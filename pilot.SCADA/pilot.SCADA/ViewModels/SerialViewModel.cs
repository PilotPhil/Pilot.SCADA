using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using pilot.SCADA.Global;
using HandyControl.Controls;
using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using pilot.DAL.Serialization;

namespace pilot.SCADA.ViewModels
{
    public class SerialViewModel : ViewModelBase
    {
        //序列化
        private readonly ISerialize _serialize;

        /// <summary>
        /// CTOR
        /// </summary>
        public SerialViewModel(ISerialize serialize)
        {
            this._serialize = serialize;//依赖反转
            this._serialize.SetPath(Path.Combine(GlobalValues.CurrentProjectPath, "SerialComParamModel.json"));

            //反序列化实例化对象
            SerialModel = _serialize.Read<SerialModel>();
            SerialModel = SerialModel ?? new SerialModel()
            {
                
                BaudRate = 9600,
                DataBit = 8,
                Parity = "无",
                StopBit = "1"
            };

            SerialModel.PortList = SerialPort.GetPortNames().ToList();//获取可用端口
        }


        #region 属性
        private SerialModel _serialModel;
        /// <summary>
        /// 串口通信参数模型
        /// </summary>
        public SerialModel SerialModel
        {
            get { return _serialModel; }
            set
            {
                if (_serialModel == value) { return; }
                _serialModel = value;
                RaisePropertyChanged(() => SerialModel);
            }
        }

        #endregion

        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 确认 设置串口对象 的命令
        /// </summary>
        public RelayCommand<object> ConfirmCommand
        {
            get
            {
                return _myCommand1 ?? (_myCommand1 = new RelayCommand<object>(Confirm));
            }
        }
        public void Confirm(object param)
        {
            LogRecordModel log = new LogRecordModel();
            var SerialComView = param as Window;

            try//设置串口对象，设置静态唯一串口对象
            {
                SerialObj.OnlySerial.PortName = SerialModel.PortName;
                SerialObj.OnlySerial.BaudRate = SerialModel.BaudRate;
                SerialObj.OnlySerial.DataBits = SerialModel.DataBit;

                if (SerialModel.StopBit == "1")
                    SerialObj.OnlySerial.StopBits = System.IO.Ports.StopBits.One;
                else if (SerialModel.StopBit == "1.5")
                    SerialObj.OnlySerial.StopBits = System.IO.Ports.StopBits.OnePointFive;
                else
                    SerialObj.OnlySerial.StopBits = System.IO.Ports.StopBits.Two;

                if (SerialModel.Parity == "无")
                    SerialObj.OnlySerial.Parity = System.IO.Ports.Parity.None;
                else if (SerialModel.Parity == "偶校验")
                    SerialObj.OnlySerial.Parity = System.IO.Ports.Parity.Even;
                else
                    SerialObj.OnlySerial.Parity = System.IO.Ports.Parity.Odd;


                log.Content = "串口对象创建成功";
                log.Type = LogType.Success;

                _serialize.Write(SerialModel);
            }
            catch (Exception ex)
            {
                log.Content = ex.ToString();
                log.Type = LogType.Failed;
            }
            finally
            {
                GlobalValues.Log(log);
                SerialComView.Close();
            }
        }

        #endregion

    }
}
