using GalaSoft.MvvmLight.Messaging;
using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Global
{
    public class GlobalValues
    {
        /// <summary>
        /// 软件实例正在使用的 项目
        /// </summary>
        public static string CurrentProjectPath { get; set; } = "";//string.IsNullOrEmpty(GlobalValues.CurrentProjectPath);

        /// <summary>
        /// 系统是否正在监测
        /// </summary>
        public static bool IsOnMointoring { get; set; } = false;

        /// <summary>
        /// 写日志封装
        /// </summary>
        /// <param name="newLog"></param>
        public static void Log(LogRecordModel newLog)
        {
            if (newLog == null)
                return;

            Messenger.Default.Send<LogRecordModel>(newLog, "Log");
        }
        
        /// <summary>
        /// 传感器列表
        /// </summary>
        public static List<SensorModel> SensorList { get; set; }
    }
}
