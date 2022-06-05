using pilot.SCADA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.Task.Statics
{
    public class Model:NotificationObject
    {
        //最大值
        private float _max;
        public float Max
        {
            get { return _max; }
            set
            {
                _max = value;
                this.RaisePropertyChanged("Max");
            }
        }

        //最小值
        private float _min;
        public float Min
        {
            get { return _min; }
            set
            {
                _min = value;
                this.RaisePropertyChanged("Min");
            }
        }

        //平均值
        private float _mean;
        public float Mean
        {
            get { return _mean; }
            set
            {
                _mean = value;
                this.RaisePropertyChanged("Mean");
            }
        }

        //标准差
        private float  _std;
        public float  Std
        {
            get { return _std; }
            set
            {
                _std = value;
                this.RaisePropertyChanged("Std");
            }
        }

        //偏度
        private float _skw;
        public float Skw
        {
            get { return _skw; }
            set
            {
                _skw = value;
                this.RaisePropertyChanged("Skw");
            }
        }

        //峰度
        private float _kut;
        public float Kut
        {
            get { return _kut; }
            set
            {
                _kut = value;
                this.RaisePropertyChanged("Kut");
            }
        }

        //跨零率
        private float _zcr;
        public float Zcr
        {
            get { return _zcr; }
            set
            {
                _zcr = value;
                this.RaisePropertyChanged("Zcr");
            }
        }
    }
}
