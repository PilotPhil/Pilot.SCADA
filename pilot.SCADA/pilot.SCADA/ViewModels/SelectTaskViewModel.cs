using pilot.SCADA.Common;
using pilot.SCADA.DAL;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.ViewModels
{
    class SelectTaskViewModel : NotificationObject
    {
        //选中的task
        public ObservableCollection<TaskModuleModel> DispSelectedTaskList { get; set; }
        //加载的task
        public ObservableCollection<TaskModuleModel> DispLoadedTaskList { get; set; }

        //任务流 list
        private ObservableCollection<TaskFlowModel> _taskFlowList;
        public ObservableCollection<TaskFlowModel> TaskFlowList
        {
            get
            {
                return _taskFlowList;
            }
            set
            {
                _taskFlowList = value;
                jsonSerialize.SerializeWrite(TaskFlowList);
            }
        }

        JsonSerialize jsonSerialize = new JsonSerialize(Path.Combine(BasePath.SelectedProject.ProjectPath, "TaskFlowList.json"));


        /// <summary>
        /// ctor
        /// </summary>
        public SelectTaskViewModel()
        {
            //逆序列化
            TaskFlowList = jsonSerialize.DeserializeRead<ObservableCollection<TaskFlowModel>>() ?? new ObservableCollection<TaskFlowModel>();

            //同步处理流程数量与传感器数量
            var objNum = SensorManagerViewModel.GetInstance().SensorList.Count;

            while (TaskFlowList.Count != objNum)
            {
                if (TaskFlowList.Count > objNum)
                {
                    TaskFlowList.RemoveAt(TaskFlowList.Count - 1);
                }
                else if (TaskFlowList.Count < objNum)
                {
                    TaskFlowList.Add(new TaskFlowModel());
                }
            }

            jsonSerialize.SerializeWrite(TaskFlowList);

            DispSelectedTaskList = new ObservableCollection<TaskModuleModel>();
            DispLoadedTaskList = TaskFlowManageViewModel.GetInstance().TaskList;

            AddOneTaskCommand.ExecuteAction = new Action<object>(AddOneTask);
            AddOneTaskCommand.CanExecuteFunc = new Func<object, bool>(o => true);

            RemoveOneTaskCommand.ExecuteAction = new Action<object>(RemoveOneTask);
            RemoveOneTaskCommand.CanExecuteFunc = new Func<object, bool>(o => true);
        }

        /// <summary>
        /// 添加一个任务
        /// </summary>
        public DelegateCommand AddOneTaskCommand { get; set; } = new DelegateCommand();
        private void AddOneTask(object param)
        {
            int index = (int)param;

            var tasks = TaskFlowManageViewModel.GetInstance().TaskList;

            if (index < 0 || index > tasks.Count - 1)
            {
                return;
            }
            else
            {
                var toAddTask = tasks.ElementAt(index);

                //是否重复
                if (this.DispSelectedTaskList.Any(inp => inp.Path == toAddTask.Path) == true)
                {
                    return;
                }

                this.DispSelectedTaskList.Add(toAddTask);
            }
        }

        /// <summary>
        /// 移除一个任务
        /// </summary>
        public DelegateCommand RemoveOneTaskCommand { get; set; } = new DelegateCommand();
        private void RemoveOneTask(object param)
        {
            int index = (int)param;

            if (index < 0 || index > this.DispSelectedTaskList.Count - 1)
            {
                return;
            }
            else
            {
                this.DispSelectedTaskList.RemoveAt(index);
            }
        }
    }
}
