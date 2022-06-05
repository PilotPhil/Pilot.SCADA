using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pilot.SCADA.ViewModels
{
    public class CreateSensorModelView : ViewModelBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public CreateSensorModelView()
        {
            Messenger.Default.Register<SensorModel>(this, "SendSensor2Edit", (model) =>
            {
                this.mode = WorkMode.Update;//修改为 更新 编辑 模式
                this.Title = "编辑传感器";

                this.SensorModel = model;
            });
        }

        /// <summary>
        /// 工作模式：创建还是修改
        /// </summary>
        private WorkMode mode = WorkMode.Create;



        #region 属性
        private SensorModel sensorModel = new SensorModel();
        /// <summary>
        /// 传感器基本信息 model
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


        private string title = "创建传感器";
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set
            {
                if (title == value) { return; }
                title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        #endregion


        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 确认创建 的命令
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
            if(mode==WorkMode.Create)
            {
                if (GlobalValues.SensorList.Any(inp => inp.ID == this.sensorModel.ID) == true)
                {
                    MessageBox.Show("传感器ID重复");
                    return;
                }
                else
                {
                    Messenger.Default.Send<SensorModel>(SensorModel, "Add1Sensor");
                    
                }
            }
            else if(mode==WorkMode.Update)
            {
                Messenger.Default.Send<SensorModel>(sensorModel, "Update1Sensor");
            }

            (param as Window).Close();
        }
        #endregion
    }

    enum WorkMode
    {
        Create,
        Update
    }
}
