using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using pilot.DAL.Serialization;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using pilot.SCADA.Sensor;
using pilot.SCADA.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace pilot.SCADA.ViewModels
{
    public class SensorManagerViewModel : ViewModelBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serialize"></param>
        public SensorManagerViewModel(ISerialize serialize, ISensorManage sensorsManage)
        {
            this._serialize = serialize;
            this._serialize.SetPath(Path.Combine(GlobalValues.CurrentProjectPath, "SensorList.json"));

            this._sensorsManage = sensorsManage;

            SensorList = _serialize.Read<ObservableCollection<SensorModel>>();
            SensorList = SensorList ?? new ObservableCollection<SensorModel>();

            GlobalValues.SensorList = this.SensorList.ToList();

            Messenger.Default.Register<SensorModel>(this, "Add1Sensor", this.AddOneSensor);
            Messenger.Default.Register<SensorModel>(this, "Update1Sensor", this.UpdateOneSensor);

            _sensorsManage.UpdateSensorList(this.sensorList.ToList());
        }


        #region 属性
        private readonly ISerialize _serialize;

        private readonly ISensorManage _sensorsManage;

        private ObservableCollection<SensorModel> sensorList;
        /// <summary>
        /// SensorList
        /// </summary>
        public ObservableCollection<SensorModel> SensorList
        {
            get { return sensorList; }
            set
            {
                if (sensorList == value) { return; }
                sensorList = value;
                RaisePropertyChanged(() => SensorList);
            }
        }

        #endregion


        #region 业务方法

        /// <summary>
        /// 添加一个传感器并序列化保存
        /// </summary>
        /// <param name="sensor"></param>
        private void AddOneSensor(SensorModel sensor)
        {
            LogRecordModel log = new LogRecordModel();

            try
            {
                if (SensorList.Any(cus => cus.ID == sensor.ID) == true)
                {
                    throw new Exception("传感器序号重复，重新设置序号");
                }

                SensorList.Add(sensor);
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
                _serialize.Write(SensorList);
                GlobalValues.SensorList = this.SensorList.ToList();
                _sensorsManage.UpdateSensorList(this.sensorList.ToList());
            }
        }

        /// <summary>
        /// 移除一个传感器
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        public void RemoveOneSensor(int indexID)
        {
            LogRecordModel log = new LogRecordModel();

            try
            {
                if (SensorList.Any(cus => cus.ID == indexID) == false)
                {
                    throw new Exception("指定传感器不存在");
                }

                for (int i = 0; i < SensorList.Count; i++)
                {
                    if (SensorList[i].ID == indexID)
                    {
                        SensorList.RemoveAt(i);
                    }
                }
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
                _serialize.Write(SensorList);
                GlobalValues.SensorList = this.SensorList.ToList();
                _sensorsManage.UpdateSensorList(this.sensorList.ToList());
            }
        }

        /// <summary>
        /// 更新一个传感器的信息
        /// </summary>
        /// <param name="sensor"></param>
        private void UpdateOneSensor(SensorModel sensor)
        {
            LogRecordModel log = new LogRecordModel();

            try
            {
                if (SensorList.Any(cus => cus.ID == sensor.ID) == false)
                {
                    throw new Exception("指定传感器不存在");
                }

                for (int i = 0; i < SensorList.Count; i++)
                {
                    if (SensorList[i].ID == sensor.ID)
                    {
                        SensorList[i] = sensor;
                    }
                }
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
                _serialize.Write(SensorList);
                GlobalValues.SensorList = this.SensorList.ToList();
                _sensorsManage.UpdateSensorList(this.sensorList.ToList());
            }
        }
        #endregion


        #region 命令
        private RelayCommand<object> _myCommand2;
        /// <summary>
        /// 新建传感器 的命令
        /// </summary>
        public RelayCommand<object> NewSensorCommand
        {
            get
            {
                return _myCommand2 ?? (_myCommand2 = new RelayCommand<object>(NewSensor));
            }
        }
        private void NewSensor(object param)
        {
            try
            {
                new CreateSensorView().ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private RelayCommand<object> _myCommand3;
        /// <summary>
        /// 编辑传感器 的命令
        /// </summary>
        public RelayCommand<object> EditSensorCommand
        {
            get
            {
                return _myCommand3 ?? (_myCommand3 = new RelayCommand<object>(EditSensor));
            }
        }
        private void EditSensor(object param)
        {
            try
            {
                int index = (int)param;
                var sensor2edit = SensorList[index];

                new CreateSensorView().Show();

                Messenger.Default.Send<SensorModel>(sensor2edit, "SendSensor2Edit");

                _serialize.Write(SensorList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private RelayCommand<object> _myCommand4;
        /// <summary>
        /// 删除一个传感器 的命令
        /// </summary>
        public RelayCommand<object> DeleteOneSensorCommand
        {
            get
            {
                return _myCommand4 ?? (_myCommand4 = new RelayCommand<object>(DeleteOneSensor));
            }
        }
        private void DeleteOneSensor(object param)
        {
            var index = (int)param;

            if (index < 0 || index > SensorList.Count - 1)
            {
                MessageBox.Show("该传感器不存在");
            }

            this.sensorList.RemoveAt(index);
            _serialize.Write(SensorList);
        }

        #endregion
    }
}
