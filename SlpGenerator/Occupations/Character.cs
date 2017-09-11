using SlpGenerator.TextFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlpGenerator.Occupations
{
    public class Character
    {
        Random rnd;

        public virtual string Name { get; set; }
        public virtual string[] Traits { get; set; }
        public virtual string[] Goals { get; set; }
        public virtual int SpecialBasicProperty { get; set; }
        public virtual string[] Skills { get; set; }
        public virtual string[] Talents { get; set; }
        public virtual string[] Weapons { get; set; }
        public virtual int AmmoDice { get; set; }
        public virtual int FoodDice { get; set; }
        public virtual int WaterDice { get; set; }
        public virtual bool HasArtifactItem { get; set; }
        public virtual bool HasGarbageItem { get; set; }
        public bool IsLoaded;

        public virtual Point[] BasicPropertyPoints { get; set; }
        public virtual Point[] SkillPoints { get; set; }
        public virtual int MutationCount { get; set; }

        public enum BpNames : int
        {
            STY = 0,
            KYL = 1,
            SKP = 2,
            KNS = 3
        }

        public virtual string GetEquipmentString()
        {
            string ammo = "PATRONER: " + AmmoDice + "T6. ";
            string food = "KRUBB: " + FoodDice + "T6. ";
            string water = "VATTEN: " + WaterDice + "T6. ";

            return ammo + food + water;
        }

        public virtual string GetRandomItem(string[] arr)
        {
            rnd = new Random();

            return arr[rnd.Next(arr.Length)];
        }
    }
}
