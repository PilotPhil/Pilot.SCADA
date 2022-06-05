using pilot.Algorithm.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using pilot.Algorithm.Interface;
using pilot.Algorithm.Base;

namespace pilot.Algorithm
{
    public class TestAlgorithm
    {
        static void Main()
        {
            //1.测试统计
            TestStatics();

            //2.测试fatigue
            TestCumulativeDamage();

            //3.测试卷积
            TestConv();

            Console.ReadLine();
        }

        static void TestStatics()
        {
            List<float> inp = new List<float>() { 3, -8, 1, 5, 3, 2, 9 };

            StaticsUtil statics = new StaticsUtil();

            float[] res = statics.Apply2(inp) as float[];

            Console.WriteLine("Max:" + res[0]);
            Console.WriteLine("Min:" + res[1]);
            Console.WriteLine("mean:" + res[2]);
            Console.WriteLine("std:" + res[3]);
            Console.WriteLine("skw:" + res[4]);
            Console.WriteLine("kut:" + res[5]);
            Console.WriteLine("zcr:" + res[6]);

        }

        static void TestCumulativeDamage()
        {
            List<float> inp = new List<float>() { 3, -8, 1, 5, 3, 2, 9, 2, -4, 2, -5, -22, 54, 10.4f, 43, 3.2f, 0.4f, -9, 4 };

            CumulativeDamageUtil cumulativeDamageUtil = new CumulativeDamageUtil();
            cumulativeDamageUtil.K = 5.8E12f;
            cumulativeDamageUtil.UStress = 235;

            double res = (double)cumulativeDamageUtil.Apply2(inp);
            Console.WriteLine("damage:" + res);
        }

        static void TestConv()
        {
            ConvUtil convUtil = new ConvUtil();
            List<float> inp1 = new List<float> { 1, 2, 3, 4, 5, 6 };
            List<float> inp2 = new List<float> { -4, 5, 2, -1, -4, 3 };

            float[] res = convUtil.Apply2(inp1, inp2) as float[];

            Console.WriteLine("Conv Result:");
            foreach (var item in res)
            {
                Console.Write(item.ToString() + " , ");
            }
        }
    }
}
