using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf;
using SlpGenerator.TextFields;
using SlpGenerator.TextFields.Menus.MenuList;
using SlpGenerator.TextFields.Menus.DropItem;
using System.Threading;
using SlpGenerator.TextFields.Lists;

namespace SlpGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        Random rnd = new Random();

        public MainWindow()
        {

            InitializeComponent();

            Populate();
        }

        // Slumpar fram en komplett Slp baserat på reglerna i mutant
        private void GetRandomCharacter(Grid slp)
        {
            Random rnd = new Random();
            int index = rnd.Next(0, 8);

            // Laddar in alla Labels från Grid i "list"
            List<Label> list = new List<Label>();
            for (int i = 0; i < slp.Children.Count; i++)
            {
                list.Add(GetLabelFromGrid(slp, i));
            }


            // SetLabel - skickar in listan, uid på labeln samt den sträng som labeln ska ha som content.
            SetLabel(list, "name", MutantHumanName.Mutants.GetRandomName());
            SetLabel(list, "occu", Occupation.Occupations[index]);
            SetLabel(list, "trait", Occupation.GetRandomMultiOption(Occupation.SpecialTrait[index]));
            SetLabel(list, "goal", Occupation.GetRandomMultiOption(Occupation.SpecialGoal[index]));

            // SetSkillLabel - Sätter skill-labelarna
            SetSkillLabels(index, list);

            // Skapar en lista med poäng som sätts på bp-lablarna slumpvis. 
            // Summan av poängen slumpas mellan 12 (+1) och 13 (+1) och lagras i bpPoints
            // som sedan används i villkoret för if-satsen i metoden nedan för att avgöra om det
            // ska slumpas fram en eller två mutationer.
            PointList bpPoints;
            SetBPLabels(rnd, index, list, out bpPoints);

            // slumpar mutation-labelar
            SetMutationLabels(list, bpPoints);

            SetLabel(list, "talent", Occupation.GetRandomMultiOption(Occupation.SpecialTalents[index]));
            SetLabel(list, "equip1", Occupation.GetEquipment(Occupation.GetMultiOptions(Occupation.SpecialEquipment[index])));
            SetLabel(list, "equip2", Occupation.GetRandomMultiOption(Occupation.SpecialWeapon[index]));
            SetLabel(list, "equip3", "");

            // Om sysslan som slumpats fram är Skrotskalle så läggs även en artefakt till på equipment plats 3.
            if ((list.Find(p => p.Uid == "occu")).Content as string == "SKROTSKALLE")
            {
                SetLabel(list, "equip3", Artifact.Artifacts.GetRandomName());
            }
        }

        // Sätter content för mutation-labelar
        private void SetMutationLabels(List<Label> list, PointList bpPoints)
        {
            SetLabel(list, "mutat1", Mutation.Mutations.GetRandomName());
            SetLabel(list, "mutat2", "");

            // Om summan av grundpoängen är 12 så slumpas ännu en mutation fram, enligt regler.
            if (bpPoints.Sum() == 12)
            {
                // ser till att mutationerna inte är samma
                do
                {
                    SetLabel(list, "mutat2", Mutation.Mutations.GetRandomName());

                } while ((list.Find(p => p.Uid == "mutat2").Content == (list.Find(p => p.Uid == "mutat1").Content)));
            }
        }

        // Sätter värden för Grundpoäng
        private void SetBPLabels(Random rnd, int index, List<Label> list, out PointList bpPoints)
        {
            bpPoints = new PointList();
            bpPoints.GetInitialValues(4, 2);
            bpPoints.GetRandomValues((4 + rnd.Next(0, 2)), 4);

            SetLabel(list, "sty", bpPoints[0].ToString());
            SetLabel(list, "kyl", bpPoints[1].ToString());
            SetLabel(list, "skp", bpPoints[2].ToString());
            SetLabel(list, "kns", bpPoints[3].ToString());

            // Hittar spciella bpn för sysslan och plussar på med 1.
            Label spec = list.Find(p => p.Uid == Occupation.SpecialProps[index].ToLower());
            int temp = Convert.ToInt16(spec.Content) + 1;
            spec.Content = temp;
        }

        // Sätter skill-lablar samt sätter 
        private void SetSkillLabels(int index, List<Label> list)
        {
            SetLabel(list, "skill1", Occupation.SpecialSkills[index]);
            SetLabel(list, "skill2", Skill.Skills.GetRandomName());
            do
            {
                SetLabel(list, "skill3", Skill.Skills.GetRandomName());

            } while ((list.Find(p => p.Uid == "skill3").Content == (list.Find(p => p.Uid == "skill2").Content)));

            // Skapar ny instans av PointList för poängutdelning av skills poäng.
            PointList skillPoints = new PointList();
            skillPoints.GetInitialValues(3, 1);
            skillPoints.GetRandomValues(2, 3);
            // Ser till att inte skillPoint[0] blir högre än 2 då
            // enligt reglerna för mutant ett värde initialt inte får vara större än 2
            // och inte större än 3 om det är sysslans specialskill
            while (skillPoints[0] == 3)
            {
                int temp;
                if (skillPoints[1] < 3)
                {
                    temp = skillPoints[0];
                    skillPoints[0] = skillPoints[1];
                    skillPoints[1] = temp;
                }
                else if (skillPoints[2] < 3)
                {
                    temp = skillPoints[0];
                    skillPoints[0] = skillPoints[2];
                    skillPoints[2] = temp;
                }
            }
            // plussar på ett poäng för specialskillen
            skillPoints[0] += 1;

            SetLabel(list, "skillp1", skillPoints[0].ToString());
            SetLabel(list, "skillp2", skillPoints[1].ToString());
            SetLabel(list, "skillp3", skillPoints[2].ToString());
        }

        // Söker upp labeln i "list" som matchar den "id" som skickas in och sätter
        // "text" som content.
        private void SetLabel(List<Label> list, string id, string text)
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

        // Metod för samtliga contextmenyer
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            btn.ContextMenu.IsEnabled = true;
            btn.ContextMenu.PlacementTarget = btn;
            btn.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            btn.ContextMenu.IsOpen = true;
        }


        //----------------------------------------------POPULATE-------------------------------------------------------------------------------------------

        private void Populate()
        {
            TextFields.MutantHumanName.Mutants.Load("MUTANTER.txt");
            TextFields.Occupation.Occupations.Load("SYSSLA.txt");
            TextFields.Occupation.SpecialProps.Load("SPEC_BP.txt");
            TextFields.Occupation.SpecialSkills.Load("SPEC_FARDIGHETER.txt");
            TextFields.Occupation.SpecialTalents.Load("SPEC_TALANGER.txt");
            TextFields.Occupation.SpecialEquipment.Load("SPEC_UTRUSTNING.txt");
            TextFields.Occupation.SpecialWeapon.Load("SPEC_VAPEN.txt");
            TextFields.Mutation.Mutations.Load("MUTATIONER.txt");
            TextFields.Occupation.SpecialTrait.Load("SPEC_UTSEENDE.txt");
            TextFields.Occupation.SpecialGoal.Load("SPEC_DROM.txt");
            TextFields.Skill.Skills.Load("SKILLS.txt");
            TextFields.Artifact.Artifacts.Load("ARTEFAKTER.txt");

            PopulateNameCM(NameBtn1);
            PopulateNameCM(NameBtn2);
            PopulateNameCM(NameBtn3);

            PopulateOccuCM(OccuBtn1);
            PopulateOccuCM(OccuBtn2);
            PopulateOccuCM(OccuBtn3);

            PopulateTraitCM(TraitBtn1);
            PopulateTraitCM(TraitBtn2);
            PopulateTraitCM(TraitBtn3);

            PopulateGoalCM(GoalBtn1);
            PopulateGoalCM(GoalBtn2);
            PopulateGoalCM(GoalBtn3);

            PopulateSkillCM(Skill1Btn1);
            PopulateSkillCM(Skill2Btn1);
            PopulateSkillCM(Skill3Btn1);
            PopulateSkillCM(Skill4Btn1);
            PopulateSkillCM(Skill5Btn1);
            PopulateSkillCM(Skill6Btn1);
            PopulateSkillCM(Skill1Btn2);
            PopulateSkillCM(Skill2Btn2);
            PopulateSkillCM(Skill3Btn2);
            PopulateSkillCM(Skill4Btn2);
            PopulateSkillCM(Skill5Btn2);
            PopulateSkillCM(Skill6Btn2);
            PopulateSkillCM(Skill1Btn3);
            PopulateSkillCM(Skill2Btn3);
            PopulateSkillCM(Skill3Btn3);
            PopulateSkillCM(Skill4Btn3);
            PopulateSkillCM(Skill5Btn3);
            PopulateSkillCM(Skill6Btn3);

            PopulateTalentCM(TalentsBtn1);
            PopulateTalentCM(TalentsBtn2);
            PopulateTalentCM(TalentsBtn3);

            PopulateMutationCM(MutationsBtn1);
            PopulateMutationCM(Mutations2Btn1);
            PopulateMutationCM(Mutations3Btn1);
            PopulateMutationCM(MutationsBtn2);
            PopulateMutationCM(Mutations2Btn2);
            PopulateMutationCM(Mutations3Btn2);
            PopulateMutationCM(MutationsBtn3);
            PopulateMutationCM(Mutations2Btn3);
            PopulateMutationCM(Mutations3Btn3);

            PopulateEquipmentCM(Equipment1Btn1);
            PopulateEquipmentCM(Equipment2Btn1);
            PopulateEquipmentCM(Equipment3Btn1);
            PopulateEquipmentCM(Equipment4Btn1);
            PopulateEquipmentCM(Equipment1Btn2);
            PopulateEquipmentCM(Equipment2Btn2);
            PopulateEquipmentCM(Equipment3Btn2);
            PopulateEquipmentCM(Equipment4Btn2);
            PopulateEquipmentCM(Equipment1Btn3);
            PopulateEquipmentCM(Equipment2Btn3);
            PopulateEquipmentCM(Equipment3Btn3);
            PopulateEquipmentCM(Equipment4Btn3);

            PopulatePointCM(StyBtn1);
            PopulatePointCM(KylBtn1);
            PopulatePointCM(SkpBtn1);
            PopulatePointCM(KnsBtn1);
            PopulatePointCM(StyBtn2);
            PopulatePointCM(KylBtn2);
            PopulatePointCM(SkpBtn2);
            PopulatePointCM(KnsBtn2);
            PopulatePointCM(StyBtn3);
            PopulatePointCM(KylBtn3);
            PopulatePointCM(SkpBtn3);
            PopulatePointCM(KnsBtn3);

            PopulatePointCM(SkillPoint1Btn1);
            PopulatePointCM(SkillPoint2Btn1);
            PopulatePointCM(SkillPoint3Btn1);
            PopulatePointCM(SkillPoint4Btn1);
            PopulatePointCM(SkillPoint5Btn1);
            PopulatePointCM(SkillPoint6Btn1);
            PopulatePointCM(SkillPoint1Btn2);
            PopulatePointCM(SkillPoint2Btn2);
            PopulatePointCM(SkillPoint3Btn2);
            PopulatePointCM(SkillPoint4Btn2);
            PopulatePointCM(SkillPoint5Btn2);
            PopulatePointCM(SkillPoint6Btn2);
            PopulatePointCM(SkillPoint1Btn3);
            PopulatePointCM(SkillPoint2Btn3);
            PopulatePointCM(SkillPoint3Btn3);
            PopulatePointCM(SkillPoint4Btn3);
            PopulatePointCM(SkillPoint5Btn3);
            PopulatePointCM(SkillPoint6Btn3);

        }


        // "Kastar" nya tärningar för utrustningen.
        // (Laddar om hela menyn)
        private void NewRoll(object sender, RoutedEventArgs e)
        {

            DropItem sent;
            Button btn;
            SlpGenerator.Menus.SlpMenu.GetButton(sender, out sent, out btn);

            PopulateEquipmentCM(btn);
        }


        private void PopulatePointCM(Button targetBtn)
        {
            List<string> list = new List<string>
            {
                "0", "1", "2", "3", "4", "5"
            };

            Menus.SlpMenu.point = new DropMenu
                (list,
                new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                "Point",
                false);

            targetBtn.ContextMenu = Menus.SlpMenu.point as DropMenu;
        }

        private void PopulateEquipmentCM(Button targetBtn)
        {
            Menus.SlpMenu.equipment = new DropMenu
                            ("SPECIFIKT FÖR SYSSLA",
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Equipments",
                            true);
            Menus.SlpMenu.equipment.Items.Add(new DropItem() { Header = "VAPEN" });
            Menus.SlpMenu.equipment.Items.Add(new DropItem() { Header = "UTRUSTNING" });
            Menus.SlpMenu.equipment.Items.Add(new DropItem() { Header = "ARTEFAKT" });

            // Lägger till sysslor som submenyer i "SPECIFIKT FR SYSSLA"
            ((DropItem)Menus.SlpMenu.equipment.Items[4]).AddRange(Occupation.Occupations);

            // Lägger till submenyer för vapen, utrustning och artefakter i respektive syssla
            for (int i = 0; i < ((DropItem)Menus.SlpMenu.equipment.Items[4]).Items.Count; i++)
            {
                ((((DropItem)Menus.SlpMenu.equipment.Items[4]) as DropItem).Items[i] as DropItem).Items.Add(new DropItem() { Header = "VAPEN" });
                ((((DropItem)Menus.SlpMenu.equipment.Items[4]) as DropItem).Items[i] as DropItem).Items.Add(new DropItem() { Header = "UTRUSTNING" });

                // Lägger till artefakt som submeny hos skrotskalle
                if (i == 1)
                ((((DropItem)Menus.SlpMenu.equipment.Items[4]) as DropItem).Items[1] as DropItem).Items.Add(new DropItem() { Header = "ARTEFAKT" });
            }

            // Lägger till items i respektive submeny i specifikt för syssla
            DropItem di = new DropItem();
            di = Menus.SlpMenu.equipment.Items[4] as DropItem;
            for (int i = 0; i < di.Items.Count; i++)
            {
                ((DropItem)((DropItem)di.Items[i]).Items[0]).AddRange(
                    Occupation.GetMultiOptions(
                        Occupation.SpecialWeapon[i]),
                    new RoutedEventHandler(
                        Menus.SlpMenu.SetTextFromContext));

                ((DropItem)((DropItem)di.Items[i]).Items[1]).AddItem(
                    Occupation.GetEquipment(
                        Occupation.GetMultiOptions(
                            Occupation.SpecialEquipment[i])),
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));

                if (i == 1)
                {
                    ((DropItem)((DropItem)di.Items[i]).Items[2]).AddRange(
                        Artifact.Artifacts,
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));
                }

            }

            // Lägger till vapen items i Vapen-submenyn i första menyn.
            ((DropItem)Menus.SlpMenu.equipment.Items[5]).AddRange(
                Occupation.GetAllOptions(Occupation.SpecialWeapon),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));

            // Lägger till items i utrustning
            ((DropItem)Menus.SlpMenu.equipment.Items[6]).AddItem("KASTA OM TÄRNINGAR", new RoutedEventHandler(NewRoll));
            for (int i = 0; i < Occupation.SpecialEquipment.Count; i++)
            {
                ((DropItem)Menus.SlpMenu.equipment.Items[6]).
                    AddItem(
                    Occupation.GetEquipment(
                        Occupation.GetMultiOptions(
                            Occupation.SpecialEquipment[i])),
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));
            }

            // Lägger till items i Artefakter
            ((DropItem)Menus.SlpMenu.equipment.Items[7]).AddRange(Artifact.Artifacts, new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));

            targetBtn.ContextMenu =
                Menus.SlpMenu.equipment;
        }

        private void PopulateMutationCM(Button targetBtn)
        {
            Menus.SlpMenu.mutation = new DropMenu
                            (Mutation.Mutations,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Mutations",
                            false);
            targetBtn.ContextMenu =
                Menus.SlpMenu.mutation;
        }

        private void PopulateTalentCM(Button targetBtn)
        {
            Menus.SlpMenu.talent = new DropMenu
                            (Occupation.Occupations,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Talents",
                            true);
            for (int i = 4; i < Menus.SlpMenu.trait.Items.Count; i++)
            {
                Menus.SlpMenu.talent.
                    AddItemsToSubMenu(Occupation.GetMultiOptions(Occupation.SpecialTalents[i - 4]),
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                    i);
            }
            targetBtn.ContextMenu = Menus.SlpMenu.talent;
        }

        private void PopulateSkillCM(Button targetBtn)
        {
            Menus.SlpMenu.skill = new DropMenu
                (TextFields.Skill.Skills,
                new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                "Skills",
                false);
            //Lägger till submenyn för sysslor
            Menus.SlpMenu.skill.AddSubMenu(4, "SPECIFIKT FÖR SYSSLA");
            // Lägger till sysslor i submenyn.
            Menus.SlpMenu.skill.
            AddItemsToSubMenu(Occupation.Occupations, 4);
            // Lägger till items i de olika sysslorna
            for (int i = 0; i < Occupation.Occupations.Count; i++)
            {
                Menus.SlpMenu.skill.
                    AddItemsToSubMenu(Occupation.SpecialSkills[i], new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext), 4, i);
            }
            // Lägger till DropMenu som ContextMenu.
            targetBtn.ContextMenu = Menus.SlpMenu.skill;
        }

        private void PopulateGoalCM(Button targetBtn)
        {
            Menus.SlpMenu.goal = new DropMenu
                (Occupation.Occupations,
                new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                "Goals",
                true);
            for (int i = 4; i < Menus.SlpMenu.goal.Items.Count; i++)
            {
                Menus.SlpMenu.goal.
                    AddItemsToSubMenu(Occupation.GetMultiOptions(Occupation.SpecialGoal[i - 4]),
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                    i);
            }
            targetBtn.ContextMenu = Menus.SlpMenu.goal;
        }

        private void PopulateTraitCM(Button targetBtn)
        {
            Menus.SlpMenu.trait = new DropMenu
                            (Occupation.Occupations,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Traits",
                            true);
            for (int i = 4; i < Menus.SlpMenu.trait.Items.Count; i++)
            {
                Menus.SlpMenu.trait.
                    AddItemsToSubMenu(Occupation.GetMultiOptions(Occupation.SpecialTrait[i - 4]),
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                    i);
            }
            targetBtn.ContextMenu = Menus.SlpMenu.trait;
        }

        private void PopulateOccuCM(Button targetBtn)
        {
            Menus.SlpMenu.occupation = new DropMenu
                            (Occupation.Occupations,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Occupations",
                            false);
            targetBtn.ContextMenu = Menus.SlpMenu.occupation;
        }

        private void PopulateNameCM(Button targetBtn)
        {
            Menus.SlpMenu.name = new DropMenu
                            (MutantHumanName.Mutants,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Names",
                            false);
            targetBtn.ContextMenu =
                Menus.SlpMenu.name;
        }

        //--------------------------------------------------------CONTEXTMENU-METODER----------------------------------------------------------------------------

        private void OpenContextMenu(object sender)
        {
            var btn = sender as Button;

            btn.ContextMenu.IsEnabled = true;
            btn.ContextMenu.PlacementTarget = btn;
            btn.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            btn.ContextMenu.IsOpen = true;
        }

        private void SetTextField(MenuItem mi, Label field)
        {
            field.Content =
                        (string)mi.Header == "TÖM" ?
                        "" :
                        mi.Header.ToString();
        }

        public void SetLabelContent(object sender, RoutedEventArgs e)
        {
            MenuItem sent = sender as MenuItem;
            ContextMenu cm = new ContextMenu();

            cm = sent.Parent as ContextMenu;

            Button btn = cm.PlacementTarget as Button;
            Viewbox vb = btn.Content as Viewbox;
            Label lbl = vb.Child as Label;

            SetTextField(sent, lbl);

        }
        //---------------------------------------------------KNAPPAR---------------------------------------------------

        private void button_save_window_Click(object sender, RoutedEventArgs e)
        {

            Util.SaveWindow(this, 200, "e:\\window.png", SaveBtn, SlumpSlp1, SlumpSlp2, SlumpSlp3);
        }

        private void SlumpSlp1_Click(object sender, RoutedEventArgs e)
        {
            GetRandomCharacter(Grid1);
        }

        private void SlumpSlp2_Click(object sender, RoutedEventArgs e)
        {
            GetRandomCharacter(Grid2);
        }

        private void SlumpSlp3_Click(object sender, RoutedEventArgs e)
        {
            GetRandomCharacter(Grid3);
        }
        
    }
}
