using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class SensorModel : ObservableObject
    {
        #region 基础信息
        private int id;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set
            {
                if (id == value) { return; }
                id = value;
                RaisePropertyChanged(() => ID);
            }
        }

        private string name;
        /// <summary>
        /// 名
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) { return; }
                name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        private string location;
        /// <summary>
        /// Location
        /// </summary>
        public string Location
        {
            get { return location; }
            set
            {
                if (location == value) { return; }
                location = value;
                RaisePropertyChanged(() => Location);
            }
        }

        private string type;
        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get { return type; }
            set
            {
                if (type == value) { return; }
                type = value;
                RaisePropertyChanged(() => Type);
            }
        }

        private uint dataSourceIndex;
        /// <summary>
        /// 使用数据源索引
        /// </summary>
        public uint DataSourceIndex
        {
            get { return dataSourceIndex; }
            set
            {
                if (dataSourceIndex == value) { return; }
                dataSourceIndex = value;
                RaisePropertyChanged(() => DataSourceIndex);
            }
        }

        private bool isEnable;
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                if (isEnable == value) { return; }
                isEnable = value;
                RaisePropertyChanged(() => IsEnable);
            }
        }

        private string unit;
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set
            {
                if (unit == value) { return; }
                unit = value;
                RaisePropertyChanged(() => Unit);
            }
        }

        #endregion

        //task list
        [JsonIgnore]
        public ObservableCollection<TaskModuleModel> TaskList { get; set; } = new ObservableCollection<TaskModuleModel>();

        [JsonIgnore]
        public Func<object, object> TaskFlow;

        //传感 类型list
        [JsonIgnore]
        public ObservableCollection<string> TypeList { get; private set; } = new ObservableCollection<string>()
        {
            "应变","加速度","速度","角度","温度","长度","压强","应力"
        };

        //单位 类型list
        [JsonIgnore]
        public ObservableCollection<string> UnitList { get; private set; } = new ObservableCollection<string>()
        {
            "mm","m","m^2/s","-","°C","°F","N","MPa"
        };
    }
}
