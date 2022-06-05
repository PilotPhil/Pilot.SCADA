using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.WindowsAPICodePack.Dialogs;
using pilot.DAL.Serialization;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using pilot.SCADA.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace pilot.SCADA.ViewModels
{
    public class ProjectManagViewModel : ViewModelBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public ProjectManagViewModel(ISerialize serialize)
        {
            this.jsonSerialize = serialize;
            this.jsonSerialize.SetPath(BasicPath);

            ProjectRecordList = new List<ProjectRecordModel>();

            ProjectRecordList = jsonSerialize.Read<List<ProjectRecordModel>>() ?? new List<ProjectRecordModel>();

            Messenger.Default.Register<object>(this, "OpenProjectToken", this.OpenProjectFormFile);
            Messenger.Default.Register<object>(this, "NewProjectToken", this.NewProject);

            Messenger.Default.Register<ProjectRecordModel>(this, "CreateProjectToken", this.OpenProjectFromModel);
        }


        #region 属性
        //基础项目管理路径
        private readonly string BasicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cfg", "ProjectRecordList.json");

        //序列化
        private readonly ISerialize jsonSerialize;
        //是否选中过了项目
        private static bool _hasSelectedProject = false;

        private List<ProjectRecordModel> _projectRecordList;
        /// <summary>
        /// 工程记录list
        /// </summary>
        public List<ProjectRecordModel> ProjectRecordList
        {
            get { return _projectRecordList; }
            set
            {
                if (_projectRecordList == value) { return; }
                _projectRecordList = value;
                RaisePropertyChanged(() => ProjectRecordList);
            }
        }
        #endregion


        #region 业务方法
        /// <summary>
        /// 添加一个项目记录，不重复
        /// </summary>
        /// <param name="model"></param>
        private void AddOnePrj(ProjectRecordModel model)
        {
            //如果发现有重复的，修改其保存时间
            for (int i = 0; i < ProjectRecordList.Count; i++)
            {
                if (ProjectRecordList[i].ProjectPath == model.ProjectPath)
                {
                    ProjectRecordList[i].SaveTime = model.SaveTime;
                    return;
                }
            }

            ProjectRecordList.Insert(0, model);

            if (ProjectRecordList.Count > 10)//限制显示10条记录
            {
                ProjectRecordList.RemoveAt(ProjectRecordList.Count);
            }
        }

        /// <summary>
        /// 从模型打开工程
        /// </summary>
        /// <param name="model"></param>
        private void OpenProjectFromModel(ProjectRecordModel model)
        {
            LogRecordModel log = new LogRecordModel();

            try
            {
                GlobalValues.CurrentProjectPath = model.ProjectPath;
                AddOnePrj(model);

                _hasSelectedProject = true;
                Messenger.Default.Send<object>(null, "HasSelectedProjectToken");//通知mainviewmodel 已经选择了工程 跳转页面

                jsonSerialize.Write(ProjectRecordList);

                log.Content = "已打开位于" + BasicPath + "的工程";
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
            }
        }


        #endregion


        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 新建工程 的命令
        /// </summary>
        public RelayCommand<object> NewProjectCommand
        {
            get
            {
                return _myCommand1 ?? (_myCommand1 = new RelayCommand<object>(NewProject));
            }
        }
        private void NewProject(object param)
        {
            LogRecordModel log = null;
            try
            {
                if (_hasSelectedProject == true)//已经设置好当前系统实例的工程
                {
                    System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);//重开一个实例
                    return;
                }

                new NewProjectView().ShowDialog();
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

        private RelayCommand<object> _myCommand2;
        /// <summary>
        /// 打开工程 的命令
        /// </summary>
        public RelayCommand<object> OpenProjectFormFileCommand
        {
            get
            {
                return _myCommand2 ?? (_myCommand2 = new RelayCommand<object>(OpenProjectFormFile));
            }
        }
        private void OpenProjectFormFile(object param)
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;//设置为选择文件夹
                dialog.Title = "选择工程文件所在文件夹";

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    var filePath = dialog.FileName;
                    var name = filePath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Last<string>();//截取到项目名---文件夹名

                    OpenProjectFromModel(new ProjectRecordModel()
                    {
                        ProjectPath = filePath,
                        ProjectName = name,
                        SaveTime = string.Format("{0:MM/dd HH:mm}", DateTime.Now)
                    });
                }
            }

        }

        private RelayCommand<object> _myCommand3;
        /// <summary>
        /// 从记录中打开工程 的命令
        /// </summary>
        public RelayCommand<object> OpenProjectFromRecordCommand
        {
            get
            {
                return _myCommand3 ?? (_myCommand3 = new RelayCommand<object>(OpenProjectFromRecord));
            }
        }
        private void OpenProjectFromRecord(object param)
        {
            var filePath = param as string;
            var name = filePath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Last<string>();//截取到项目名---文件夹名

            OpenProjectFromModel(new ProjectRecordModel()
            {
                ProjectPath = filePath,
                ProjectName = name,
                SaveTime = string.Format("{0:MM/dd HH:mm}", DateTime.Now)
            });
        }


        #endregion
    }
}
