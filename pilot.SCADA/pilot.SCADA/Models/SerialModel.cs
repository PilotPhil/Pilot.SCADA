using Newtonsoft.Json;
using System.Collections.Generic;

namespace pilot.SCADA.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class SerialModel
    {
        #region 使用的串口参数
        //串口号
        public string PortName { get; set; }

        //波特率
        public int BaudRate { get; set; }

        //数据位
        public int DataBit { get; set; }

        //校验位
        public string Parity { get; set; }

        //停止位
        public string StopBit { get; set; }
        #endregion


        #region 串口参数列表-combox初始绑定ItemSource
        //端口号
        [JsonIgnore]
        public List<string> PortList { get; set; }

        //波特率
        [JsonIgnore]
        public List<int> BaudRateList { get; set; } = new List<int>()
        {
            110,
            300,
            600,
            1200,
            2400,
            4800,
            9600,
            14400,
            19200,
            38400
        };

        //数据位
        [JsonIgnore]
        public List<int> DataBitList { get; set; } = new List<int>()
        {
            6,
            7,
            8
        };

        //校验位
        [JsonIgnore]
        public List<string> ParityList { get; set; } = new List<string>()
        {
            "无",
            "偶校验",
            "奇校验"
        };

        //停止位
        [JsonIgnore]
        public List<string> StopBitList { get; set; } = new List<string>()
        {
            "1",
            "1.5",
            "2"
        };
        #endregion
    }
}
