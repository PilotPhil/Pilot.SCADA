using GalaSoft.MvvmLight;
using LiveCharts;
using System.Collections.Generic;

namespace pilot.SCADA.Models
{
    public class DataCheckModel
    {
        /// <summary>
        /// X轴长度
        /// </summary>
        public int AxisXLength { get; set; }

        /// <summary>
        /// 更新频率
        /// </summary>
        public float UpdateFreq { get; set; }

        /// <summary>
        /// 选择要更新（显示）的数据源
        /// </summary>
        public int SelectDispIndex { get; set; }

        /// <summary>
        /// 数据点
        /// </summary>
        public SeriesCollection SeriesCollection { get; set; }

        /// <summary>
        /// 横坐标 字符标签
        /// </summary>
        public List<string> XLabels { get; set; }

        /// <summary>
        /// 是否开启获取数据
        /// </summary>
        public bool IsOnCheck { get; set; }
    }
}
