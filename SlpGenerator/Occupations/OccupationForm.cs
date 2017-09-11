using SlpGenerator.TextFields;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlpGenerator.Occupations
{
    public class OccupationForm
    {
        public string Name { get; set; }
        public ObservableCollection<string> Traits { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Goals { get; set; } = new ObservableCollection<string>();
        public int SpecialBasicProperty { get; set; }
        public ObservableCollection<string> Skills { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Talents { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Weapons { get; set; } = new ObservableCollection<string>();
        public int AmmoDice { get; set; }
        public int FoodDice { get; set; }
        public int WaterDice { get; set; }
        public bool HasArtifactItem { get; set; }
        public bool HasGarbageItem { get; set; }



        public OccupationForm()
        {
        }


        public void Empty()
        {
            Name = "";
            Traits.Clear();
            Goals.Clear();
            SpecialBasicProperty = 0;
            Skills.Clear();
            Talents.Clear();
            Weapons.Clear();
            AmmoDice = 0;
            FoodDice = 0;
            WaterDice = 0;
            HasArtifactItem = false;
            HasGarbageItem = false;
        }

        public static OccupationForm operator +(OccupationForm output, Occupation input)
        {
            output.Name = input.Name;

            if (input.Traits != null)
            {
                for (int i = 0; i < input.Traits.Length; i++)
                {
                    output.Traits.Add(input.Traits[i]);
                }
            }
            if (input.Goals != null)
            {
                for (int i = 0; i < input.Goals.Length; i++)
                {
                    output.Goals.Add(input.Goals[i]);
                }
            }
            
            output.SpecialBasicProperty = input.SpecialBasicProperty;

            if (input.Skills != null)
            {
                for (int i = 0; i < input.Skills.Length; i++)
                {
                    output.Skills.Add(input.Skills[i]);
                }
            }
            
            if ( input.Talents != null)
            {
                for (int i = 0; i < input.Talents.Length; i++)
                {
                    output.Talents.Add(input.Talents[i]);
                }
            }
            
            if (input.Weapons != null)
            {
                for (int i = 0; i < input.Weapons.Length; i++)
                {
                    output.Weapons.Add(input.Weapons[i]);
                }
            }
            
            output.AmmoDice = input.AmmoDice;
            output.FoodDice = input.FoodDice;
            output.WaterDice = input.WaterDice;
            output.HasArtifactItem = input.HasArtifactItem;
            output.HasGarbageItem = input.HasGarbageItem;

            return output;
        }
    }
}
