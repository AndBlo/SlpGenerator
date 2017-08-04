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
    partial class MainWindow
    {
        // Slumpar fram en komplett Slp baserat på reglerna i mutant
        private void GetRandomCharacter(Grid slp, int occu, int bp, int sbp, int sp, int maxSp, int minSp, int maxSpecSp, int skillCount, int mut, List<string> equipList)
        {
            EmptyLabels(slp);

            Random rnd = new Random();
            int index;
            if (occu == -1)
            {
                // Slumpar fram ett värde från 0 till 7 som motsvarar en syssla
                index = rnd.Next(0, 8);
            }
            else
            {
                index = occu;
            }
            

            // Laddar in alla Labels från Grid i "list"
            List<Label> list = GetLabelsFromGrid(slp);

            SetLabel(list, "name", MutantHumanName.Mutants.GetRandomName());
            SetLabel(list, "occu", Occupation.Occupations[index]);
            SetLabel(list, "trait", Occupation.GetRandomMultiOption(Occupation.SpecialTrait[index]));
            SetLabel(list, "goal", Occupation.GetRandomMultiOption(Occupation.SpecialGoal[index]));
            SetLabel(list, "talent", Occupation.GetRandomMultiOption(Occupation.SpecialTalents[index]));

            // SetSkillLabel - Sätter skill-labelarna
            if (skillCount != 0)
            {
                SetSkillLabels(index, list, sp, maxSp, minSp, maxSpecSp, skillCount);
            }

            SetBPLabels(rnd, index, list, bp, sbp);

            SetMutationLabels(list, mut);

            // slumpar fram och sätter equip-labelar
            SetEquipLabels(index, list, equipList);
        }

        // Metod för de fält som bara har en av varje kategori.
        private void SetSingleLabels(int index, List<Label> list)
        {
            SetLabel(list, "name", MutantHumanName.Mutants.GetRandomName());
            SetLabel(list, "occu", Occupation.Occupations[index]);
            SetLabel(list, "trait", Occupation.GetRandomMultiOption(Occupation.SpecialTrait[index]));
            SetLabel(list, "goal", Occupation.GetRandomMultiOption(Occupation.SpecialGoal[index]));
            SetLabel(list, "talent", Occupation.GetRandomMultiOption(Occupation.SpecialTalents[index]));
        }

        // Sätter equip-labels
        private void SetEquipLabels(int index, List<Label> list, List<string> equipList)
        {
            List<string> equipments = new List<string>();

            for (int i = 0; i < equipList.Count; i++)
            {
                string equipment = "";
                do
                {
                    if (equipList[i].ToLower().Contains("utrustning"))
                    {
                        equipment = Occupation.GetEquipment(Occupation.GetMultiOptions(Occupation.SpecialEquipment[index]));
                    }
                    else if (equipList[i].ToLower().Contains("vapen"))
                    {
                        equipment = Occupation.GetRandomMultiOption(Occupation.SpecialWeapon[index]);
                    }
                    else if (equipList[i].ToLower().Contains("artefakt"))
                    {
                        equipment = Menus.SlpMenu.ThrowDice(Artifact.Artifacts.GetRandomName());
                    }
                    else if (equipList[i].ToLower().Contains("skrot"))
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
            

            //SetLabel(list, "equip1", Occupation.GetEquipment(Occupation.GetMultiOptions(Occupation.SpecialEquipment[index])));
            //SetLabel(list, "equip2", Occupation.GetRandomMultiOption(Occupation.SpecialWeapon[index]));
            //SetLabel(list, "equip3", "");
            //// Om sysslan som slumpats fram är Skrotskalle så läggs även en artefakt till på equipment plats 3.
            //if ((list.Find(p => p.Uid == "occu")).Content as string == "SKROTSKALLE")
            //{
            //    SetLabel(list, "equip3", Menus.SlpMenu.ThrowDice(Artifact.Artifacts.GetRandomName()));
            //}
        }

        // Sätter content för mutation-labelar
        private void SetMutationLabels(List<Label> list, int mutationCount)
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

            for (int i = 0; i < mutationCount; i++)
            {
                SetLabel(list,
                    ("mutat" + (i + 1).ToString()),
                    mutations[i]);
            }
        }

        // Sätter värden för Grundpoäng, bp.
        private void SetBPLabels(Random rnd, int index, List<Label> list, int bp, int sbp)
        {

            int specIndex;

            if (sbp == -1)
            {
                List<String> bpsList = new List<string>()
                {
                    "sty",
                    "kyl",
                    "skp",
                    "kns"
                };

                specIndex = bpsList.FindIndex(p => p.ToLower() == Occupation.SpecialBp[index].ToLower());

            }
            {
                specIndex = sbp;
            }

            Point[] points = new Point[4];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point();

                points[i].MinP = 2;

                if (i == specIndex)
                {
                    points[i].MaxP = 5;
                }
                else
                {
                    points[i].MaxP = 4;
                }
            }

            Point.DistributePoints(bp, points);
            
            SetLabel(list, "sty", points[0].Score.ToString());
            SetLabel(list, "kyl", points[1].Score.ToString());
            SetLabel(list, "skp", points[2].Score.ToString());
            SetLabel(list, "kns", points[3].Score.ToString());
        }


        // Sätter skill-lablar samt sätter 
        private void SetSkillLabels(int index, List<Label> list, int sp, int maxSp, int minSp, int maxSpecSp, int skillCount)
        {

            // Skapar ny instans av PointList för poängutdelning av skills poäng.
            //PointList skillPoints = new PointList(skillCount, sp, minSp, maxSp, maxSpecSp, 0);

            Point[] points = new Point[skillCount];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point();

                points[i].MinP = minSp;

                if (i == 0)
                {
                    points[i].MaxP = maxSpecSp;
                }
                else
                {
                    points[i].MaxP = maxSp;
                }
                
            }

            Point.DistributePoints(sp, points);

            List<string> skills = new List<string>();
            // Lägger till den första färdigheten som är specifik för sysslan.
            skills.Add(Occupation.SpecialSkills[index]);

            // For-loop med skillCount - 1 då i villkoret d första färdigheten redan är satt.
            // Lagrar antalet färdigheter i skills och kollar så att inte samma färdighet läggs
            // till två gånger
            for (int i = 0; i < skillCount - 1; i++)
            {
                string skill;
                do
                {
                    skill = Skill.Skills.GetRandomName();

                } while (skills.Contains(skill));

                skills.Add(skill);
            }

            for (int i = 0; i < skillCount; i++)
            {
                SetLabel(list,
                    ("skill" + (i + 1).ToString()),
                    skills[i]);

                SetLabel(list,
                    ("skillp" + (i + 1).ToString()),
                     points[i].Score.ToString());
            }
            
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
