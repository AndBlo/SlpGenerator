using SlpGenerator.TextFields;
using SlpGenerator.TextFields.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SlpGenerator
{
    partial class MainWindow
    {
        // Slumpar fram en komplett Slp baserat på reglerna i mutant
        private void GetRandomCharacter(Grid slp, int occu, int bp, int sbp, int sp, int maxSp, int minSp, int maxSpecSp, int skillCount, int mut)
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
            List<Label> list = LoadLabelsFromGrid(slp);

            // SetLabel - skickar in listan, uid på labeln samt den sträng som labeln ska ha som content.
            SetSingleLabels(index, list);

            // SetSkillLabel - Sätter skill-labelarna
            if (skillCount != 0)
            {
                SetSkillLabels(index, list, sp, maxSp, minSp, maxSpecSp, skillCount);
            }

            // Skapar en lista med poäng som sätts på bp-lablarna slumpvis. 
            // Summan av poängen slumpas mellan 12 (+1) och 13 (+1) och lagras i bpPoints
            // som sedan används i villkoret för if-satsen i metoden nedan för att avgöra om det
            // ska slumpas fram en eller två mutationer.
            PointList bpPoints =
            SetBPLabels(rnd, index, list, bp, sbp);

            if (mut == -1)
            {
                // slumpar mutation-labelar
                SetMutationLabels(list, bpPoints);

            }
            else
            {
                SetMutationLabels(list, mut);
            }

            // slumpar fram och sätter equip-labelar
            SetEquipLabels(index, list);
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
        private void SetEquipLabels(int index, List<Label> list)
        {
            SetLabel(list, "equip1", Occupation.GetEquipment(Occupation.GetMultiOptions(Occupation.SpecialEquipment[index])));
            SetLabel(list, "equip2", Occupation.GetRandomMultiOption(Occupation.SpecialWeapon[index]));
            SetLabel(list, "equip3", "");
            // Om sysslan som slumpats fram är Skrotskalle så läggs även en artefakt till på equipment plats 3.
            if ((list.Find(p => p.Uid == "occu")).Content as string == "SKROTSKALLE")
            {
                SetLabel(list, "equip3", Menus.SlpMenu.ThrowDice(Artifact.Artifacts.GetRandomName()));
            }
        }

        // Sätter content för mutation-labelar
        private void SetMutationLabels(List<Label> list, PointList bpPoints)
        {
                SetLabel(list, "mutat1", Mutation.Mutations.GetRandomName());
                SetLabel(list, "mutat2", "");

                // Om summan av grundpoängen är 12 så slumpas ännu en mutation fram, enligt regler.
                if (bpPoints.Sum() == 13)
                {
                // ser till att mutationerna inte är samma
                string m1 = Mutation.Mutations.GetRandomName();
                string m2 = Mutation.Mutations.GetRandomName();

                while (m1 == m2)
                {
                    m2 = Mutation.Mutations.GetRandomName();
                }

                SetLabel(list, "mutat1", m1);
                SetLabel(list, "mutat2", m2);
            }
            
        }

        // Sätter content för mutation-labelar
        private void SetMutationLabels(List<Label> list, int numberOfMutations)
        {
            if (numberOfMutations == 1)
            {
                SetLabel(list, "mutat1", Mutation.Mutations.GetRandomName());
            }
            else if (numberOfMutations == 2)
            {
                string m1 = Mutation.Mutations.GetRandomName();
                string m2 = Mutation.Mutations.GetRandomName();

                while (m1 == m2)
                {
                    m2 = Mutation.Mutations.GetRandomName();
                }

                SetLabel(list, "mutat1", m1);
                SetLabel(list, "mutat2", m2);
            }
            else if (numberOfMutations == 3)
            {
                string m1 = Mutation.Mutations.GetRandomName();
                string m2 = Mutation.Mutations.GetRandomName();
                string m3 = Mutation.Mutations.GetRandomName();

                while (m1 == m2)
                {
                    m2 = Mutation.Mutations.GetRandomName();

                    while (m2 == m3)
                    {
                        m3 = Mutation.Mutations.GetRandomName();
                    }
                }
                
                SetLabel(list, "mutat1", m1);
                SetLabel(list, "mutat2", m2);
                SetLabel(list, "mutat3", m3);
            }
        }

        // Sätter värden för Grundpoäng, bp.
        private PointList SetBPLabels(Random rnd, int index, List<Label> list, int bp, int sbp)
        {
            PointList bpPoints;

            if (sbp != -1)
            {
                bpPoints = new PointList(4, bp, 1, 4, sbp);
            }
            else if (sbp == -1)
            {
                List<String> bpsList = new List<string>()
                {
                    "sty",
                    "kyl",
                    "skp",
                    "kns"
                };

                bpPoints = new PointList(4, bp, 1, 4, bpsList.FindIndex(p => p.ToLower() == Occupation.SpecialBp[index].ToLower()));
            }
            else
            {
                bpPoints = new PointList();
            }
            
            //bpPoints.GetInitialValues(4, 2);
            //bpPoints.GetRandomValues(bp - 9, 4);

            SetLabel(list, "sty", bpPoints[0].ToString());
            SetLabel(list, "kyl", bpPoints[1].ToString());
            SetLabel(list, "skp", bpPoints[2].ToString());
            SetLabel(list, "kns", bpPoints[3].ToString());

            return bpPoints;

            //// Hittar spciella bpn för sysslan och plussar på med 1.
            //Label spec = list.Find(p => p.Uid == Occupation.SpecialBp[index].ToLower());
            //int temp = Convert.ToInt16(spec.Content) + 1;
            //spec.Content = temp;
        }


        // Sätter skill-lablar samt sätter 
        private void SetSkillLabels(int index, List<Label> list, int sp, int maxSp, int minSp, int maxSpecSp, int skillCount)
        {
            
            // Skapar ny instans av PointList för poängutdelning av skills poäng.
            PointList skillPoints = new PointList(skillCount, sp, minSp, maxSp, maxSpecSp, 0);

            if (skillCount == 1)
            {
                SetLabel(list, "skill1", Occupation.SpecialSkills[index]);

                SetLabel(list, "skillp1", skillPoints[0].ToString());
            }
            else if (skillCount == 2)
            {
                SetLabel(list, "skill1", Occupation.SpecialSkills[index]);
                SetLabel(list, "skill2", Skill.Skills.GetRandomName());

                SetLabel(list, "skillp1", skillPoints[0].ToString());
                SetLabel(list, "skillp2", skillPoints[1].ToString());
            }
            else if (skillCount == 3)
            {
                string s1 = Occupation.SpecialSkills[index];
                string s2 = Skill.Skills.GetRandomName();
                string s3 = Skill.Skills.GetRandomName();

                while (s2 == s3)
                {
                    s3 = Skill.Skills.GetRandomName();
                }

                SetLabel(list, "skill1", s1);
                SetLabel(list, "skill2", s2);
                SetLabel(list, "skill3", s3);

                SetLabel(list, "skillp1", skillPoints[0].ToString());
                SetLabel(list, "skillp2", skillPoints[1].ToString());
                SetLabel(list, "skillp3", skillPoints[2].ToString());
            }
            else if (skillCount == 4)
            {
                string s1 = Occupation.SpecialSkills[index];
                string s2 = Skill.Skills.GetRandomName();
                string s3 = Skill.Skills.GetRandomName();
                string s4 = Skill.Skills.GetRandomName();

                while (s2 == s3)
                {
                    s3 = Skill.Skills.GetRandomName();

                    while (s3 == s4)
                    {
                        s4 = Skill.Skills.GetRandomName();
                    }
                }

                SetLabel(list, "skill1", s1);
                SetLabel(list, "skill2", s2);
                SetLabel(list, "skill3", s3);
                SetLabel(list, "skill4", s4);

                SetLabel(list, "skillp1", skillPoints[0].ToString());
                SetLabel(list, "skillp2", skillPoints[1].ToString());
                SetLabel(list, "skillp3", skillPoints[2].ToString());
                SetLabel(list, "skillp4", skillPoints[3].ToString());

            }
            else if (skillCount == 5)
            {
                string s1 = Occupation.SpecialSkills[index];
                string s2 = Skill.Skills.GetRandomName();
                string s3 = Skill.Skills.GetRandomName();
                string s4 = Skill.Skills.GetRandomName();
                string s5 = Skill.Skills.GetRandomName();

                while (s2 == s3)
                {
                    s3 = Skill.Skills.GetRandomName();

                    while (s3 == s4)
                    {
                        s4 = Skill.Skills.GetRandomName();

                        while (s4 == s5)
                        {
                            s5 = Skill.Skills.GetRandomName();
                        }
                    }
                }

                SetLabel(list, "skill1", s1);
                SetLabel(list, "skill2", s2);
                SetLabel(list, "skill3", s3);
                SetLabel(list, "skill4", s4);
                SetLabel(list, "skill5", s5);

                SetLabel(list, "skillp1", skillPoints[0].ToString());
                SetLabel(list, "skillp2", skillPoints[1].ToString());
                SetLabel(list, "skillp3", skillPoints[2].ToString());
                SetLabel(list, "skillp4", skillPoints[3].ToString());
                SetLabel(list, "skillp5", skillPoints[4].ToString());
            }
            else if (skillCount == 6)
            {
                string s1 = Occupation.SpecialSkills[index];
                string s2 = Skill.Skills.GetRandomName();
                string s3 = Skill.Skills.GetRandomName();
                string s4 = Skill.Skills.GetRandomName();
                string s5 = Skill.Skills.GetRandomName();
                string s6 = Skill.Skills.GetRandomName();

                while (s2 == s3)
                {
                    s3 = Skill.Skills.GetRandomName();

                    while (s3 == s4)
                    {
                        s4 = Skill.Skills.GetRandomName();

                        while (s4 == s5)
                        {
                            s5 = Skill.Skills.GetRandomName();

                            while (s5 == s6)
                            {
                                s6 = Skill.Skills.GetRandomName();
                            }
                        }
                    }
                }

                SetLabel(list, "skill1", s1);
                SetLabel(list, "skill2", s2);
                SetLabel(list, "skill3", s3);
                SetLabel(list, "skill4", s4);
                SetLabel(list, "skill5", s5);
                SetLabel(list, "skill6", s6);

                SetLabel(list, "skillp1", skillPoints[0].ToString());
                SetLabel(list, "skillp2", skillPoints[1].ToString());
                SetLabel(list, "skillp3", skillPoints[2].ToString());
                SetLabel(list, "skillp4", skillPoints[3].ToString());
                SetLabel(list, "skillp5", skillPoints[4].ToString());
                SetLabel(list, "skillp6", skillPoints[5].ToString());
            }


        }

        // returnerar en label-lista laddad med alla labels i en grid.
        public static List<Label> LoadLabelsFromGrid(Grid slp)
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
