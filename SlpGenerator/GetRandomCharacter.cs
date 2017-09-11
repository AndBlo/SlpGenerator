using SlpGenerator.Occupations;
using SlpGenerator.TextFields;
using SlpGenerator.TextFields.Lists;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SlpGenerator
{
    partial class SlpWindow
    {
        private void GetRandomCharacter(Grid grid)
        {
            EmptyLabels(grid);

            List<Label> list =
                GetLabelsFromGrid(grid);

            Character character =
                GetCharacterByToolBarChoice();

            if (cbBasicProperties.Text.ToUpper() == "ENLIGT SYSSLA")
            {
                SetBasicPropertyPointsFromToolbar(character, character.SpecialBasicProperty);
            }
            else
            {
                SetBasicPropertyPointsFromToolbar(character, (int)Enum.Parse(typeof(Character.BpNames), cbBasicProperties.Text, true));
            }


            SetSkillPointsFromToolbar(character);

            SetLabel(list, "name", MutantHumanName.Mutants.GetRandomName());
            SetLabel(list, "occu", character.Name);
            SetLabel(list, "trait", character.GetRandomItem(character.Traits));
            SetLabel(list, "goal", character.GetRandomItem(character.Goals));
            SetLabel(list, "talent", character.GetRandomItem(character.Talents));

            SetBasicPropertyPoints(list, character);

            SetSkills(grid, list, character);

            character.MutationCount = Convert.ToInt32(cbMutationCount.Text);
            SetMutations(grid, list, character);

            SetEquipments(grid, list, GetSelectedEquipment(character), character);

        }

        private static void SetBasicPropertyPoints(List<Label> list, Character character)
        {
            SetLabel(list, "sty", character.BasicPropertyPoints[0].Score.ToString());
            SetLabel(list, "kyl", character.BasicPropertyPoints[1].Score.ToString());
            SetLabel(list, "skp", character.BasicPropertyPoints[2].Score.ToString());
            SetLabel(list, "kns", character.BasicPropertyPoints[3].Score.ToString());
        }

        private Character GetCharacterByToolBarChoice()
        {
            Character character;
            if (rbOccupationIsRandom.IsChecked == false)
            {
                character = Occupation.Occupations.Find(p => p.Name == cbOccupation.Text.ToUpper()) as Character;
            }
            else
            {
                character = Occupation.Occupations[rnd.Next(0, Occupation.Occupations.Count)] as Character;
            }

            return character;
        }

        private void SetEquipments(Grid grid, List<Label> list, List<string> equipmentList, Character character)
        {

            List<string> equipments = new List<string>();

            for (int i = 0; i < equipmentList.Count; i++)
            {
                string equipment = "";
                do
                {
                    if (equipmentList[i].ToLower().Contains("utrustning"))
                    {
                        equipment = Menus.SlpMenu.ThrowDice(character.GetEquipmentString());
                    }
                    else if (equipmentList[i].ToLower().Contains("vapen"))
                    {
                        equipment = character.GetRandomItem(character.Weapons);
                    }
                    else if (equipmentList[i].ToLower().Contains("artefakt"))
                    {
                        equipment = Menus.SlpMenu.ThrowDice(Artifact.Artifacts.GetRandomName());
                    }
                    else if (equipmentList[i].ToLower().Contains("skrot"))
                    {
                        equipment = Menus.SlpMenu.ThrowDice(Garbage.Garbages.GetRandomName());
                    }
                } while (equipments.Contains(equipment));

                equipments.Add(equipment);
            }

            for (int i = 0; i < equipments.Count; i++)
            {
                SetLabel(list,
                       ("equip" + (i + 1).ToString()),
                       equipments[i]);
            }
        }

        private void SetMutations(Grid grid, List<Label> list, Character character)
        {
            List<string> mutations = new List<string>();

            for (int i = 0; i < 4; ++i)
            {
                string mutation;
                do
                {
                    mutation = Mutation.Mutations.GetRandomName();
                }
                while (mutations.Contains(mutation));

                mutations.Add(mutation);
            }

            for (int i = 0; i < character.MutationCount; i++)
            {
                SetLabel(list,
                    ("mutat" + (i + 1).ToString()),
                    mutations[i]);
            }
        }

        private void SetSkills(Grid grid, List<Label> list, Character character)
        {
            List<string> skills = new List<string>();

            skills.Add(character.Skills[0]);

            for (int i = 0; i < character.SkillPoints.Length - 1; i++)
            {
                string skill;
                do
                {
                    skill = Skill.Skills.GetRandomName();

                } while (skills.Contains(skill));

                skills.Add(skill);
            }

            for (int i = 0; i < character.SkillPoints.Length; i++)
            {
                SetLabel(list,
                    ("skill" + (i + 1).ToString()),
                    skills[i]);

                SetLabel(list,
                    ("skillp" + (i + 1).ToString()),
                     character.SkillPoints[i].Score.ToString());
            }
        }

        private void SetBasicPropertyPointsFromToolbar(Character character, int special)
        {

            Point[] points = new Point[4];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point();

                points[i].MinP = 2;

                if (i == special)
                {
                    points[i].MaxP = 5;
                }
                else
                {
                    points[i].MaxP = 4;
                }

            }

            character.BasicPropertyPoints = points;

            Point.DistributePoints(Convert.ToInt32(cbBasicPropertyPoints.Text), character.BasicPropertyPoints);
        }

        private void SetSkillPointsFromToolbar(Character character)
        {
            Point[] points = new Point[Convert.ToInt16(cbSkillCount.Text)];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point();

                points[i].MinP = Convert.ToInt16(cbMinimumSkillPoint.Text);

                if (i == 0)
                {
                    points[i].MaxP = Convert.ToInt16(cbMaximumSpecialSkillPoint.Text);
                }
                else
                {
                    points[i].MaxP = Convert.ToInt16(cbMaximumSkillPoint.Text);
                }

            }

            character.SkillPoints = points;

            Point.DistributePoints(Convert.ToInt32(cbSkillPoints.Text), character.SkillPoints);
        }


        private List<string> GetSelectedEquipment(Character character)
        {
            List<string> list = new List<string>();

            if (rbEquipmentIsFixed.IsChecked == true)
            {
                list.Add("UTRUSTNING");
                list.Add("VAPEN");
                if (character.HasArtifactItem)
                {
                    list.Add("ARTEFAKT");
                }
                if (character.HasGarbageItem)
                {
                    list.Add("SKROT");
                }
            }
            else
            {
                if (CheckBoxEquipment1.IsChecked == true)
                    list.Add(((ComboBoxItem)cbEquipment1.SelectedItem).Content as string);
                if (CheckBoxEquipment2.IsChecked == true)
                    list.Add(((ComboBoxItem)cbEquipment2.SelectedItem).Content as string);
                if (CheckBoxEquipment3.IsChecked == true)
                    list.Add(((ComboBoxItem)cbEquipment3.SelectedItem).Content as string);
                if (CheckBoxEquipment4.IsChecked == true)
                    list.Add(((ComboBoxItem)cbEquipment4.SelectedItem).Content as string);
            }



            return list;
        }

        // returnerar en label-lista laddad med alla labels i en grid.
        public static List<Label> GetLabelsFromGrid(Grid slp)
        {

            List<Label> list = new List<Label>();
            for (int i = 0; i < slp.Children.Count; i++)
            {
                list.Add(GetLabelFromGrid(slp, i));
            }

            return list;
        }

        // Söker upp labeln i "list" som matchar den "id" som skickas in och sätter
        // "text" som content.
        public static void SetLabel(List<Label> list, string id, string text)
        {
            Label lbl = list.Find(p => p.Uid == id);
            lbl.Content = text;
        }


        // Returnerar Label från Grid
        private static Label GetLabelFromGrid(Grid slp, int index)
        {
            var btn = slp.Children[index] as Button;
            var vb = btn.Content as Viewbox;
            var lbl = vb.Child as Label;
            return lbl;
        }

    }
}
