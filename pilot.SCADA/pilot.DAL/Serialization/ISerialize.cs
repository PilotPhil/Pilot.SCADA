using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.DAL.Serialization
{
    public interface ISerialize
    {
        /// <summary>
        /// 设置文件路径
        /// </summary>
        /// <param name="path"></param>
        void SetPath(string filePath);

        /// <summary>
        /// 将目标模型序列化写入json文件
        /// </summary>
        /// <param name="objModel"></param>
        void Write(object objModel);

        /// <summary>
        /// 从json文件读取某类型model
        /// </summary>
        T Read<T>();

    }
}
