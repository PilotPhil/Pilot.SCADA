using pilot.SCADA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Global
{
    class BasePath
    {
        //唯一的选中的系统用的工程配置
        public static ProjectRecordModel SelectedProject { get; set; } = new ProjectRecordModel();

        

    }
}
