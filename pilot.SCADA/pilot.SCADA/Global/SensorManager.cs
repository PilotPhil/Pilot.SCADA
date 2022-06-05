using pilot.SCADA.Common;
using pilot.SCADA.DAL;
using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Global
{
    class SensorManager:NotificationObject
    {
        private static SensorManager _instance;

        /// <summary>
        /// ctor
        /// </summary>
        private SensorManager()
        {
            SensorList = jsonSerialize.DeserializeRead<List<SensorModel>>();
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static SensorManager GetInstance()
        {
            if(_instance==null)
            {
                _instance = new SensorManager();
            }
            return _instance;
        }

        //传感器列表
        private List<SensorModel> _sensorList;
        public List<SensorModel> SensorList
        {
            get { return _sensorList; }
            set
            {
                _sensorList = value;
                this.RaisePropertyChanged("SensorList");
            }
        }

        private readonly JsonSerialize jsonSerialize = new JsonSerialize("SensorManager.json");

        public void Save2Json()
        {
            jsonSerialize.SerializeWrite(SensorList);
        }

    }
}
