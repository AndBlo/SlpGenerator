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
            Util.PrintDialog(this, tbTray);
        }

        private void ExitBtn(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaverBtn(object sender, RoutedEventArgs e)
        {
        }

        private void SaveSLP1Btn(object sender, RoutedEventArgs e)
        {
            AppFile af1 = new AppFile();
            af1.SaveFile(Grid1);
        }

        private void SaveSLP2Btn(object sender, RoutedEventArgs e)
        {
            AppFile af2 = new AppFile();
            af2.SaveFile(Grid2);
        }

        private void SaveSLP3Btn(object sender, RoutedEventArgs e)
        {
            AppFile af3 = new AppFile();
            af3.SaveFile(Grid3);
        }

        private void LoadSLP1Btn(object sender, RoutedEventArgs e)
        {
            AppFile af1 = new AppFile();
            af1.OpenFile(Grid1);
        }

        private void LoadSLP2Btn(object sender, RoutedEventArgs e)
        {
            AppFile af2 = new AppFile();
            af2.OpenFile(Grid2);
        }

        private void LoadSLP3Btn(object sender, RoutedEventArgs e)
        {
            AppFile af3 = new AppFile();
            af3.OpenFile(Grid3);
        }

        private void button_save_window_Click(object sender, RoutedEventArgs e)
        {
            // Metod för att spara fönstret som .png. Metoden döljer knapparna
            Util.SaveWindow(this, 200, tbTray);
        }

        //private void SlumpSlp1_Click(object sender, RoutedEventArgs e)
        //{
        //    GetRandomCharacter(Grid1);
        //}

        //private void SlumpSlp2_Click(object sender, RoutedEventArgs e)
        //{
        //    GetRandomCharacter(Grid2);
        //}

        //private void SlumpSlp3_Click(object sender, RoutedEventArgs e)
        //{
        //    GetRandomCharacter(Grid3);
        //}

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

            // Antalet mutationer lagras i mut. Om "enligt regler" är angivet så lagras -1.
            int mutationCount = ((ComboBoxItem)_mut.SelectedItem).Content.ToString().ToLower() == "enligt regler" ?
                    -1 : Convert.ToInt32(((ComboBoxItem)_mut.SelectedItem).Content);


            if (((ComboBoxItem)_targetCB.SelectedItem).Content.ToString() == "Slp 1")
            {
                GetRandomCharacter(Grid1, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount);
            }
            else if (((ComboBoxItem)_targetCB.SelectedItem).Content.ToString() == "Slp 2")
            {
                GetRandomCharacter(Grid2, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount);
            }
            else if (((ComboBoxItem)_targetCB.SelectedItem).Content.ToString() == "Slp 2")
            {
                GetRandomCharacter(Grid3, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount);
            }
            else
            {
                GetRandomCharacter(Grid1, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount);
                GetRandomCharacter(Grid2, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount);
                GetRandomCharacter(Grid3, occu, basicPoints, specialBasicPoint, skillPoints, maxSkillPoint, minSkillPoint, maxSpecialSkillPoint, skillCount, mutationCount);
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
            List<Label> lila = MainWindow.LoadLabelsFromGrid(grid);
            for (int i = 0; i < lila.Count; i++)
            {
                lila[i].Content = "";
            }
        }

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

                //-----------------------------------------------------------------------------------------------------------------------------------------------
                // Kollar om items i comboboxen är enabled. Om ingen är det så sätts
                // comboboxens enabled på false.
                //UpdateComboBoxIsEnabled(_spCB);
                //UpdateComboBoxIsEnabled(_minSpCB);
                //UpdateComboBoxIsEnabled(_maxSpCB);
                //UpdateComboBoxIsEnabled(_maxSpecSpCB);

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


        //private void SetComboBoxItems(int maxSum, int minSum, int i, int currentSkillPoints)
        //{
        //    if (currentSkillPoints < minSum || currentSkillPoints > maxSum)
        //    {
        //        ((ComboBoxItem)_spCB.Items[i]).IsEnabled = false;
        //    }
        //    else if (currentSkillPoints > minSum || currentSkillPoints < maxSum)
        //    {
        //        ((ComboBoxItem)_spCB.Items[i]).IsEnabled = true;
        //    }
        //}

        //---------------------------------------------------------------------------------------------------------------------------


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

        //-----------------------------------------------------COMMANDS-------------------------------------------------------------------

    }

    public class AppFile
    {
        private OrderedDictionary od { get; set; } = new OrderedDictionary();

        public List<string> Keys { get; set; } = new List<string>();

        public List<string> Values { get; set; } = new List<string>();

        public string StreamString { get; set; }


        private void LoadLabels(Grid grid)
        {
            List<Label> labelList =
            SlpGenerator.MainWindow.LoadLabelsFromGrid(grid);

            for (int i = 0; i < labelList.Count; i++)
            {
                Keys.Add(labelList[i].Uid as string);
                Values.Add(labelList[i].Content as string);
            }

        }

        public void SaveFile(Grid grid)
        {
            LoadLabels(grid);

            for (int i = 0; i < Keys.Count; i++)
            {
                StreamString
                    += Keys[i]
                    + "_";
                StreamString
                    += Values[i]
                    + "|";
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SLP file (*.slp)|*.slp";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName, true))
                {
                    writer.WriteLine(StreamString);
                }
            }
        }
        public void OpenFile(Grid grid)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SLP file (*.slp)|*.slp";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                using (var reader = new StreamReader(openFileDialog.FileName, true))
                {
                    StreamString = reader.ReadLine();
                }
            }

            if (StreamString != null)
            {

                string[] arr;
                string[] arr2;
                arr = StreamString.Split('|');

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr2 = arr[i].Split('_');
                    Keys.Add(arr2[0]);
                    Values.Add(arr2[1]);
                }

                List<Label> labelList =
                    SlpGenerator.MainWindow.LoadLabelsFromGrid(grid);

                for (int i = 0; i < labelList.Count; i++)
                {
                    MainWindow.SetLabel(labelList, Keys[i], Values[i]);
                }
            }


        }

    }
}
