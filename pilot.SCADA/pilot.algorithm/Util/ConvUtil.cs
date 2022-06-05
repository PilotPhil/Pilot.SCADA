using pilot.Algorithm.Base;
using pilot.Algorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.Algorithm.Util
{
    sealed class ConvUtil : ConvBase, IApplyable2
    {
        Task<float[]> task;

        public object Apply2(List<float> inp1, List<float> inp2)
        {
            task = Do(inp1, inp2);
            return task.Result;
        }

        private async Task<float[]> Do(List<float> inp1,List<float> inp2)
        {
            float[] res=null;

            await Task.Run(()=> 
            {
                res=Conv(inp1.ToArray(), inp2.ToArray());
            });

            return res;
        }
    }
}
