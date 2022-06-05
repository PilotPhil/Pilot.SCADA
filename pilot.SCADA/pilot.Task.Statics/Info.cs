using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
    class ModuleInfo
    {
        #region 基础信息
        //模块名称
        public static string ModuleName { get; private set; } = "基础统计";
        //模块版本
        public static string ModuleVersion { get; private set; } = "0.0.2";
        //作者
        public static string Author { get; private set; } = "Pilot.Phil";
        #endregion

        #region 类信息
        //命名空间
        public static string NameSpace { get; private set; } = "pilot.Task.Statics";

        //View class name
        public static string ViewClassName { get; private set; } = "View";

        //ViewModel className
        public static string ViewModelClassName { get; private set; } = "ViewModel";
        #endregion


        //使用范例：

        //Assembly assembly = Assembly.LoadFile(Path);
        //Type type = assembly.GetType("Info.ModuleInfo");

        //BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static;

        //var NameSpace = type.GetProperty("NameSpace", bindingFlags).GetValue(this) as string;
        //var ViewClassName = type.GetProperty("DispCLassName", bindingFlags).GetValue(this) as string;

        //Type ViewClass = assembly.GetType(NameSpace + "." + ViewClassName);

        //object DispViewInstance = Activator.CreateInstance(ViewClass);
    }
}
