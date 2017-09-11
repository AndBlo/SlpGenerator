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
using SlpGenerator.TextFields;
using SlpGenerator.TextFields.Menus.MenuList;
using SlpGenerator.TextFields.Menus.DropItem;
using System.Threading;
using SlpGenerator.TextFields.Lists;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using Microsoft.Win32;
using System.Collections.Specialized;
using Newtonsoft.Json;
using SlpGenerator.Occupations;

namespace SlpGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    // Lagt till två till filer som är "partial" klasser av MainWindow för att få lite ordning: 
    // * RandomCharacter.cs som innehåller metoder för att slumpa fram hela karaktärer - används genom toolbaren och slump-knappen
    // * LoadCM.cs som innehåller metoderna för att ladda in alla menyer och items i samtliga ContextMeyer ("DropMenu").

    public partial class SlpWindow : Window
    {

        Random rnd = new Random();

        public SlpWindow()
        {

            InitializeComponent();
            LoadOccupations();
            Populate();
            PopulateContextMenus();

            cbOccupation.ItemsSource = Occupation.Occupations.Select(p => p.Name);

        }

        private static void LoadOccupations()
        {
            var list = Directory.GetFiles(@"MOF\", "*.mof");
            if (list.Length > 0)
            {
                Occupation occupation;


                for (int i = 0; i < list.Length; i++)
                {
                    occupation = new Occupation();

                    string input;

                    using (var reader = new StreamReader(list[i], true))
                    {
                        input = reader.ReadLine();
                    }

                    Occupation.Occupations.Add(JsonConvert.DeserializeObject<Occupation>(input));
                }
            }
        }

        private void Populate()
        {
            TextFields.MutantHumanName.Mutants.Load("MUTANTER.txt");
            //TextFields.Occupation.Occupations.Load("SYSSLA.txt");
            //TextFields.Occupation.SpecialBp.Load("SPEC_BP.txt");
            //TextFields.Occupation.SpecialSkills.Load("SPEC_FARDIGHETER.txt");
            //TextFields.Occupation.SpecialTalents.Load("SPEC_TALANGER.txt");
            //TextFields.Occupation.SpecialEquipment.Load("SPEC_UTRUSTNING.txt");
            //TextFields.Occupation.SpecialWeapon.Load("SPEC_VAPEN.txt");
            TextFields.Mutation.Mutations.Load("MUTATIONER.txt");
            //TextFields.Occupation.SpecialTrait.Load("SPEC_UTSEENDE.txt");
            //TextFields.Occupation.SpecialGoal.Load("SPEC_DROM.txt");
            TextFields.Skill.Skills.Load("SKILLS.txt");
            TextFields.Artifact.Artifacts.Load("ARTEFAKTER.txt");
            TextFields.Garbage.Garbages.Load("SKROT.txt");

        }

        private void PopulateContextMenus()
        {
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

        //---------------------------------------------------KNAPPAR---------------------------------------------------


        // Metod för samtliga contextmenyer
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            btn.ContextMenu.IsEnabled = true;
            btn.ContextMenu.PlacementTarget = btn;
            btn.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            btn.ContextMenu.IsOpen = true;
        }

        private void PrinBtn(object sender, RoutedEventArgs e)
        {
            // Metod för att spara fönstret som .png. Metoden döljer knapparna
            Util.PrintDialog(this, tbTray, slumpTray);
        }

        private void ExitBtn(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveSLP1Btn(object sender, RoutedEventArgs e)
        {
            AppFile af1 = new AppFile();
            af1.Save(Grid1);
        }

        private void SaveSLP2Btn(object sender, RoutedEventArgs e)
        {
            AppFile af2 = new AppFile();
            af2.Save(Grid2);
        }

        private void SaveSLP3Btn(object sender, RoutedEventArgs e)
        {
            AppFile af3 = new AppFile();
            af3.Save(Grid3);
        }

        private void LoadSLP1Btn(object sender, RoutedEventArgs e)
        {
            AppFile af1 = new AppFile();
            af1.Open(Grid1);
        }

        private void LoadSLP2Btn(object sender, RoutedEventArgs e)
        {
            AppFile af2 = new AppFile();
            af2.Open(Grid2);
        }

        private void LoadSLP3Btn(object sender, RoutedEventArgs e)
        {
            AppFile af3 = new AppFile();
            af3.Open(Grid3);
        }

        private void OpenOccupationWindow(object sender, RoutedEventArgs e)
        {
            OccupationPopup popup = new OccupationPopup();
            popup.ShowDialog();

            var list = Directory.GetFiles(@"MOF\", "*.mof");
            if (list.Count() != Occupation.Occupations.Count)
            {
                Occupation.Occupations.Clear();
                LoadOccupations();
                PopulateContextMenus();
                cbOccupation.ItemsSource = Occupation.Occupations.Select(p => p.Name);
            }
        }

        private void button_save_window_Click(object sender, RoutedEventArgs e)
        {
            // Metod för att spara fönstret som .png. Metoden döljer knapparna
            Util.SaveWindow(this, 200, tbTray);
        }

        private void Slumpa_Click(object sender, RoutedEventArgs e)
        {
            if (cbTargetSLP.Text.Contains("1"))
            {
                GetRandomCharacter(Grid1);
            }
            if (cbTargetSLP.Text.Contains("2"))
            {
                GetRandomCharacter(Grid2);
            }
            if (cbTargetSLP.Text.Contains("3"))
            {
                GetRandomCharacter(Grid3);
            }
            if (cbTargetSLP.Text.ToUpper().Contains("ALLA"))
            {
                GetRandomCharacter(Grid1);
                GetRandomCharacter(Grid2);
                GetRandomCharacter(Grid3);
            }

        }

        private void EmptySlp1_Click(object sender, RoutedEventArgs e)
        {
            EmptyLabels(Grid1);
        }

        private void EmptySlp2_Click(object sender, RoutedEventArgs e)
        {
            EmptyLabels(Grid2);
        }

        private void EmptySlp3_Click(object sender, RoutedEventArgs e)
        {
            EmptyLabels(Grid3);
        }

        private void EmptyAll_Click(object sender, RoutedEventArgs e)
        {
            EmptyLabels(Grid1);
            EmptyLabels(Grid2);
            EmptyLabels(Grid3);
        }

        private void CommonCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void EmptyLabels(Grid grid)
        {
            List<Label> lila = SlpWindow.GetLabelsFromGrid(grid);
            for (int i = 0; i < lila.Count; i++)
            {
                lila[i].Content = "";
            }
        }

        //---------------------------------------------------------SELECTIONCHANGED FÖR FÄRDIGHETER I TOOLBAR-----------------------------------------------------

        private void cbSkillCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (cbSkillPoints != null && cbMinimumSkillPoint != null && cbMaximumSkillPoint != null && cbMaximumSpecialSkillPoint != null && cbSkillCount != null)
            {
                int min = Convert.ToInt32(((ComboBoxItem)cbMinimumSkillPoint.SelectedItem).Content);
                int max = Convert.ToInt32(((ComboBoxItem)cbMaximumSkillPoint.SelectedItem).Content);
                int sMax = Convert.ToInt32(((ComboBoxItem)cbMaximumSpecialSkillPoint.SelectedItem).Content);
                int skillCount = Convert.ToInt32(((ComboBoxItem)cbSkillCount.SelectedItem).Content);
                int skillPoints = Convert.ToInt32(((ComboBoxItem)cbSkillPoints.SelectedItem).Content);

                // Räknar ut maxsumman
                int maxSum = (max * (skillCount - 1)) + (sMax * 1);
                // Räknar ut minsumman
                int minSum = (min * skillCount);

                // Uppdaterar antalet items som är enabled baserat på vilka items
                // som är valda i andra boxar.
                UpdateSkillComboBoxes(min, max, sMax, skillCount, skillPoints, maxSum, minSum);

                // Sätter SelectedItem till den närmsta enabled item
                UpdateSelectedItem(cbSkillPoints);
                UpdateSelectedItem(cbMinimumSkillPoint);
                UpdateSelectedItem(cbMaximumSkillPoint);
                UpdateSelectedItem(cbMaximumSpecialSkillPoint);

            }
        }

        private static void UpdateSelectedItem(ComboBox cb)
        {
            if (!((ComboBoxItem)cb.SelectedItem).IsEnabled)
            {

                List<ComboBoxItem> cbli = new List<ComboBoxItem>();
                List<ComboBoxItem> cbli2 = new List<ComboBoxItem>();
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    cbli.Add(cb.Items[i] as ComboBoxItem);
                }


                cbli2 = cbli.FindAll(p => p.IsEnabled && Convert.ToInt32(p.Content) < Convert.ToInt32((cb.SelectedItem as ComboBoxItem).Content));
                if (cbli2.Count != 0)
                {
                    cb.SelectedItem = cbli2[cbli2.Count - 1];
                }

                else if (cbli2.Count == 0)
                {
                    cbli2 = cbli.FindAll(p => p.IsEnabled && Convert.ToInt32(p.Content) > Convert.ToInt32((cb.SelectedItem as ComboBoxItem).Content));

                    if (cbli2.Count != 0)
                    {
                        cb.SelectedItem = cbli2[0];
                    }
                    else
                    {
                        cb.SelectedItem = cb.Items[0];
                    }
                }

            }
        }

        private void UpdateSkillComboBoxes(int min, int max, int sMax, int skillCount, int skillPoints, int maxSum, int minSum)
        {
            // Ser till så att poängskalan endast har giltiga val
            for (int i = 0; i < cbSkillPoints.Items.Count; i++)
            {
                int currentSkillPoints = Convert.ToInt32(((ComboBoxItem)cbSkillPoints.Items[i]).Content);
                bool condition = (currentSkillPoints < minSum || currentSkillPoints > maxSum);

                SetComboBoxItemsByCondition(cbSkillPoints, i, condition);
            }
            //min
            for (int i = 0; i < cbMinimumSkillPoint.Items.Count; i++)
            {
                int currentMin = Convert.ToInt32(((ComboBoxItem)cbMinimumSkillPoint.Items[i]).Content);
                bool condition = (currentMin > skillPoints || currentMin > max || currentMin > sMax || skillCount / skillPoints > currentMin);

                SetComboBoxItemsByCondition(cbMinimumSkillPoint, i, condition);
            }
            //max
            for (int i = 0; i < cbMaximumSkillPoint.Items.Count; i++)
            {
                int currentMax = Convert.ToInt32(((ComboBoxItem)cbMaximumSkillPoint.Items[i]).Content);
                bool condition = (currentMax > (double)(skillPoints / min) || currentMax > sMax);

                SetComboBoxItemsByCondition(cbMaximumSkillPoint, i, condition);
            }
            //max special
            for (int i = 0; i < cbMaximumSpecialSkillPoint.Items.Count; i++)
            {
                int currentSpecMax = Convert.ToInt32(((ComboBoxItem)cbMaximumSpecialSkillPoint.Items[i]).Content);
                bool condition = currentSpecMax > (double)(skillPoints / min) || currentSpecMax < max;

                SetComboBoxItemsByCondition(cbMaximumSpecialSkillPoint, i, condition);
            }
        }

        private void SetComboBoxItemsByCondition(ComboBox cb, int index, bool conditionIsTrue)
        {
            if (conditionIsTrue)
            {
                ((ComboBoxItem)cb.Items[index]).IsEnabled = false;
            }
            else if (!conditionIsTrue)
            {
                ((ComboBoxItem)cb.Items[index]).IsEnabled = true;
            }
        }

        public void UpdateComboBoxIsEnabled(ComboBox cb)
        {
            int counter = 0;
            // Poänglistan
            for (int i = 0; i < cb.Items.Count; i++)
            {
                if (((ComboBoxItem)cb.Items[i]).IsEnabled == false)
                {
                    counter++;
                }
            }
            if (counter == cb.Items.Count)
            {
                cb.IsEnabled = false;
            }
            else if (counter != cb.Items.Count)
            {
                cb.IsEnabled = true;
            }
            else if (counter == cb.Items.Count - 1)
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    if (((ComboBoxItem)cb.Items[i]).IsEnabled == true)
                    {
                        cb.SelectedItem = ((ComboBoxItem)cb.Items[i]);
                    }
                }
            }
        }

        private void CheckBoxEquipment1_Checked(object sender, RoutedEventArgs e)
        {
            cbEquipment1.IsEnabled = true;
        }

        private void CheckBoxEquipment1_Unchecked(object sender, RoutedEventArgs e)
        {
            cbEquipment1.IsEnabled = false;
        }

        private void CheckBoxEquipment2_Checked(object sender, RoutedEventArgs e)
        {
            cbEquipment2.IsEnabled = true;
        }

        private void CheckBoxEquipment2_Unchecked(object sender, RoutedEventArgs e)
        {
            cbEquipment2.IsEnabled = false;
        }

        private void CheckBoxEquipment3_Checked(object sender, RoutedEventArgs e)
        {
            cbEquipment3.IsEnabled = true;
        }

        private void CheckBoxEquipment3_Unchecked(object sender, RoutedEventArgs e)
        {
            cbEquipment3.IsEnabled = false;
        }

        private void CheckBoxEquipment4_Checked(object sender, RoutedEventArgs e)
        {
            cbEquipment4.IsEnabled = true;
        }

        private void CheckBoxEquipment4_Unchecked(object sender, RoutedEventArgs e)
        {
            cbEquipment4.IsEnabled = false;
        }

        private void cbOccupation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cbEquipment3 != null && CheckBoxEquipment3 != null)
            //{
            //    ComboBoxItem cbi = new ComboBoxItem();
            //    cbi = ((ComboBoxItem)cbOccupation.SelectedItem);
            //    if (((string)cbi.Content).ToUpper().Contains("skrot"))
            //    {
            //        cbEquipment3.IsEnabled = false;
            //        CheckBoxEquipment3.IsChecked = false;
            //    }
            //    else
            //    {
            //        cbEquipment3.IsEnabled = true;
            //        CheckBoxEquipment3.IsChecked = true;
            //    }
            //}
            
        }

        private void rbOccupationIsRandom_Checked(object sender, RoutedEventArgs e)
        {
            if(cbOccupation != null)
            cbOccupation.IsEnabled = false;
        }

        private void rbOccupationIsRandom_Unchecked(object sender, RoutedEventArgs e)
        {
            if(cbOccupation != null)
            {
                cbOccupation.IsEnabled = true;
                cbOccupation.SelectedItem = cbOccupation.Items[0];
            }
        }

        private void cbOccupation_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(cbOccupation != null)
            {
                cbOccupation.SelectedItem = null;
            }
        }

        private void rbEquipmentIsFixed_Checked(object sender, RoutedEventArgs e)
        {
                SetEquipmentControlsIsEnabled(false);
        }


        private void rbEquipmentIsFixed_Unchecked(object sender, RoutedEventArgs e)
        {
                SetEquipmentControlsIsEnabled(true);
        }

        private void SetEquipmentControlsIsEnabled(bool isEnabled)
        {
            if (cbEquipment1 != null && cbEquipment2 != null && cbEquipment3 != null && cbEquipment4 != null)
            {
                CheckBoxEquipment1.IsEnabled = isEnabled;
                CheckBoxEquipment2.IsEnabled = isEnabled;
                CheckBoxEquipment3.IsEnabled = isEnabled;
                CheckBoxEquipment4.IsEnabled = isEnabled;
            }
            
        }

        private void CheckBoxEquipment1_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetEquipmentComboBoxIsEnabled(sender as CheckBox, cbEquipment1);
        }

        private void CheckBoxEquipment2_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetEquipmentComboBoxIsEnabled(sender as CheckBox, cbEquipment2);
        }

        private void CheckBoxEquipment3_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetEquipmentComboBoxIsEnabled(sender as CheckBox, cbEquipment3);
        }

        private void CheckBoxEquipment4_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SetEquipmentComboBoxIsEnabled(sender as CheckBox, cbEquipment4);
        }

        private void SetEquipmentComboBoxIsEnabled(CheckBox chb, ComboBox cb)
        {
            if (chb.IsEnabled == true)
            {
                if (chb.IsChecked == true)
                {
                    cb.IsEnabled = true;
                }
                else
                {
                    cb.IsEnabled = false;
                }
            }
            else
            {
                cb.IsEnabled = false;
            }
        }
    }

    
}
