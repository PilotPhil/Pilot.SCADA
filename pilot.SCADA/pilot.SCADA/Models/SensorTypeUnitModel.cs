using pilot.SCADA.Common;
using System.Collections.Generic;

namespace pilot.SCADA.Models
{
    public class SensorTypeUnitModel : NotificationObject
    {
        //类型列表
        private List<string> _typeList;
        public List<string> TypeList
        {
            get { return _typeList; }
            set
            {
                _typeList = value;
                this.RaisePropertyChanged("TypeList");
            }
        }

        //单位列表
        private List<string> _unitList;
        public List<string> UnitList
        {
            get { return _unitList; }
            set
            {
                _unitList = value;
                this.RaisePropertyChanged("UnitList");
            }
        }
    }
}
