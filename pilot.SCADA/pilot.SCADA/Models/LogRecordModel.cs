using System;

namespace pilot.SCADA.Models
{
    public class LogRecordModel
    {
        //记录时间
        public string RecordTime { get; private set; } = DateTime.Now.ToString();

        //操作员(登陆者)身份
        public LogIdentity LogIdentity { get; private set; } = LogIdentity.Developer;

        //记录内容
        public string Content { get; set; }

        //记录类型
        public LogType Type { get; set; }


    }

    public enum LogType
    {
        Success = 2,
        Failed = -1,
        Waring = 1,
        Nornal = 0
    }

    public enum LogIdentity
    {
        Developer = -1,
        Administer = 0,
        User = 2
    }
}
