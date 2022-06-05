using pilot.SCADA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pilot.Algorithm.Util;
using System.Timers;

namespace pilot.Task.Statics
{
    class ViewModel:NotificationObject
    {

        //统计模型
        private Model _staticsModel;
        public Model StaticsModel
        {
            get { return _staticsModel; }
            set
            {
                _staticsModel = value;
                this.RaisePropertyChanged("StaticsModel");
            }
        }

        //ctor
        public ViewModel()
        {
            StaticsModel = new Model();
            timer4Task.Interval = 10000;//10S
            //timer4Task.Elapsed += DoProcess;
        }

        /// <summary>
        /// 做计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void DoProcess(object sender, ElapsedEventArgs e)
        //{
        //    float[] res=staticsUtil.Apply2(new List<float>()) as float[];
        //    StaticsModel.Max = res[0];
        //    StaticsModel.Min = res[1];
        //    StaticsModel.Mean = res[2];
        //    StaticsModel.Std = res[3];
        //    StaticsModel.Skw = res[4];
        //    StaticsModel.Kut = res[5];
        //    StaticsModel.Zcr = res[6];
        //}

        //用于执行task的计时器
        private Timer timer4Task = new Timer();

        //统计算法 应用
        //StaticsUtil staticsUtil = new StaticsUtil();
    }
}
