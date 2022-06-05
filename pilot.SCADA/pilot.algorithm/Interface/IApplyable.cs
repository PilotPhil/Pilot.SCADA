using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilot.Algorithm.Interface
{
    /// <summary>
    /// 算法可应用接口
    /// </summary>
    interface IApplyable
    {
        object Apply2(List<float> inp);
    }

    interface IApplyable2
    {
        object Apply2(List<float> inp1, List<float> inp2);
    }
}
