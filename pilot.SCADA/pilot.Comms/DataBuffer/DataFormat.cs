using System;

namespace pilot.Comms.DataBuffer
{
    /// <summary>
    /// 数据点 格式
    /// </summary>
    public class DataFormat
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public DateTime time { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public ushort value { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="time"></param>
        /// <param name="value"></param>
        public DataFormat(DateTime time, ushort value)
        {
            this.time = time;
            this.value = value;
        }
    }

}
