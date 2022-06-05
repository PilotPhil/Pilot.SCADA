using LiveCharts;
using LiveCharts.Configurations;
using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.ViewModels
{
    class ConstantChangesChartViewModel
    {
        public ConstantChangesChartModel ConstantChangesChartModel { get; set; }

        public ConstantChangesChartViewModel()
        {
            var mapperIndex = Mappers.Xy<MeasureIndexModel>()
                .X(model => model.Index)
                .Y(model => model.Value);

            Charting.For<MeasureIndexModel>(mapperIndex);

            ConstantChangesChartModel = new ConstantChangesChartModel()
            {
                ChartValueIndexList = new ChartValues<MeasureIndexModel>(),
                ChartValueTimeList = new ChartValues<MeasureTimeModel>()
            };
        }

        public void AddOnePoint(MeasureIndexModel point)
        {
            ConstantChangesChartModel.ChartValueIndexList.Add(point);
        }
    }
}
