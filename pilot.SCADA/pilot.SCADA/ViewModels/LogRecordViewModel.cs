using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.ViewModels
{
    /// <summary>
    /// 日志业务
    /// </summary>
    public class LogRecordViewModel : ViewModelBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public LogRecordViewModel()
        {
            CurrentLog = new LogRecordModel();
            LogRecordList = new List<LogRecordModel>();

            //消息注册，添加log记录--->发送体 在GlobalValue中进行了封装：public static void Log(LogRecordModel newLog);
            Messenger.Default.Register<LogRecordModel>(this, "Log", this.Record);
        }


        #region 业务方法
        /// <summary>
        /// 日志记录
        /// </summary>
        /// <param name="model"></param>
        private void Record(LogRecordModel model)
        {
            CurrentLog = model;
            LogRecordList.Add(model);
        }

        #endregion


        #region 属性
        private LogRecordModel _currentLog;
        /// <summary>
        /// 当前记录 一条
        /// </summary>
        public LogRecordModel CurrentLog
        {
            get { return _currentLog; }
            set
            {
                if (_currentLog == value) { return; }
                _currentLog = value;
                RaisePropertyChanged(() => CurrentLog);
            }
        }

        private List<LogRecordModel> _LogRecordList;
        /// <summary>
        /// 工程日志记录
        /// </summary>
        public List<LogRecordModel> LogRecordList
        {
            get { return _LogRecordList; }
            set
            {
                if (_LogRecordList == value) { return; }
                _LogRecordList = value;
                RaisePropertyChanged(() => LogRecordList);
            }
        }

        #endregion
    }


}
