
using pilot.SCADA.Models;
using System.Collections.Generic;

namespace pilot.SCADA.Sensor
{
    public interface ISensorManage
    {
        void UpdateSensorList(List<SensorModel> sensorList);
        List<SensorModel> GetSensorList(List<SensorModel> sensorList);
        SensorModel GetSensorByIndex(int index);
        int? GetSensorNum();
    }
}
