using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlpGenerator.TextFields.Lists
{
    public class PointList : List<int>
    {

        protected Random Random;

        public virtual PointList GetRandomValues(int sum, int maxPoint)
        {
            int maxSize = this.Count();
            Random = new Random();
            int rndRes;
            int counter = 0;

            while (sum > 0)
            {

                if (counter == maxSize)
                {
                    counter = 0;
                }

                if (this[counter] == maxPoint)
                {
                    counter++;
                    continue;
                }

                rndRes = Random.Next(2);
                this[counter] += rndRes;
                sum -= rndRes;

                counter++;

            }

            return this;
        }

        public virtual PointList GetInitialValues(int count, int value)
        {
            for (int i = 0; i < count; i++)
            {
                this.Add(value);
            }

            return this;
        }
    }
}
