using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Models
{
    /// <summary>
    /// 针对每一个传感器的task flow，存储和delegate
    /// </summary>
    class TaskFlowModel : ObservableObject
    {
        //选中的task
        public ObservableCollection<TaskModuleModel> SelectedTaskList { get; set; } = new ObservableCollection<TaskModuleModel>();
        //加载的task
        //public ObservableCollection<TaskModuleModel> LoadedTaskList { get; set; } = new ObservableCollection<TaskModuleModel>();

        //task flow 任务流代理，把算法代理，执行
        public Func<object, object> TaskFlow;
        //{
        //    TaskFlow = new Func<object, object>(do1);
        //    TaskFlow += do2;
        //    TaskFlow += do3;
        //    TaskFlow += do4;
        //    TaskFlow.Invoke();
        //}
    }
}
