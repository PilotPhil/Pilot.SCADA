
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using pilot.DAL.Serialization;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pilot.SCADA.ViewModels
{
    [JsonObject(MemberSerialization.OptIn)]
    public class NewProjectViewModel : ViewModelBase
    {
        //默认新建工程path
        public static string DefaultProjectPath { get; set; }

        //新建工程名
        private string _newPrjName;
        public string NewPrjName
        {
            get { return _newPrjName; }
            set
            {
                _newPrjName = value;
                this.RaisePropertyChanged("NewPrjName");
            }
        }

        //新建工程路径
        private string _newPrjPath;
        public string NewPrjPath
        {
            get { return _newPrjPath; }
            set
            {
                _newPrjPath = value;
                this.RaisePropertyChanged("NewPrjPath");
            }
        }

        //是否选中为默认项目创建地址
        private bool _isSetDefaultPrjPath;
        public bool IsSetDefaultPrjPath
        {
            get { return _isSetDefaultPrjPath; }
            set
            {
                _isSetDefaultPrjPath = value;
                this.RaisePropertyChanged("IsSetDefaultPrjPath");
            }
        }

        //基础项目管理路径
        public static string BasicPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        //序列化
        private readonly ISerialize jsonSerialize;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serialize"></param>
        public NewProjectViewModel(ISerialize serialize)
        {
            this.jsonSerialize = serialize;
            this.jsonSerialize.SetPath(Path.Combine(BasicPath, "Cfg", "DefaultPrjPath.json"));//序列化 默认项目创建地址

            DefaultProjectPath = jsonSerialize.Read<string>();
            DefaultProjectPath = DefaultProjectPath ?? "";
            NewPrjPath = DefaultProjectPath;
        }


        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 确认创建新工程 的命令
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
            LogRecordModel log = new LogRecordModel();

            try
            {
                if (NewPrjPath == null || NewPrjPath == "" || NewPrjName == null || NewPrjName == "")
                {
                    throw new Exception("工程名和工程路径不能为空");
                }

                Directory.CreateDirectory(NewPrjPath + "\\" + NewPrjName);

                if (IsSetDefaultPrjPath == true)
                {
                    jsonSerialize.Write(DefaultProjectPath);
                }

                var newPrjModel = new ProjectRecordModel()
                {
                    ProjectName = NewPrjName,
                    ProjectPath = NewPrjPath,
                    SaveTime = string.Format("{0:MM/dd HH:mm}", DateTime.Now)
                };

                Messenger.Default.Send<ProjectRecordModel>(newPrjModel, "CreateProjectToken");

                log.Content = "已创建位于" + NewPrjName + "的工程" + NewPrjName;
                log.Type = LogType.Success;
            }
            catch (Exception ex)
            {
                log.Content = ex.Message;
                log.Type = LogType.Failed;
            }
            finally
            {
                GlobalValues.Log(log);
                (param as Window).Close();
            }
        }

        private RelayCommand<object> _myCommand2;
        /// <summary>
        /// 取消并关闭窗口 的命令
        /// </summary>
        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _myCommand2 ?? (_myCommand2 = new RelayCommand<object>(Cancel));
            }
        }
        private void Cancel(object param)
        {
            (param as Window).Close();
        }

        private RelayCommand<object> _myCommand3;
        /// <summary>
        /// 选择项目路径 的命令
        /// </summary>
        public RelayCommand<object> ChoosePathCommand
        {
            get
            {
                return _myCommand3 ?? (_myCommand3 = new RelayCommand<object>(ChoosePath));
            }
        }
        private void ChoosePath(object param)
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;//设置为选择文件夹
                dialog.Title = "选择工程文件所在文件夹";
                dialog.InitialDirectory = DefaultProjectPath;//初始path

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    var path = dialog.FileName;
                    DefaultProjectPath = path;
                    this.NewPrjPath = path;
                }

                (param as Window).Activate();//选择完路径后将新建工程view设为激活的，放在上层
            }
        }

        #endregion
    }


}
