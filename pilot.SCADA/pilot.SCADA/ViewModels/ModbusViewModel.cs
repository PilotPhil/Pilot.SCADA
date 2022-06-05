using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using NModbus;
using NModbus.Serial;
using NModbus.Utility;
using pilot.Comms.DataBuffer;
using pilot.DAL.Serialization;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace pilot.SCADA.ViewModels
{
    public class ModbusViewModel : ViewModelBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public ModbusViewModel(ISerialize serilizer, IDataBuffer dataStorage)
        {
            this._serilizer = serilizer;
            this._serilizer.SetPath(Path.Combine(GlobalValues.CurrentProjectPath, "ModbusModel.json"));

            this._dataStorage = dataStorage;

            ModbusModel = _serilizer.Read<ModbusModel>();
            ModbusModel = ModbusModel ?? new ModbusModel()
            {
                ScanRate = 1000,
                StartAddr = 0,
                ReadNum = 0,
                SlaveId = 0,
                UseRtu = true
            };

            //读取定时器
            timer2Read.Interval = ModbusModel.ScanRate;
            timer2Read.Elapsed += this.ReadSensorValues;

            //注册消息，mainviewmodel中command控制开始、停止读取，发送messenger至modbusviewmodel进行开始、停止控制
            Messenger.Default.Register<object>(this, "StartModbusReadToken", StartRead);
            Messenger.Default.Register<object>(this, "StopModbusReadToken", StopRead);
        }


        #region 属性
        //序列化对象
        private readonly ISerialize _serilizer;

        private readonly IDataBuffer _dataStorage;

        private ModbusModel _modbusModel;
        /// <summary>
        /// modbus参数模型
        /// </summary>
        public ModbusModel ModbusModel
        {
            get { return _modbusModel; }
            set
            {
                if (_modbusModel == value) { return; }
                _modbusModel = value;
                RaisePropertyChanged(() => ModbusModel);
            }
        }

        //用于读取的计时器
        private readonly Timer timer2Read = new Timer();

        //master
        static IModbusSerialMaster master;

        #endregion


        #region 业务方法
        /// <summary>
        /// 创建Modbus Master
        /// </summary>
        private void CreateMaster()
        {
            SerialPort SelectedPort = SerialObj.OnlySerial;

            timer2Read.Interval = ModbusModel.ScanRate;

            LogRecordModel log = null;
            try
            {
                //序列化并写入
                _serilizer.Write(ModbusModel);

                if (SelectedPort.IsOpen)
                    SelectedPort.Close();

                SelectedPort.Open();

                var factory = new ModbusFactory();

                if (ModbusModel.UseRtu)
                    master = factory.CreateRtuMaster(SelectedPort);
                else
                    master = factory.CreateAsciiMaster(SelectedPort);

                log = new LogRecordModel()
                {
                    Content = "Modbus Master创建成功",
                    Type = LogType.Success
                };
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.Message,
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        /// <summary>
        /// 读取传感器数值
        /// </summary>
        /// <returns></returns>
        private async void ReadSensorValues(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                var ValueList = master.ReadInputRegisters(ModbusModel.SlaveId, ModbusModel.StartAddr, ModbusModel.ReadNum);

                this._dataStorage.AddDataPoint(ModbusModel.StartAddr, ModbusModel.ReadNum, DateTime.UtcNow, ValueList);
            });
        }

        /// <summary>
        /// modbus 开始读取
        /// </summary>
        /// <param name="param"></param>
        private void StartRead(object param)
        {
            LogRecordModel log = null;

            try
            {
                if (master == null)
                {
                    throw new Exception("未设置Modbus Master");
                }

                timer2Read.Start();

                GlobalValues.IsOnMointoring = true;//开始监测标志 置 true

                log = new LogRecordModel()
                {
                    Content = "已开始监测",
                    Type = LogType.Success
                };
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.ToString(),
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        /// <summary>
        /// modbus 停止读取
        /// </summary>
        /// <param name="param"></param>
        private void StopRead(object param)
        {
            LogRecordModel log = null;

            try
            {
                timer2Read.Stop();

                GlobalValues.IsOnMointoring = false;

                log = new LogRecordModel()
                {
                    Content = "已停止监测",
                    Type = LogType.Success
                };
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.ToString(),
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }


        #endregion


        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 确认 创建modbus master对象 的命令
        /// </summary>
        public RelayCommand<object> ConfirmCommand
        {
            get
            {
                return _myCommand1 ?? (_myCommand1 = new RelayCommand<object>(Confirm));
            }
        }
        private void Confirm(object param)
        {
            LogRecordModel log = null;
            try
            {
                this.CreateMaster();
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.Message,
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
                var window = param as Window;
                window.Close();
            }
        }

        #endregion
    }
}
