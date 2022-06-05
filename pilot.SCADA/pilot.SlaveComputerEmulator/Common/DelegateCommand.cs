using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace pilot.SCADA.Common
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 判断命令能否执行
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (CanExecuteFunc == null)
                return true;
            
            return this.CanExecuteFunc(parameter);
        }

        /// <summary>
        /// 命令执行
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            //this.ExecuteAction(parameter);

            ExecuteAction?.Invoke(parameter);
        }

        //要执行的Action操作
        public Action<object> ExecuteAction { get; set; }

        public Func<object,bool> CanExecuteFunc { get; set; }
    }
}
