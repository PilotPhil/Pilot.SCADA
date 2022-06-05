using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;
using pilot.SCADA.DAL;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using pilot.SCADA.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pilot.SCADA.ViewModels
{
    class TaskFlowManageViewModel : ViewModelBase
    {
        //记录的任务列表
        public ObservableCollection<TaskModuleModel> TaskList { get; set; }

        //序列化对象
        private readonly ISerialize jsonSerialize;

        //ctor
        public TaskFlowManageViewModel(ISerialize serialize)
        {
            this.jsonSerialize = serialize;
            this.jsonSerialize.SetPath(Path.Combine(BasePath.SelectedProject.ProjectPath, "TaskManager.json"));

            TaskList = jsonSerialize.Read<ObservableCollection<TaskModuleModel>>() ?? new ObservableCollection<TaskModuleModel>();
        }

        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 添加一个任务 的命令
        /// </summary>
        public RelayCommand<object> AddOneTaskCommand
        {
            get
            {
                return _myCommand1 ?? (_myCommand1 = new RelayCommand<object>(AddOneTask));
            }
        }
        private void AddOneTask(object param)
        {
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = false;//设置为选择文件夹
                dialog.Title = "选择工程文件所在文件夹";

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    var filePath = dialog.FileName;

                    //反射加载DLL
                    Assembly assembly = Assembly.LoadFile(filePath);
                    Type type = assembly.GetType("Info.ModuleInfo");

                    BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static;

                    var ModuleName = type.GetProperty("ModuleName", bindingFlags);
                    var ModuleVersion = type.GetProperty("ModuleVersion", bindingFlags);
                    var Author = type.GetProperty("Author", bindingFlags);

                    var newModule = new TaskModuleModel()
                    {
                        ModuleName = ModuleName.GetValue(this) as string,
                        ModuleVersion = ModuleVersion.GetValue(this) as string,
                        Author = Author.GetValue(this) as string,
                        Path = filePath
                    };

                    if (TaskList.Any(inp => inp.Path == newModule.Path))//判断是否已经存在
                    {
                        LoggerRecordViewModel.GetInstance().Record(new Models.LogRecordModel()
                        {
                            RecordTime = DateTime.Now.ToString(),
                            Content = "任务已存在，添加失败",
                            Identity = Registrant.Name ?? "未登录",
                            Type = "失败"
                        });
                    }
                    else
                    {
                        TaskList.Add(newModule);
                        jsonSerialize.Write(TaskList);
                    }
                }

                //焦点集中到原来的窗口
                (param as Window).Activate();
            }
        }

        private RelayCommand<object> _myCommand2;
        /// <summary>
        /// 移除一个任务 的命令
        /// </summary>
        public RelayCommand<object> RemoveOneTaskCommand
        {
            get
            {
                return _myCommand2 ?? (_myCommand2 = new RelayCommand<object>(RemoveOneTask));
            }
        }
        private void RemoveOneTask(object param)
        {
            int index = (int)param;

            if (index < 0 || index > TaskList.Count)//超出范围
            {
                LoggerRecordViewModel.GetInstance().Record(new Models.LogRecordModel()
                {
                    RecordTime = DateTime.Now.ToString(),
                    Content = "任务移除失败，索引越界",
                    Identity = Registrant.Name ?? "未登录",
                    Type = "失败"
                });
            }
            else
            {
                TaskList.RemoveAt(index);
                LoggerRecordViewModel.GetInstance().Record(new Models.LogRecordModel()
                {
                    RecordTime = DateTime.Now.ToString(),
                    Content = "任务移除成功",
                    Identity = Registrant.Name ?? "未登录",
                    Type = "成功"
                });
            }

            jsonSerialize.Write(TaskList);
        }

        private RelayCommand<object> _myCommand3;
        /// <summary>
        /// 预览任务界面 的命令
        /// </summary>
        public RelayCommand<object> PreviewTaskViewCommand
        {
            get
            {
                return _myCommand3 ?? (_myCommand3 = new RelayCommand<object>(PreviewTaskView));
            }
        }
        private void PreviewTaskView(object param)
        {
            try
            {
                int index = (int)param;//index

                var task2preview = TaskList[index];

                Assembly assembly = Assembly.LoadFile(task2preview.Path);
                Type type = assembly.GetType("Info.ModuleInfo");

                BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static;

                var NameSpace = type.GetProperty("NameSpace", bindingFlags).GetValue(this) as string;
                var ViewClassName = type.GetProperty("ViewClassName", bindingFlags).GetValue(this) as string;

                Type ViewClass = assembly.GetType(NameSpace + "." + ViewClassName);

                object DispViewInstance = Activator.CreateInstance(ViewClass);

                new TaskPreviewView(DispViewInstance).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion
    }
}
