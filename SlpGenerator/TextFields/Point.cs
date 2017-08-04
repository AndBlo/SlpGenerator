using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlpGenerator
{
    public class Point
    {
        private int _min;

        public int MinP
        {
            get { return _min; }
            set { _min = value; Score = value; }
        }
        public int MaxP { get; set; }
        public int Score { get; set; }

        public Point(int min, int max)
        {
            MinP = min;
            MaxP = max;
        }

        public Point(int min)
        {
            MinP = min;
        }

        public Point()
        {
            
        }

        public static void DistributePoints(int n, Point[] points)
        {
            List<int> intList = new List<int>();
            //for (int i = 0; i < points.Length; i++)
            //{
            //    points[i].Score = points[i].MinP;
            //    n -= points[i].MinP;
            //}
            n -= points.Sum(p => p.MinP);

            Random rand = new Random(DateTime.Now.Millisecond ^ points.Length);
            Thread.Sleep(1);

            do
            {
                for (int i = 0; i < points.Length; i++)
                {
                    int rndInt;

                    rndInt = rand.Next(0, n + 1);

                    if (rndInt + points[i].Score > points[i].MaxP)
                        rndInt = points[i].MaxP - points[i].Score;

                    points[i].Score += rndInt;
                    n -= rndInt;

                }

            } while (n != 0);

        }
    }

}
