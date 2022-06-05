using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pilot.SCADA.DAL
{
    
    class JsonSerialize
    {
        /// <summary>
        /// 路径
        /// </summary>
        public string FilePath { get; set; }

        ////序列化设置
        //JsonSerializerOptions option = new JsonSerializerOptions()
        //{
        //    WriteIndented = true//测试用，有换行
        //    //WriteIndented = false//设置为false提高写入速度，生产中用
        //};

        /// <summary>
        /// ctor-全路径，绝对路径
        /// </summary>
        /// <param name="filePath"></param>
        public JsonSerialize(string filePath)
        {
            this.FilePath = filePath;
        }

        /// <summary>
        /// 序列化并写入
        /// </summary>
        /// <param name="model"></param>
        public void SerializeWrite(object model)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(model);

                File.WriteAllText(FilePath, jsonData);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }

        /// <summary>
        /// 读出并反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DeserializeRead<T>()
        {
            try
            {
                string jsonData = File.ReadAllText(FilePath);

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
    }
}
