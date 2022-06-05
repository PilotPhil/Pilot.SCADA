using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Sensor
{
    public class SensorCollection : ISensorManage
    {
        private List<SensorModel> sensorList = new List<SensorModel>();

        public SensorModel GetSensorByIndex(int index)
        {
            if (sensorList == null || index < 0 || index > sensorList.Count - 1)
            {
                return null;
            }
            else
            {
                return sensorList[(int)index];
            }
        }

        public int? GetSensorNum()
        {
            return sensorList?.Count;
        }

        public void UpdateSensorList(List<SensorModel> sensorList)
        {
            this.sensorList = sensorList;
        }

        List<SensorModel> ISensorManage.GetSensorList(List<SensorModel> sensorList)
        {
            return this.sensorList;
        }
    }
}
