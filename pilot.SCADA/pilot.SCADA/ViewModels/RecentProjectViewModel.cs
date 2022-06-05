using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.ViewModels
{
    public class RecentProjectViewModel : ViewModelBase
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public RecentProjectViewModel()
        {

        }

        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 从 recentProjectViewModel 发送消息 通知 ProjectManagerViewModel打开工程 的命令
        /// </summary>
        public RelayCommand<object> OpenProjectCommand
        {
            get
            {
                return _myCommand1 ?? (_myCommand1 = new RelayCommand<object>(OpenProject));
            }
        }
        private void OpenProject(object param)
        {
            //从 recentProjectViewModel 发送消息 通知 ProjectManagerViewModel打开工程
            Messenger.Default.Send<object>(null, "OpenProjectToken");
        }

        private RelayCommand<object> _myCommand2;
        /// <summary>
        /// 从 recentProjectViewModel 发送消息 通知 ProjectManagerViewModel打开工程 的命令
        /// </summary>
        public RelayCommand<object> NewProjectCommand
        {
            get
            {
                return _myCommand2 ?? (_myCommand2 = new RelayCommand<object>(NewProject));
            }
        }
        private void NewProject(object param)
        {
            //从 recentProjectViewModel 发送消息 通知 ProjectManagerViewModel打开工程
            Messenger.Default.Send<object>(null, "OpenProjectToken");
        }
        #endregion
    }
}
