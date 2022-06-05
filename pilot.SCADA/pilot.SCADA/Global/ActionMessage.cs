using pilot.SCADA.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.SCADA.Global
{
    class ActionMessage:NotificationObject
    {
        private static ActionMessage _instance;

        /// <summary>
        /// ctor
        /// </summary>
        private ActionMessage()
        {
            MsgDisp = "就绪";
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static ActionMessage GetInstance()
        {
            if(_instance==null)
            {
                _instance = new ActionMessage();
            }
            return _instance;
        }

        private string _msgDisp;
        public string MsgDisp
        {
            get { return _msgDisp; }
            set
            {
                _msgDisp = value;
                this.RaisePropertyChanged("MsgDisp");
            }
        }

        /// <summary>
        /// 设置消息提醒
        /// </summary>
        /// <param name="msg"></param>
        public void SetMsg(string msg)
        {
            this.MsgDisp = msg;
        }
    }
}
