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

namespace SlpGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    // Lagt till två till filer som är "partial" klasser av MainWindow för att få lite ordning: 
    // * RandomCharacter.cs som innehåller metoder för att slumpa fram hela karaktärer - används genom toolbaren och slump-knappen
    // * LoadCM.cs som innehåller metoderna för att ladda in alla menyer och items i samtliga ContextMeyer ("DropMenu").

    public partial class MainWindow : Window
    {

        Random rnd = new Random();

        public MainWindow()
        {

            InitializeComponent();
            Populate();
        }

        private void Populate()
        {
            TextFields.MutantHumanName.Mutants.Load("MUTANTER.txt");
            TextFields.Occupation.Occupations.Load("SYSSLA.txt");
            TextFields.Occupation.SpecialBp.Load("SPEC_BP.txt");
            TextFields.Occupation.SpecialSkills.Load("SPEC_FARDIGHETER.txt");
            TextFields.Occupation.SpecialTalents.Load("SPEC_TALANGER.txt");
            TextFields.Occupation.SpecialEquipment.Load("SPEC_UTRUSTNING.txt");
            TextFields.Occupation.SpecialWeapon.Load("SPEC_VAPEN.txt");
            TextFields.Mutation.Mutations.Load("MUTATIONER.txt");
            TextFields.Occupation.SpecialTrait.Load("SPEC_UTSEENDE.txt");
            TextFields.Occupation.SpecialGoal.Load("SPEC_DROM.txt");
            TextFields.Skill.Skills.Load("SKILLS.txt");
            TextFields.Artifact.Artifacts.Load("ARTEFAKTER.txt");
            TextFields.Garbage.Garbages.Load("SKROT.txt");

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

        private void button_save_window_Click(object sender, RoutedEventArgs e)
        {
            // Metod för att spara fönstret som .png. Metoden döljer knapparna
            Util.SaveWindow(this, 200, tbTray);
        }

        private void Slumpa_Click(object sender, RoutedEventArgs e)
        {
            int occu = ((ComboBoxItem)_occu.SelectedItem).Content.ToString() == "Slumpvalt" ?
                -1 : Convert.ToInt32(_occu.SelectedIndex) - 1;

            // Antalet grundegenskapspoäng lagras i basicPoints
            int basicPoints = Convert.ToInt32(((ComboBoxItem)_bpCB.SelectedItem).Content);

            // Vilken GE som är special lagras i specialBasicPoint (-1 om det är enligt sysslans special)
            int specialBasicPoint = ((ComboBoxItem)_specialBpCB.SelectedItem).Content.ToString() == "Enligt syssla" ?
            -1 : Convert.ToInt32(_specialBpCB.SelectedIndex) - 1;

            // Antalet färdigheter lagras i skillCount
            int skillCount = Convert.ToInt32(((ComboBoxItem)_skill.SelectedItem).Content);

            // Antalet skill-poäng lagras i sp
            int skillPoints = (_spCB.SelectedItem as ComboBoxItem).IsEnabled ?
                Convert.ToInt32(((ComboBoxItem)_spCB.SelectedItem).Content) :
                -1;

            // Maxpoäng på en färdighet
            int maxSkillPoint = Convert.ToInt32((_maxSpCB.SelectedItem as ComboBoxItem).Content);

            // Minimumpoäng för en färdighet
            int minSkillPoint = Convert.ToInt32((_minSpCB.SelectedItem as ComboBoxItem).Content);

            // Maxpoäng för specialfärdigheten för sysslan
            int maxSpecialSkillPoint = Convert.ToInt32((_maxSpecSpCB.SelectedItem as ComboBoxItem).Content);

            //// Antalet mutationer lagras i mut
            int mutationCount = Convert.ToInt32(((ComboBoxItem)_mut.SelectedItem).Content);
            
            // Lista med de kategorier som är valda i toolbar
            List<string> selectedEquipment = GetSelectedEquipment();

            if (((ComboBoxItem)_targetCB.SelectedItem).Content.ToString() == "Slp 1")
            {
                GetRandomCharacter(Grid1, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount, selectedEquipment);
            }
            else if (((ComboBoxItem)_targetCB.SelectedItem).Content.ToString() == "Slp 2")
            {
                GetRandomCharacter(Grid2, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount, selectedEquipment);
            }
            else if (((ComboBoxItem)_targetCB.SelectedItem).Content.ToString() == "Slp 2")
            {
                GetRandomCharacter(Grid3, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount, selectedEquipment);
            }
            else
            {
                GetRandomCharacter(Grid1, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount, selectedEquipment);
                GetRandomCharacter(Grid2, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount, selectedEquipment);
                GetRandomCharacter(Grid3, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount, selectedEquipment);
            }
        }

        // Räknar och returnerar antalet aktiverade equipment i toolbar
        private int CountEquip()
        {
            int counter = 0;

            if (cbEquip1.IsChecked == true)
                counter++;
            if (cbEquip2.IsChecked == true)
                counter++;
            if (cbEquip3.IsChecked == true)
                counter++;
            if (cbEquip4.IsChecked == true)
                counter++;

            return counter;
        }

        private List<string> GetSelectedEquipment()
        {
            List<string> list = new List<string>();
            if (cbEquip1.IsChecked == true)
                list.Add(((ComboBoxItem)_equip1.SelectedItem).Content as string);
            if (cbEquip2.IsChecked == true)
                list.Add(((ComboBoxItem)_equip2.SelectedItem).Content as string);
            if (cbEquip3.IsChecked == true)
                list.Add(((ComboBoxItem)_equip3.SelectedItem).Content as string);
            if (cbEquip4.IsChecked == true)
                list.Add(((ComboBoxItem)_equip4.SelectedItem).Content as string);

            return list;
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
            List<Label> lila = MainWindow.GetLabelsFromGrid(grid);
            for (int i = 0; i < lila.Count; i++)
            {
                lila[i].Content = "";
            }
        }

        //---------------------------------------------------------SELECTIONCHANGED FÖR FÄRDIGHETER I TOOLBAR-----------------------------------------------------

        private void _skill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (_spCB != null && _minSpCB != null && _maxSpCB != null && _maxSpecSpCB != null && _skill != null)
            {
                int min = Convert.ToInt32(((ComboBoxItem)_minSpCB.SelectedItem).Content);
                int max = Convert.ToInt32(((ComboBoxItem)_maxSpCB.SelectedItem).Content);
                int sMax = Convert.ToInt32(((ComboBoxItem)_maxSpecSpCB.SelectedItem).Content);
                int skillCount = Convert.ToInt32(((ComboBoxItem)_skill.SelectedItem).Content);
                int skillPoints = Convert.ToInt32(((ComboBoxItem)_spCB.SelectedItem).Content);

                // Räknar ut maxsumman
                int maxSum = (max * (skillCount - 1)) + (sMax * 1);
                // Räknar ut minsumman
                int minSum = (min * skillCount);

                // Uppdaterar antalet items som är enabled baserat på vilka items
                // som är valda i andra boxar.
                UpdateSkillComboBoxes(min, max, sMax, skillCount, skillPoints, maxSum, minSum);

                // Sätter SelectedItem till den närmsta enabled item
                UpdateSelectedItem(_spCB);
                UpdateSelectedItem(_minSpCB);
                UpdateSelectedItem(_maxSpCB);
                UpdateSelectedItem(_maxSpecSpCB);

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
            for (int i = 0; i < _spCB.Items.Count; i++)
            {
                int currentSkillPoints = Convert.ToInt32(((ComboBoxItem)_spCB.Items[i]).Content);
                bool condition = (currentSkillPoints < minSum || currentSkillPoints > maxSum);

                SetComboBoxItemsByCondition(_spCB, i, condition);
            }
            //min
            for (int i = 0; i < _minSpCB.Items.Count; i++)
            {
                int currentMin = Convert.ToInt32(((ComboBoxItem)_minSpCB.Items[i]).Content);
                bool condition = (currentMin > skillPoints || currentMin > max || currentMin > sMax || skillCount / skillPoints > currentMin);

                SetComboBoxItemsByCondition(_minSpCB, i, condition);
            }
            //max
            for (int i = 0; i < _maxSpCB.Items.Count; i++)
            {
                int currentMax = Convert.ToInt32(((ComboBoxItem)_maxSpCB.Items[i]).Content);
                bool condition = (currentMax > (double)(skillPoints / min) || currentMax > sMax);

                SetComboBoxItemsByCondition(_maxSpCB, i, condition);
            }
            //max special
            for (int i = 0; i < _maxSpecSpCB.Items.Count; i++)
            {
                int currentSpecMax = Convert.ToInt32(((ComboBoxItem)_maxSpecSpCB.Items[i]).Content);
                bool condition = currentSpecMax > (double)(skillPoints / min) || currentSpecMax < max;

                SetComboBoxItemsByCondition(_maxSpecSpCB, i, condition);
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

        private void cbEquip1_Checked(object sender, RoutedEventArgs e)
        {
            _equip1.IsEnabled = true;
        }

        private void cbEquip1_Unchecked(object sender, RoutedEventArgs e)
        {
            _equip1.IsEnabled = false;
        }

        private void cbEquip2_Checked(object sender, RoutedEventArgs e)
        {
            _equip2.IsEnabled = true;
        }

        private void cbEquip2_Unchecked(object sender, RoutedEventArgs e)
        {
            _equip2.IsEnabled = false;
        }

        private void cbEquip3_Checked(object sender, RoutedEventArgs e)
        {
            _equip3.IsEnabled = true;
        }

        private void cbEquip3_Unchecked(object sender, RoutedEventArgs e)
        {
            _equip3.IsEnabled = false;
        }

        private void cbEquip4_Checked(object sender, RoutedEventArgs e)
        {
            _equip4.IsEnabled = true;
        }

        private void cbEquip4_Unchecked(object sender, RoutedEventArgs e)
        {
            _equip4.IsEnabled = false;
        }

        private void _occu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_equip3 != null && cbEquip3 != null)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi = ((ComboBoxItem)_occu.SelectedItem);
                if (((string)cbi.Content).ToUpper().Contains("skrot"))
                {
                    _equip3.IsEnabled = false;
                    cbEquip3.IsChecked = false;
                }
                else
                {
                    _equip3.IsEnabled = true;
                    cbEquip3.IsChecked = true;
                }
            }
            
        }

    }

    
}
