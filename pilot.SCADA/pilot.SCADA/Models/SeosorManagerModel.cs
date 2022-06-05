using pilot.SCADA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Models
{
    public class SeosorManagerModel
    {
        //传感器列表
        public List<SensorModel> SensorList { get; set; } = new List<SensorModel>();

    }
}
