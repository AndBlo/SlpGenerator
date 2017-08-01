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

        public PointList()
        {
            
        }

        // Konstruktor som skapar ny pointlist med färdigslumpade värden
        public PointList(int count, int sum, int min, int max, int specialIndex)
        {
            if ((count * min) >= sum)
            {
                this.GetInitialValues(count, 0);
                this.GetRandomValues(sum - 1, max);
                if (sum != 0)
                {

                }
            }
            else
            {
                // Skapar en pointlist med antal element(count) där varje
                // element får värdet min.
                this.GetInitialValues(count, min);

                // Delar ut poäng slumpvis över elementen. Eftersom
                // att elementen redan har fått ett minimivärde så dras
                // det av från  summan som skickas in tillsammans med det sista
                // poänget som ska tilldelas specialIndex. max är värdet som
                // ett element max får ha.
                this.GetRandomValues(sum - (1 + min * count), max);

                // Specialen plussas på med 1
                this[specialIndex] += 1;
            }
        }

        // Konstruktor som skapar ny pointlist med färdigslumpade värden
        public PointList(int count, int sum, int min, int max, int specMax, int specialIndex)
        {
            if ((count * min) == sum)
            {
                this.GetInitialValues(count, min);
                this.GetRandomValues(sum - (count * min), max);
                if (sum != 0)
                {

                }
            }
            else
            {
                // Skapar en pointlist med antal element(count) där varje
                // element får värdet min.
                this.GetInitialValues(count, min);

                // Delar ut poäng slumpvis över elementen. Eftersom
                // att elementen redan har fått ett minimivärde så dras
                // det av från  summan som skickas in tillsammans med det sista
                // poänget som ska tilldelas specialIndex. max är värdet som
                // ett element max får ha.
                this.GetRandomValues(sum - ((specMax - max) + (min * count)), max);

                // Specialen plussas på med 1
                if (this[specialIndex] == specMax)
                {
                    for (int i = 0; i < this.Count; i++)
                    {
                        if (i != specialIndex && this[i] < max)
                        {
                            this[i] += specMax - max;
                        }
                    }
                }
                else
                {
                    this[specialIndex] += (specMax - max);
                }
                
            }
        }

        public virtual PointList GetRandomValues(int sum, int maxPoint)
        {
            int maxSize = this.Count();
            Random = new Random();
            int rndRes;
            int counter = 0;

            while (sum > 0)
            {
                // När counter uppnår storleken på listan så nollas den
                if (counter == maxSize)
                {
                    counter = 0;
                }

                if (this.Sum() / maxSize == maxPoint)
                {
                    break;
                }
                // Om aktuellt index värde är större än maxpoängen för listan så hoppar den
                // till nästa index
                else if (this[counter] == maxPoint)
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
