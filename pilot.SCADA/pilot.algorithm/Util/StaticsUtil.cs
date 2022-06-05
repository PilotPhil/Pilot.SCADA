using pilot.Algorithm.Base;
using pilot.Algorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.Algorithm.Util
{
    public class StaticsUtil : StaticsBase, IApplyable
    {
        Task<float[]> task;

        /// <summary>
        /// 总的计算
        /// </summary>
        /// <param name="inp"></param>
        /// <returns></returns>
        public object Apply2(List<float> inp)
        {
            task = Do(inp);
            return task.Result;
        }

        private async Task<float[]> Do(List<float> inp)
        {
            float[] res = new float[7];

            await Task.Run(() =>
            {
                res[0] = this.Calculate(inp, MaxFun);
                res[1] = this.Calculate(inp, MinFun);
                res[2] = this.Calculate(inp, MeanFun);
                res[3] = this.Calculate(inp, StdFun);
                res[4] = this.Calculate(inp, SkwFun); 
                res[5] = this.Calculate(inp, KutFun);
                res[6] = this.Calculate(inp, ZcrFun);
            });

            return res;
        }
    }
}
