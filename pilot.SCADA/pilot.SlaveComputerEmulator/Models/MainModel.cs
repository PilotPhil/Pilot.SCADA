using Newtonsoft.Json;
using pilot.SCADA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SlaveComputerEmulator.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    class MainModel:NotificationObject
    {
        //端口
        private string _com;
        public string Com
        {
            get { return _com; }
            set
            {
                _com = value;
                this.RaisePropertyChanged("Com");
            }
        }

        //可用端口列表
        private List<string> _comList;
        [JsonIgnore]
        public List<string> ComList
        {
            get { return _comList; }
            set
            {
                _comList = value;
                this.RaisePropertyChanged("ComList");
            }
        }

        //从站地址
        private byte _slaveId;
        public byte SlaveId
        {
            get { return _slaveId; }
            set
            {
                _slaveId = value;
                this.RaisePropertyChanged("SlaveId");
            }
        }

        //传感器数量
        private ushort _sensorNum;
        public ushort SensorNum
        {
            get { return _sensorNum; }
            set
            {
                _sensorNum = value;
                this.RaisePropertyChanged("SensorNum");
            }
        }

        //刷新率Hz
        private ushort _freq;
        public ushort Freq
        {
            get { return _freq; }
            set
            {
                _freq = value;
                this.RaisePropertyChanged("Freq");
            }
        }

        //值上限
        private int _upValue;
        public int UpValue
        {
            get { return _upValue; }
            set
            {
                _upValue = value;
                this.RaisePropertyChanged("UpValue");
            }
        }

        //值下限
        private int _downValue;
        public int DownValue
        {
            get { return _downValue; }
            set
            {
                _downValue = value;
                this.RaisePropertyChanged("DownValue");
            }
        }
    }
}
