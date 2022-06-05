using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.Algorithm.Base
{
    using DF = List<float>;//类似于typedef

    /// <summary>
    /// 雨流计数法用的数据类型
    /// </summary>
    class RainFlowDataModel
    {
        public DF Index { get; set; } = new DF();//索引
        public DF Range { get; set; } = new DF();//幅值
        public DF Mean { get; set; } = new DF(); //均值
        public DF Count { get; set; } = new DF();//计数
        public DF Start { get; set; } = new DF();//起始点
        public DF End { get; set; } = new DF();  //终止点

        /// <summary>
        /// 清除所有成员
        /// </summary>
        public void ClearAll()
        {
            Index.Clear();
            Range.Clear();
            Mean.Clear();
            Count.Clear();
            Start.Clear();
            End.Clear();
        }
    }
}
