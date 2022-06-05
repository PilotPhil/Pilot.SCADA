using System;
using System.Collections.Generic;

namespace pilot.Comms.DataBuffer
{
    public class RelatedDataBuffer :  IDataBuffer
    {
        /// <summary>
        /// ctor
        /// </summary>
        public RelatedDataBuffer()
        {
        }

        /// <summary>
        /// 字典：地址---值
        /// </summary>
        private Dictionary<ushort, DataFormat> CurrentData = new Dictionary<ushort, DataFormat>();


        #region 方法
        /// <summary>
        /// 添加数据点
        /// </summary>
        /// <param name="AddrKey"></param>
        /// <param name="dataModels"></param>
        public void AddDataPoint(ushort StartAddr, ushort ReadNum, DateTime TimeStamp, ushort[] ValueList)
        {
            var len = Math.Min(ReadNum, ValueList.Length);

            for (int i = 0; i < len; i++)
            {
                var key = (ushort)(StartAddr + i);
                var model = new DataFormat(TimeStamp, ValueList[i]);

                if (CurrentData.ContainsKey(key))//键值存在
                {
                    CurrentData[key] = model;
                }
                else//键值 不 存在
                {
                    CurrentData.Add(key, model);
                }
            }
        }

        /// <summary>
        /// 通过索引 地址 获取值
        /// </summary>
        /// <param name="addr"></param>
        /// <returns></returns>
        public DataFormat GetDataByAddr(ushort addr)
        {
            if (CurrentData.ContainsKey(addr))
            {
                return CurrentData[addr];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns>[0]:addrlist [1]:valuelist</returns>
        public List<List<ushort>> GetAllData()
        {
            var _AddrList = new List<ushort>();
            var _ValueList = new List<ushort>();

            foreach (var item in CurrentData)
            {
                _AddrList.Add(item.Key);
                _ValueList.Add(item.Value.value);//Value.value--->DataFormat.value
            }

            return new List<List<ushort>>() { _AddrList, _ValueList };
        }


        #endregion
    }
}
