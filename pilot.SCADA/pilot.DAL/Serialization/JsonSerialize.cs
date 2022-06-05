using Newtonsoft.Json;
using System;
using System.IO;

namespace pilot.DAL.Serialization
{

    public class JsonSerialize : ISerialize
    {
        //json文件路径
        private string _filePath;

        /// <summary>
        /// ctor
        /// </summary>
        public JsonSerialize()
        {

        }

        /// <summary>
        /// 设置路径
        /// </summary>
        /// <param name="filePath"></param>
        public void SetPath(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// 序列化并写入
        /// </summary>
        /// <param name="model"></param>
        public void Write(object model)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(model);

                File.WriteAllText(_filePath, jsonData);
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// 读出并反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Read<T>()
        {
            try
            {
                string jsonData = File.ReadAllText(_filePath);

                T model = JsonConvert.DeserializeObject<T>(jsonData);//反序列化

                return model;
            }
            catch (FileNotFoundException)
            {
                return default;
            }
            catch (Exception)
            {
                return default;
            }

        }



        ////序列化设置
        //JsonSerializerOptions option = new JsonSerializerOptions()
        //{
        //    WriteIndented = true//测试用，有换行
        //    //WriteIndented = false//设置为false提高写入速度，生产中用
        //};
    }
}
