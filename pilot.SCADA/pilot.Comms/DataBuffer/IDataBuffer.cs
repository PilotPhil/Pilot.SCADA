using System;
using System.Collections.Generic;

namespace pilot.Comms.DataBuffer
{
    /// <summary>
    /// 数据缓冲区 压入数据 接口
    /// </summary>
    public interface IDataBuffer
    {
        /// <summary>
        /// 添加数据点 按照地址存入
        /// </summary>
        /// <param name="StartAddr">起始地址</param>
        /// <param name="ReadNum">读取数量</param>
        /// <param name="TimeStamp">时间戳</param>
        /// <param name="ValueList">传感器值列</param>
        void AddDataPoint(ushort StartAddr, ushort ReadNum, DateTime TimeStamp, ushort[] ValueList);

        /// <summary>
        /// 通过索引 地址 获取值
        /// </summary>
        /// <param name="addr">地址</param>
        /// <returns></returns>
        DataFormat GetDataByAddr(ushort addr);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="AddrList"></param>
        /// <param name="ValueList"></param>
        List<List<ushort>> GetAllData();


    }

}
