using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.IO;
using SlpGenerator.Occupations;

namespace SlpGenerator.Occupations
{
    public class Occupation : Character
    {

        public static List<Occupation> Occupations { get; set; } = new List<Occupation>();

        public static Occupation operator +(Occupation output, Occupations.OccupationForm input)
        {
            output.Name = input.Name;
            output.Traits = input.Traits.ToArray<string>();
            output.Goals = input.Goals.ToArray<string>();
            output.SpecialBasicProperty = input.SpecialBasicProperty;
            output.Skills = input.Skills.ToArray<string>();
            output.Talents = input.Talents.ToArray<string>();
            output.Weapons = input.Weapons.ToArray<string>();
            output.AmmoDice = input.AmmoDice;
            output.FoodDice = input.FoodDice;
            output.WaterDice = input.WaterDice;
            output.HasArtifactItem = input.HasArtifactItem;
            output.HasGarbageItem = input.HasGarbageItem;

            return output;
        }

        public void LoadFromFile()
        {
            string input = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Mutant occupation file (*.mof)|*.mof";

            try
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory + "\\MOF";
            }
            catch
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }


            if (openFileDialog.ShowDialog() == true)
            {
                using (var reader = new StreamReader(openFileDialog.FileName, true))
                {
                    input = reader.ReadLine();
                }
            }
            var loaded = JsonConvert.DeserializeObject<Occupation>(input);

            if (loaded != null)
            {
                IsLoaded = true;

                Populate(loaded);
            }



        }

        private void Populate(Occupation o)
        {
            this.Name = o.Name;
            this.Traits = o.Traits;
            this.Goals = o.Goals;
            this.SpecialBasicProperty = o.SpecialBasicProperty;
            this.Skills = o.Skills;
            this.Talents = o.Talents;
            this.Weapons = o.Weapons;
            this.AmmoDice = o.AmmoDice;
            this.FoodDice = o.FoodDice;
            this.WaterDice = o.WaterDice;
            this.HasArtifactItem = o.HasArtifactItem;
            this.HasGarbageItem = o.HasGarbageItem;
        }

        public void SaveToFile()
        {
            string output = JsonConvert.SerializeObject(this);


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Mutant occupation file (*.mof)|*.mof";
            try
            {
                saveFileDialog.InitialDirectory = Environment.CurrentDirectory + "\\MOF";
            }
            catch
            {
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }


            if (saveFileDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName, true))
                {
                    writer.WriteLine(output);
                }
            }
        }

    }
}
