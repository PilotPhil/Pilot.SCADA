using LiveCharts;
using pilot.SCADA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Models
{
    public class ConstantChangesChartModel:NotificationObject
    {
        public ChartValues<MeasureIndexModel> ChartValueIndexList { get; set; }
        public ChartValues<MeasureTimeModel> ChartValueTimeList { get; set; }
    }

    public class MeasureIndexModel
    {
        public int Index { get; set; }
        public float Value { get; set; }
    }

    public class MeasureTimeModel
    {
        public string Time { get; set; }
        public float Value { get; set; }
    }
}
