using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Models
{
    /// <summary>
    /// 项目记录 模型
    /// </summary>
    public class ProjectRecordModel
    {
        //正使用的项目路径---文件夹，内有多个json配置文件
        public string ProjectPath { get; set; }

        //项目名
        public string ProjectName { get; set; }

        //保存时间
        public string SaveTime { get; set; }


    }
}
