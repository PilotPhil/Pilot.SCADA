using pilot.Algorithm.Base;
using pilot.Algorithm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.Algorithm.Util
{
    class CumulativeDamageUtil : CumulativeDamageBase, IApplyable
    {
        Task<double> task;

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

        private async Task<double> Do(List<float> inp)
        {
            double damage = 0;
            await Task.Run(() =>
            {
                List<float> data = new List<float>(inp);

                Init(inp);
                KeepPeaksAndValleys();
                ExtractCycles();

                MeanStressCorrection();
                damage = DamageCompute();
            });

            return damage;
        }
    }
}
