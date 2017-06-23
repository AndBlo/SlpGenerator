using System;
using System.Collections.Generic;
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

namespace SlpGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random rnd = new Random();

        public MainWindow()
        {
            
            InitializeComponent();
            Populate();
            PopulateContextMenu(NameCM1_1, TextFields.MutantHumanName.Mutants);
            PopulateContextMenu(TraitCM1_1, TextFields.Occupation.GetAllOptions(TextFields.Occupation.SpecialTrait));
            PopulateContextMenu(GoalCM1_1, TextFields.Occupation.GetAllOptions(TextFields.Occupation.SpecialGoal));
            PopulateContextMenu(SkillCM1_1, TextFields.Occupation.SpecialSkills);
            PopulateContextMenu(SkillCM2_1, TextFields.Skill.Skills);
            PopulateContextMenu(SkillCM3_1, TextFields.Skill.Skills);
            PopulateContextMenu(SkillCM4_1, TextFields.Skill.Skills);
            PopulateContextMenu(SkillCM5_1, TextFields.Skill.Skills);
            PopulateContextMenu(SkillCM6_1, TextFields.Skill.Skills);
            PopulateContextMenu(MutationCM1_1, TextFields.Occupation.GetAllOptions(TextFields.Mutation.Mutations));
            PopulateContextMenu(MutationCM2_1, TextFields.Occupation.GetAllOptions(TextFields.Mutation.Mutations));
            PopulateContextMenu(MutationCM3_1, TextFields.Occupation.GetAllOptions(TextFields.Mutation.Mutations));
            PopulateContextMenu(TalentCM1_1, TextFields.Occupation.GetAllOptions(TextFields.Occupation.SpecialTalents));

            SetInitialSpinnerValue(SkillPoint1Spinner1);
            SetInitialSpinnerValue(SkillPoint2Spinner1);
            SetInitialSpinnerValue(SkillPoint3Spinner1);
            SetInitialSpinnerValue(SkillPoint4Spinner1);
            SetInitialSpinnerValue(SkillPoint5Spinner1);
            SetInitialSpinnerValue(SkillPoint6Spinner1);
        }

        private void IntUpDownDefaultValue(Xceed.Wpf.Toolkit.IntegerUpDown iud)
        {
            if(iud.Value == -1)
            {
                iud.Text = "";
            }
        }

        private void SetInitialSpinnerValue(Xceed.Wpf.Toolkit.IntegerUpDown iud)
        {
            iud.Text = "";
            iud.ShowButtonSpinner = false;
        }

        private void SkillPoint1Spinner1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            IntUpDownDefaultValue(sender as Xceed.Wpf.Toolkit.IntegerUpDown);
        }

        enum OccupationEnum
        {
            Krossare,
            Skrotskalle,
            Zonstrykare,
            Fixare,
            MutantMedHund,
            Krönikör,
            Boss,
            Slav

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

        }

        //--------------------------------------------------------CONTEXTMENU-METODER----------------------------------------------------------------------------

        private void RandomizeName_Click(object sender, RoutedEventArgs e)
        {
            
            MenuItem mi = sender as MenuItem;

            // Kolumn 1
            if ((int)mi.Tag == 1)
            {
                if (mi.Name.Contains("_1"))
                {
                    if (mi.Name.Contains("name"))
                    {
                        NameTxt1.Content = TextFields.MutantHumanName.Mutants.GetRandomName();
                    }
                    else if (mi.Name.Contains("trait"))
                    {
                        TraitTxt.Content = TextFields.Occupation.GetAllOptions(TextFields.Occupation.SpecialTrait).GetRandomName();
                    }
                    else if (mi.Name.Contains("goal"))
                    {
                        GoalTxt.Content = TextFields.Occupation.GetAllOptions(TextFields.Occupation.SpecialGoal).GetRandomName();
                    }
                    else if (mi.Name.Contains("mutation"))
                    {
                        Mutation1Txt1.Content = TextFields.Mutation.Mutations.GetRandomName();
                    }
                    else if (mi.Name.Contains("skill"))
                    {
                        Skill1Txt1.Content = TextFields.Occupation.SpecialSkills.GetRandomName();
                    }
                    else if (mi.Name.Contains("talent"))
                    {
                        TalentsTxt1.Content = TextFields.Occupation.GetAllOptions(TextFields.Occupation.SpecialTalents).GetRandomName();
                    }
                }
                else if (mi.Name.Contains("_2"))
                {
                    if (mi.Name.Contains("mutation"))
                    {
                        Mutation2Txt1.Content = TextFields.Mutation.Mutations.GetRandomName();
                    }
                    else if (mi.Name.Contains("skill"))
                    {
                        Skill2Txt1.Content = TextFields.Skill.Skills.GetRandomName();
                    }
                }
                else if (mi.Name.Contains("_3"))
                {
                    if (mi.Name.Contains("mutation"))
                    {
                        Mutation3Txt1.Content = TextFields.Mutation.Mutations.GetRandomName();
                    }
                    else if (mi.Name.Contains("skill"))
                    {
                        Skill3Txt1.Content = TextFields.Skill.Skills.GetRandomName();
                    }
                }
                else if (mi.Name.Contains("_4"))
                {
                    if (mi.Name.Contains("skill"))
                    {
                        Skill4Txt1.Content = TextFields.Skill.Skills.GetRandomName();
                    }
                }
                else if (mi.Name.Contains("_5"))
                {
                    if (mi.Name.Contains("skill"))
                    {
                        Skill5Txt1.Content = TextFields.Skill.Skills.GetRandomName();
                    }
                }
                else if (mi.Name.Contains("_6"))
                {
                    if (mi.Name.Contains("skill"))
                    {
                        Skill6Txt1.Content = TextFields.Skill.Skills.GetRandomName();
                    }
                }
            }


        }


        private void ContMenu(object sender)
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
                        (string)mi.Header == "TÖM!" ?
                        mi.Uid.ToString() :
                        mi.Header.ToString();
        }

        public void NameContextMenu1(object sender, RoutedEventArgs e)
        {
            ContMenu(sender);

            MenuItem mi = sender as MenuItem;

            // Kolumn 1
            if ((int)mi.Tag == 1)
            {
                if (mi.Name.Contains("_1"))
                {
                    if (mi.Name.Contains("name"))
                    {
                        SetTextField(mi, NameTxt1);
                    }
                    else if (mi.Name.Contains("trait"))
                    {
                        SetTextField(mi, TraitTxt);
                    }
                    else if (mi.Name.Contains("goal"))
                    {
                        SetTextField(mi, GoalTxt);
                    }
                    else if (mi.Name.Contains("mutation"))
                    {
                        SetTextField(mi, Mutation1Txt1);
                    }
                    else if (mi.Name.Contains("skill"))
                    {
                        SetTextField(mi, Skill1Txt1);
                    }
                    else if (mi.Name.Contains("talent"))
                    {
                        SetTextField(mi, TalentsTxt1);
                    }
                }
                else if (mi.Name.Contains("_2"))
                {
                    if (mi.Name.Contains("mutation"))
                    {
                        SetTextField(mi, Mutation2Txt1);
                    }
                    else if (mi.Name.Contains("skill"))
                    {
                        SetTextField(mi, Skill2Txt1);
                    }
                }
                else if (mi.Name.Contains("_3"))
                {
                    if (mi.Name.Contains("mutation"))
                    {
                        SetTextField(mi, Mutation3Txt1);
                    }
                    else if (mi.Name.Contains("skill"))
                    {
                        SetTextField(mi, Skill3Txt1);
                    }
                }
                else if (mi.Name.Contains("_4"))
                {
                    if (mi.Name.Contains("skill"))
                    {
                        SetTextField(mi, Skill4Txt1);
                    }
                }
                else if (mi.Name.Contains("_5"))
                {
                    if (mi.Name.Contains("skill"))
                    {
                        SetTextField(mi, Skill5Txt1);
                    }
                }
                else if (mi.Name.Contains("_6"))
                {
                    if (mi.Name.Contains("skill"))
                    {
                        SetTextField(mi, Skill6Txt1);
                    }
                }
            }

        }

        //public void PopulateContextMenu(ContextMenu cm, List<string> list)
        //{
        //    // Används för att namnge items med deras namn utan ändelser
        //    string plainName = cm.Name.Contains("_") ?
        //        (cm.Name.Substring(0, (cm.Name.Count() - 5))).ToLower() :
        //        (cm.Name.Substring(0, (cm.Name.Count() - 3))).ToLower();

        //    // Lagrar ändelsen på context-menyns namn
        //    string endInteger = cm.Name.Contains("_") ?
        //        "_" + (cm.Name.Substring((cm.Name.Count() - 3), 1)).ToLower() :
        //        "";

        //    // Skapar första menyvalet "SLUMPA!"
        //    MenuItem firstItem = new MenuItem();
        //    firstItem.Click += new RoutedEventHandler(RandomizeName_Click);
        //    firstItem.FontSize = 20;
        //    //firstItem.FontWeight = FontWeights.Bold;
        //    firstItem.Header = "SLUMPA!";
        //    firstItem.Name = plainName;

        //    // Skapar en separator
        //    Separator sep1 = new Separator();
        //    sep1.BorderThickness = new Thickness(1);
        //    sep1.BorderBrush = Brushes.Black;

        //    //Skapar en andra separator
        //    Separator sep2 = new Separator();
        //    sep2.BorderThickness = new Thickness(1);
        //    sep2.BorderBrush = Brushes.Black;

        //    // SKapar andra menyvalet som nollar textfältet
        //    MenuItem secondItem = new MenuItem();
        //    secondItem.Click += new RoutedEventHandler(NameContextMenu1);
        //    secondItem.FontSize = 20;
        //    //secondItem.FontWeight = FontWeights.Bold;
        //    secondItem.Header = "TÖM!";
        //    secondItem.Name = plainName;
        //    secondItem.Uid = "";

        //    // Skapar id beroende på vilken kolumn som berörs
        //    if (cm.Name.Contains("_1"))
        //    {
        //        firstItem.Tag = 1;
        //        secondItem.Tag = 1;
        //    }
        //    else if (cm.Name.Contains("_2"))
        //    {
        //        firstItem.Tag = 2;
        //        secondItem.Tag = 2;
        //    }
        //    else if (cm.Name.Contains("_3"))
        //    {
        //        firstItem.Tag = 3;
        //        secondItem.Tag = 3;
        //    }

        //    firstItem.Name = plainName + endInteger;
        //    secondItem.Name = plainName + endInteger;

        //    // Lägger till de första items i menyn
        //    cm.Items.Add(firstItem);
        //    cm.Items.Add(sep1);
        //    cm.Items.Add(secondItem);
        //    cm.Items.Add(sep2);



        //    // Lägger till varje sträng i listan som listobjekt
        //    for (int i = 0; i < list.Count; i++)
        //    {

        //        MenuItem mi = new MenuItem();
        //        mi.Click += new RoutedEventHandler(NameContextMenu1);
        //        mi.Header = list[i];

        //        // Bestämmer vilken kolumn som påverkas
        //        if (cm.Name.Contains("_1"))
        //            mi.Tag = 1;
        //        else if (cm.Name.Contains("_2"))
        //            mi.Tag = 2;
        //        else if (cm.Name.Contains("_3"))
        //            mi.Tag = 3;

        //        mi.Name = plainName + i.ToString() + endInteger;

        //        cm.Items.Add(mi);
        //    }
        //}


        public void PopulateContextMenu(ContextMenu cm, List<string> list)
        {
            // Används för att namnge items med deras namn utan ändelser
            string plainName = cm.Name.Contains("_") ?
                (cm.Name.Substring(0, (cm.Name.Count() - 5))).ToLower() :
                (cm.Name.Substring(0, (cm.Name.Count() - 3))).ToLower();

            // Lagrar ändelsen på context-menyns namn
            string endInteger = cm.Name.Contains("_") ?
                "_" + (cm.Name.Substring((cm.Name.Count() - 3), 1)).ToLower() :
                "";

            // Skapar första menyvalet "SLUMPA!"
            MenuItem firstItem = new MenuItem();
            firstItem.Click += new RoutedEventHandler(RandomizeName_Click);
            firstItem.FontSize = 20;
            //firstItem.FontWeight = FontWeights.Bold;
            firstItem.Header = "SLUMPA!";
            firstItem.Name = plainName;

            // Skapar en separator
            Separator sep1 = new Separator();
            sep1.BorderThickness = new Thickness(1);
            sep1.BorderBrush = Brushes.Black;

            //Skapar en andra separator
            Separator sep2 = new Separator();
            sep2.BorderThickness = new Thickness(1);
            sep2.BorderBrush = Brushes.Black;

            // SKapar andra menyvalet som nollar textfältet
            MenuItem secondItem = new MenuItem();
            secondItem.Click += new RoutedEventHandler(NameContextMenu1);
            secondItem.FontSize = 20;
            //secondItem.FontWeight = FontWeights.Bold;
            secondItem.Header = "TÖM!";
            secondItem.Name = plainName;
            secondItem.Uid = "";

            // Skapar id beroende på vilken kolumn som berörs
            if (cm.Name.Contains("_1"))
            {
                firstItem.Tag = 1;
                secondItem.Tag = 1;
            }
            else if (cm.Name.Contains("_2"))
            {
                firstItem.Tag = 2;
                secondItem.Tag = 2;
            }
            else if (cm.Name.Contains("_3"))
            {
                firstItem.Tag = 3;
                secondItem.Tag = 3;
            }

            firstItem.Name = plainName + endInteger;
            secondItem.Name = plainName + endInteger;

            // Lägger till de första items i menyn
            cm.Items.Add(firstItem);
            cm.Items.Add(sep1);
            cm.Items.Add(secondItem);
            cm.Items.Add(sep2);

            string nameMenu = "";
            List<MenuItem> head = new List<MenuItem>();

            // Lägger till varje sträng i listan som listobjekt
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == "KROSSARE" ||
                    list[i] == "SKROTSKALLE" ||
                    list[i] == "ZONSTRYKARE" ||
                    list[i] == "FIXARE" ||
                    list[i] == "MUTANT MED HUND" ||
                    list[i] == "KRÖNIKÖR" ||
                    list[i] == "BOSS" ||
                    list[i] == "SLAV")
                {
                    nameMenu = list[i];
                    head.Clear();
                }
                else
                {
                    
                    MenuItem mi = new MenuItem();
                    mi.Click += new RoutedEventHandler(NameContextMenu1);
                    mi.Header = list[i];
       
                    // Bestämmer vilken kolumn som påverkas
                    if (cm.Name.Contains("_1"))
                        mi.Tag = 1;
                    else if (cm.Name.Contains("_2"))
                        mi.Tag = 2;
                    else if (cm.Name.Contains("_3"))
                        mi.Tag = 3;

                    mi.Name = plainName + i.ToString() + endInteger;

                    head.Add(mi);

                    if (list[i] != list[list.Count - 1])
                    {
                        if (list[i + 1] == "KROSSARE" ||
                        list[i + 1] == "SKROTSKALLE" ||
                        list[i + 1] == "ZONSTRYKARE" ||
                        list[i + 1] == "FIXARE" ||
                        list[i + 1] == "MUTANT MED HUND" ||
                        list[i + 1] == "KRÖNIKÖR" ||
                        list[i + 1] == "BOSS" ||
                        list[i + 1] == "SLAV")
                        {
                            cm.Items.Add
                                (new MenuItem()
                                {Name = nameMenu == "MUTANT MED HUND" ? "MUTANTMEDHUND" : nameMenu,
                                    Header = nameMenu,
                                  ItemsSource = head});
                        }
                    }
                }
            }
        }

        public void EmptyContextMenu(ContextMenu cm)
        {
            ContextMenu newCm = new ContextMenu();
            cm = newCm;
        }
        //-----------------------------------------------HJÄLPMETODER--------------------------------------------------------------------------------------

        private void IntegerUpDown_LostFocus(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.IntegerUpDown obj = sender as Xceed.Wpf.Toolkit.IntegerUpDown;
            obj.ShowButtonSpinner = false;
        }

        private void IntegerUpDown_GotFocus(object sender, RoutedEventArgs e)
        {
            Xceed.Wpf.Toolkit.IntegerUpDown obj = sender as Xceed.Wpf.Toolkit.IntegerUpDown;
            obj.ShowButtonSpinner = true;
        }
        private void GetSpecialOccuBP(Label sty, Label kyl, Label skp, Label kns, Label mutation1, Label mutation2)
        {

            // Tömmer BP för att undvika fel om användaren vill slumpa om värdena
            TextFields.BasicProperty.BP.Clear();
            // Kallar på GetInitialValues för att lägga till minimumvärden i listan (argument 1 är antalet platser och argument 2 är värdet)
            TextFields.BasicProperty.BP.GetInitialValues(4, 2);
            // Delar ut värden slumpvis från summan som anges i argumentet (maximum på varje värde är 4)
            TextFields.BasicProperty.BP.GetRandomValues((4 + rnd.Next(0, 2)), 4);

            // Om syssla slumpats fram så plussas den speciella egenskapen för sysslan på med 1
            if (TextFields.Occupation.CurrentOccu[0] != "")
            {
                // CurrentOccu[1] lagrar förkortningen på den speciella GE för sysslan.
                if (TextFields.Occupation.CurrentOccu[1].ToLower().Contains("sty"))
                {
                    TextFields.BasicProperty.BP[0] += 1;
                    sty.Content = TextFields.BasicProperty.BP[0].ToString();
                    kyl.Content = TextFields.BasicProperty.BP[1].ToString();
                    skp.Content = TextFields.BasicProperty.BP[2].ToString();
                    kns.Content = TextFields.BasicProperty.BP[3].ToString();
                }
                else if (TextFields.Occupation.CurrentOccu[1].ToLower().Contains("kyl"))
                {
                    TextFields.BasicProperty.BP[1] += 1;
                    sty.Content = TextFields.BasicProperty.BP[0].ToString();
                    kyl.Content = TextFields.BasicProperty.BP[1].ToString();
                    skp.Content = TextFields.BasicProperty.BP[2].ToString();
                    kns.Content = TextFields.BasicProperty.BP[3].ToString();
                }
                else if (TextFields.Occupation.CurrentOccu[1].ToLower().Contains("skp"))
                {
                    TextFields.BasicProperty.BP[2] += 1;
                    sty.Content = TextFields.BasicProperty.BP[0].ToString();
                    kyl.Content = TextFields.BasicProperty.BP[1].ToString();
                    skp.Content = TextFields.BasicProperty.BP[2].ToString();
                    kns.Content = TextFields.BasicProperty.BP[3].ToString();
                }
                else if (TextFields.Occupation.CurrentOccu[1].ToLower().Contains("kns"))
                {
                    TextFields.BasicProperty.BP[3] += 1;
                    sty.Content = TextFields.BasicProperty.BP[0].ToString();
                    kyl.Content = TextFields.BasicProperty.BP[1].ToString();
                    skp.Content = TextFields.BasicProperty.BP[2].ToString();
                    kns.Content = TextFields.BasicProperty.BP[3].ToString();
                }

            }
            else
            {
                // Lägger till värdena i formuläret
                sty.Content = TextFields.BasicProperty.BP[0].ToString();
                kyl.Content = TextFields.BasicProperty.BP[1].ToString();
                skp.Content = TextFields.BasicProperty.BP[2].ToString();
                kns.Content = TextFields.BasicProperty.BP[3].ToString();
            }

            if (TextFields.BasicProperty.BP.Take(4).Sum() == 13 && mutation1.Content != null)
            {
                string temp = mutation1.Content.ToString();
                GetMutation(mutation1, mutation2);
                mutation1.Content = temp;
            }
            else if (TextFields.BasicProperty.BP.Take(4).Sum() == 14 && mutation1.Content != null)
            {
                string temp = mutation1.Content.ToString();
                GetMutation(mutation1, mutation2);
                mutation1.Content = temp;
            }
        }

        private void GetMutation(Label mutation1, Label mutation2)
        {
            // Nollar Labelen
            mutation1.Content = "";
            mutation2.Content = "";

            // Om BP slumpats fram med summan 13 så läggs två Mutationer till. Enligt reglerna för Mutant År Noll
            if (TextFields.BasicProperty.BP.Take(4).Sum() == 13)
            {
                mutation1.Content = TextFields.Mutation.Mutations.GetRandomName();

                string secondMut = TextFields.Mutation.Mutations.GetRandomName();

                while ((string)mutation1.Content == secondMut)
                {
                    secondMut = TextFields.Mutation.Mutations.GetRandomName();
                }

                mutation2.Content = secondMut;
            }
            // Om BP slumpats fram med summan 14 så läggs endast en Mutation till
            else
            {
                mutation1.Content = TextFields.Mutation.Mutations.GetRandomName();
            }
        }

        private void GetSkills(Label specSkill, Xceed.Wpf.Toolkit.IntegerUpDown specSkillPoint, Label skill2, Xceed.Wpf.Toolkit.IntegerUpDown skillPoint2, Label skill3, Xceed.Wpf.Toolkit.IntegerUpDown skillPoint3)
        {
            // värden rensas innan de får nya värden
            specSkill.ClearValue(Label.ContentProperty);
            specSkillPoint.ClearValue(Label.ContentProperty);
            skill2.ClearValue(Label.ContentProperty);
            skillPoint2.ClearValue(Label.ContentProperty);
            skill3.ClearValue(Label.ContentProperty);
            skillPoint3.ClearValue(Label.ContentProperty);
            

            TextFields.Skill.SkillPoints.Clear();
            // initierar SkillPoints med 4 platser med 0 poäng vardera.
            TextFields.Skill.SkillPoints.GetInitialValues(3, 1);
            // delar ut värden från summan 5 med maxvärde på 3
            TextFields.Skill.SkillPoints.GetRandomValues(2, 3);

            // SkillPoint[0] får inte vara större än 2 innan specvärdet plussas på
            while (TextFields.Skill.SkillPoints[0] == 3)
            {
                int temp;
                if (TextFields.Skill.SkillPoints[1] < 3)
                {
                    temp = TextFields.Skill.SkillPoints[0];
                    TextFields.Skill.SkillPoints[0] = TextFields.Skill.SkillPoints[1];
                    TextFields.Skill.SkillPoints[1] = temp;
                }
                else if (TextFields.Skill.SkillPoints[2] < 3)
                {
                    temp = TextFields.Skill.SkillPoints[0];
                    TextFields.Skill.SkillPoints[0] = TextFields.Skill.SkillPoints[2];
                    TextFields.Skill.SkillPoints[2] = temp;
                }

            }

            string skillOne, skillTwo;

            skillOne = TextFields.Skill.Skills.GetRandomName();
            skillTwo = TextFields.Skill.Skills.GetRandomName();

            while (skillOne.Contains(skillTwo))
            {
                skillOne = TextFields.Skill.Skills.GetRandomName();
            }

            specSkill.Content = TextFields.Occupation.GetRandomMultiOption(2);
            specSkillPoint.Value = (TextFields.Skill.SkillPoints[0] + 1);

            skill2.Content = skillOne;
            skillPoint2.Value = TextFields.Skill.SkillPoints[1];

            skill3.Content = skillTwo;
            skillPoint3.Value = TextFields.Skill.SkillPoints[2];

        }

        private void GetOccu(string occu)
        {
            TextFields.Occupation.CurrentOccu[0] = occu;
            //TextFields.Occupation.CurrentOccu[0] = TextFields.Occupation.Occupations.GetRandomName();
            TextFields.Occupation.SetCurrentOccu();
            TextFields.Occupation.GetEquipment();
        }

        private void SetAllFields(int column)
        {
            switch (column)
            {
                case 1:
                    OccuTxt.Content = TextFields.Occupation.CurrentOccu[0];
                    TalentsTxt1.Content = TextFields.Occupation.GetRandomMultiOption(3);
                    Equipment1Txt1.Content = TextFields.Occupation.GetRandomMultiOption(4);
                    TraitTxt.Content = TextFields.Occupation.GetRandomMultiOption(6);
                    GoalTxt.Content = TextFields.Occupation.GetRandomMultiOption(7);
                    GetSpecialOccuBP(StyTxt1, KylTxt1, SkpTxt1, KnsTxt1, Mutation1Txt1, Mutation2Txt1);
                    GetMutation(Mutation1Txt1, Mutation2Txt1);
                    GetSkills(Skill1Txt1, SkillPoint1Spinner1, Skill2Txt1, SkillPoint2Spinner1, Skill3Txt1, SkillPoint3Spinner1);
                    Equipment2Txt1.Content = string.Format("{0} {1} {2}",
                        TextFields.Occupation.CurrentEquip[0],
                        TextFields.Occupation.CurrentEquip[1],
                        TextFields.Occupation.CurrentEquip[2]);
                    if (TextFields.Occupation.CurrentOccu[0] == "SKROTSKALLE")
                    {
                        Equipment3Txt1.Content = "ARTIFAKT";
                    }
                    break;
                case 2:
                    OccuTxt2.Content = TextFields.Occupation.CurrentOccu[0];
                    TalentsTxt2.Content = TextFields.Occupation.GetRandomMultiOption(3);
                    Equipment1Txt2.Content = TextFields.Occupation.GetRandomMultiOption(4);
                    TraitTxt2.Content = TextFields.Occupation.GetRandomMultiOption(6);
                    GoalTxt2.Content = TextFields.Occupation.GetRandomMultiOption(7);
                    GetSpecialOccuBP(StyTxt2, KylTxt2, SkpTxt2, KnsTxt2, Mutation1Txt2, Mutation2Txt2);
                    GetMutation(Mutation1Txt2, Mutation2Txt2);
                    GetSkills(Skill1Txt1, SkillPoint1Spinner1, Skill2Txt1, SkillPoint2Spinner1, Skill3Txt1, SkillPoint3Spinner1);
                    Equipment2Txt2.Content = string.Format("{0} {1} {2}",
                        TextFields.Occupation.CurrentEquip[0],
                        TextFields.Occupation.CurrentEquip[1],
                        TextFields.Occupation.CurrentEquip[2]);
                    if (TextFields.Occupation.CurrentOccu[0] == "SKROTSKALLE")
                    {
                        Equipment3Txt2.Content = "ARTIFAKT";
                    }
                    break;
                case 3:
                    //OccuTxt3.Content = TextFields.Occupation.CurrentOccu[0];
                    //TalentsTxt3.Content = TextFields.Occupation.GetRandomMultiOption(3);
                    //Equipment1Txt3.Content = TextFields.Occupation.GetRandomMultiOption(4);
                    //TraitTxt3.Content = TextFields.Occupation.GetRandomMultiOption(6);
                    //GoalTxt3.Content = TextFields.Occupation.GetRandomMultiOption(7);
                    //GetSpecialOccuBP(StyTxt3, KylTxt3, SkpTxt3, KnsTxt3);
                    //GetMutation(Mutation1Txt3, Mutation2Txt3);
                    //GetSkills(Skill1Txt3, SkillPoint1Txt3, Skill2Txt3, SkillPoint2Txt3, Skill3Txt3, SkillPoint3Txt3);
                    //Equipment2Txt3.Content = string.Format("{0} {1} {2}",
                    //    TextFields.Occupation.CurrentEquip[0],
                    //    TextFields.Occupation.CurrentEquip[1],
                    //    TextFields.Occupation.CurrentEquip[2]);
                    //if (TextFields.Occupation.CurrentOccu[0] == "SKROTSKALLE")
                    //{
                    //    Equipment3Txt3.Content = "ARTIFAKT";
                    //}
                    break;
                default:
                    break;
            }

        }

        //---------------------------------------------------KNAPPAR---------------------------------------------------

        private void button_save_window_Click(object sender, RoutedEventArgs e)
        {

            Util.SaveWindow(this, 200, "e:\\window.png", SaveBtn, SlumpSlp1, SlumpSlp2, SlumpSlp3);
        }

        private void SlumpSlp1_Click(object sender, RoutedEventArgs e)
        {
            GetOccu(TextFields.Occupation.Occupations.GetRandomName());
            NameTxt1.Content = TextFields.MutantHumanName.Mutants.GetRandomName();
            SetAllFields(1);
        }

        private void SlumpSlp2_Click(object sender, RoutedEventArgs e)
        {
            GetOccu(TextFields.Occupation.Occupations.GetRandomName());
            NameTxt2.Content = TextFields.MutantHumanName.Mutants.GetRandomName();
            SetAllFields(2);
        }

        private void SlumpSlp3_Click(object sender, RoutedEventArgs e)
        {

        }

        //---------------------------------------------KNAPPAR OCH LABEL FÖR KOLUMN 1-----------------------------------------------------------------

        private void NameBtn1_Click(object sender, RoutedEventArgs e)
        {
            ContMenu(sender);
            //NameTxt1.Content = TextFields.MutantHumanName.Mutants.GetRandomName();
        }

        private void OccuBtn1_Click(object sender, RoutedEventArgs e)
        {
            ContMenu(sender);
        }

        private void Krossare_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("KROSSARE");
            SetAllFields(1);
        }

        private void Skrotskalle_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("SKROTSKALLE");
            SetAllFields(1);
        }

        private void Zonstrykare_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("ZONSTRYKARE");
            SetAllFields(1);
        }

        private void Fixare_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("FIXARE");
            SetAllFields(1);
        }

        private void MutantMedHund_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("MUTANT MED HUND");
            SetAllFields(1);
        }

        private void Kronikor_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("KRÖNIKÖR");
            SetAllFields(1);
        }

        private void Boss_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("BOSS");
            SetAllFields(1);
        }

        private void Slav_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("SLAV");
            SetAllFields(1);
        }

        private void TraitBtn1_Click(object sender, RoutedEventArgs e)
        {
            ContMenu(sender);
            //TraitTxt.Content = TextFields.Occupation.GetRandomMultiOption(6);
        }

        private void GoalBtn1_Click(object sender, RoutedEventArgs e)
        {
            ContMenu(sender);
            //GoalTxt.Content = TextFields.Occupation.GetRandomMultiOption(7);
        }

        private void BpBtn1_Click(object sender, RoutedEventArgs e)
        {
            GetSpecialOccuBP(StyTxt1, KylTxt1, SkpTxt1, KnsTxt1, Mutation1Txt1, Mutation2Txt1);
        }

        private void SkillsBtn1_Click(object sender, RoutedEventArgs e)
        {
            GetSkills(Skill1Txt1, SkillPoint1Spinner1, Skill2Txt1, SkillPoint2Spinner1, Skill3Txt1, SkillPoint3Spinner1);
        }

        private void MutationsBtn1_Click(object sender, RoutedEventArgs e)
        {
            ContMenu(sender);
            //GetMutation(Mutation1Txt1, Mutation2Txt1);
        }

        private void Skill1Btn1_Click(object sender, RoutedEventArgs e)
        {
            ContMenu(sender);
        }

        private void TalentsBtn1_Click(object sender, RoutedEventArgs e)
        {
            ContMenu(sender);
        }

        private void EquipmentBtn1_Click(object sender, RoutedEventArgs e)
        {
            TextFields.Occupation.GetEquipment();
            Equipment1Txt1.Content = TextFields.Occupation.GetRandomMultiOption(4);
            Equipment2Txt1.Content = string.Format("{0} {1} {2}",
                     TextFields.Occupation.CurrentEquip[0],
                     TextFields.Occupation.CurrentEquip[1],
            TextFields.Occupation.CurrentEquip[2]);
            if (TextFields.Occupation.CurrentOccu[0] == "SKROTSKALLE")
            {
                Equipment3Txt1.Content = "ARTIFAKT";
            }
        }

        //-------------------------------------------------KNAPPAR OCH LabelAR FÖR KOLUMN 2-----------------------------------------------------------------

        private void NameBtn2_Click(object sender, RoutedEventArgs e)
        {
            NameTxt2.Content = TextFields.MutantHumanName.Mutants.GetRandomName();
        }

        private void OccuBtn2_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            btn.ContextMenu.IsEnabled = true;
            btn.ContextMenu.PlacementTarget = btn;
            btn.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            btn.ContextMenu.IsOpen = true;
        }

        private void Krossare2_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("KROSSARE");
            SetAllFields(2);
        }

        private void Skrotskalle2_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("SKROTSKALLE");
            SetAllFields(2);
        }

        private void Zonstrykare2_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("ZONSTRYKARE");
            SetAllFields(2);
        }

        private void Fixare2_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("FIXARE");
            SetAllFields(2);
        }

        private void MutantMedHund2_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("MUTANT MED HUND");
            SetAllFields(2);
        }

        private void Kronikor2_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("KRÖNIKÖR");
            SetAllFields(2);
        }

        private void Boss2_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("BOSS");
            SetAllFields(2);
        }

        private void Slav2_Click(object sender, RoutedEventArgs e)
        {
            GetOccu("SLAV");
            SetAllFields(2);
        }

        private void TraitBtn2_Click(object sender, RoutedEventArgs e)
        {
            TraitTxt2.Content = TextFields.Occupation.GetRandomMultiOption(6);
        }

        private void GoalBtn2_Click(object sender, RoutedEventArgs e)
        {
            GoalTxt2.Content = TextFields.Occupation.GetRandomMultiOption(7);
        }

        private void BpBtn2_Click(object sender, RoutedEventArgs e)
        {
            GetSpecialOccuBP(StyTxt2, KylTxt2, SkpTxt2, KnsTxt2, Mutation1Txt2, Mutation2Txt2);
        }

        private void SkillsBtn2_Click(object sender, RoutedEventArgs e)
        {
            GetSkills(Skill1Txt1, SkillPoint1Spinner1, Skill2Txt1, SkillPoint2Spinner1, Skill3Txt1, SkillPoint3Spinner1);
        }

        private void MutationsBtn2_Click(object sender, RoutedEventArgs e)
        {
            GetMutation(Mutation1Txt2, Mutation2Txt2);
        }

        private void EquipmentBtn2_Click(object sender, RoutedEventArgs e)
        {
            TextFields.Occupation.GetEquipment();
            Equipment1Txt2.Content = TextFields.Occupation.GetRandomMultiOption(4);
            Equipment2Txt2.Content = string.Format("{0} {1} {2}",
                     TextFields.Occupation.CurrentEquip[0],
                     TextFields.Occupation.CurrentEquip[1],
            TextFields.Occupation.CurrentEquip[2]);
            if (TextFields.Occupation.CurrentOccu[0] == "SKROTSKALLE")
            {
                Equipment3Txt2.Content = "ARTIFAKT";
            }
        }


    }
}
