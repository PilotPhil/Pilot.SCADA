using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;



namespace pilot.SCADA.DAL
{
    // INI文件操作类
    class IniHelper
    {
        string strIniFilePath;  // ini配置文件路径

        #region DLL
        // 返回0表示失败，非0为成功
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // 返回取得字符串缓冲区的长度
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern long GetPrivateProfileString(string section, string key, string strDefault, StringBuilder retVal, int size, string filePath);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPrivateProfileInt(string section, string key, int nDefault, string filePath);
        #endregion

        #region 构造函数
        /// <summary>
        /// 无参构造函数,默认路径，默认配置文件
        /// </summary>
        /// <returns></returns>
        public IniHelper()
        {
            this.strIniFilePath = AppDomain.CurrentDomain.BaseDirectory + "com.ini";
        }
        /// <summary>
        /// 有参构造
        /// </summary>
        /// <param name="iniFile">默认Cfg文件夹内的指定iniFile文件</param>
        public IniHelper(string iniFile)
        {
            this.strIniFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Cfg\\" + iniFile;
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="strIniFilePath">ini配置文件路径</param>
        /// <param name="noUse">不使用的形参，构成重载</param>
        /// <returns></returns>
        public IniHelper(string strIniFilePath, bool noUse = true)
        {
            if (strIniFilePath != null)
            {
                this.strIniFilePath = strIniFilePath;
            }
        }
        #endregion

        #region 读写
        public string Read(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);

            long liRet = GetPrivateProfileString(section, key, "", temp, 255, strIniFilePath);
            return temp.ToString();

            //return (liRet >= 1);
        }

        public bool Write<T>(string section, string key, T val)
        {
            //if(val is string)
            //{
            //    return WriteIniString(section, key, val.ToString());
            //}
            //else if(val is int || val is bool || val is double || val is float)
            //{
            //    return WriteIniString(section, key, val.ToString());
            //}
            //else
            //{
            //    return false;
            //}

            return WriteIniString(section, key, val.ToString());
        }
        #endregion

        /// <summary>
        /// 往ini配置文件写入字符串
        /// </summary>
        /// <param name="section">节名</param>
        /// <param name="key">键名</param>
        /// <param name="val">要写入的字符串</param>
        /// <returns>成功true,失败false</returns>
        private bool WriteIniString(string section, string key, string val)
        {
            long liRet = WritePrivateProfileString(section, key, val, strIniFilePath);
            return (liRet != 0);
        }
    }
}