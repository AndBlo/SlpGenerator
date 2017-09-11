using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using SlpGenerator.Occupations;
using SlpGenerator.TextFields;

namespace SlpGenerator
{
    /// <summary>
    /// Interaction logic for OccupationPopup.xaml
    /// </summary>
    /// 

    public partial class OccupationPopup : Window
    {
        public OccupationPopup()
        {
            InitializeComponent();

            Form.CurrentForm = new OccupationForm();
            
            cbTraits.ItemsSource = Form.CurrentForm.Traits;
            cbGoals.ItemsSource = Form.CurrentForm.Goals;
            cbSpecialSkills.ItemsSource = Form.CurrentForm.Skills;
            cbTalents.ItemsSource = Form.CurrentForm.Talents;
            cbWeapons.ItemsSource = Form.CurrentForm.Weapons;

        }

        private void tbName_LostFocus(object sender, RoutedEventArgs e)
        {
            tbName.Text = tbName.Text.ToUpper();
            Form.CurrentForm.Name = tbName.Text.ToUpper();
        }

        private void btnAddTrait_Click(object sender, RoutedEventArgs e)
        {
            AddItemToComboBox(tbTraits, cbTraits, Form.CurrentForm.Traits);
        }


        private void btnRemoveTrait_Click(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.Traits.Remove(cbTraits.Text);
        }

        private void btnAddGoal_Click(object sender, RoutedEventArgs e)
        {
            AddItemToComboBox(tbGoals, cbGoals, Form.CurrentForm.Goals);
        }

        private void btnRemoveGoal_Click(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.Goals.Remove(cbGoals.Text);
        }

        private void btnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            AddItemToComboBox(tbSpecialSkills, cbSpecialSkills, Form.CurrentForm.Skills);
        }

        private void btnRemoveSkill_Click(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.Skills.Remove(cbSpecialSkills.Text);
        }

        private void btnAddTalent_Click(object sender, RoutedEventArgs e)
        {
            AddItemToComboBox(tbTalents, cbTalents, Form.CurrentForm.Talents);
        }

        private void btnRemoveTalent_Click(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.Talents.Remove(cbTalents.Text);
        }

        private void btnAddWeapon_Click(object sender, RoutedEventArgs e)
        {
            AddItemToComboBox(tbWeapons, cbWeapons, Form.CurrentForm.Weapons);
        }

        private void btnRemoveWeapon_Click(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.Weapons.Remove(cbWeapons.Text);
        }

        private void AddItemToComboBox(TextBox tb, ComboBox cb, ObservableCollection<string> list)
        {
            if (tb.Text != "" && tb.Text != " ")
            {
                list.Add(tb.Text.ToUpper());
                cb.SelectedItem = list[list.Count - 1];
            }

            tb.Text = "";
        }

        private void btnNewOccupation_Click(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.Empty();
            tbName.Text = "";

            SetT6ComboBoxToFirstItem(cbT6Ammo);
            SetT6ComboBoxToFirstItem(cbT6Food);
            SetT6ComboBoxToFirstItem(cbT6Water);

            rbArtifactNo.IsChecked = true;
            rbGarbageNo.IsChecked = true;

        }

        private void SetT6ComboBoxToFirstItem(ComboBox cb)
        {
            cb.SelectedItem = cb.Items[0];
        }

        //private void btnAddOccupation_Click(object sender, RoutedEventArgs e)
        //{
        //    OccupationClass oc;

        //    for (int i = 0; i < TextFields.Occupation.Occupations.Count; i++)
        //    {
        //        oc = new OccupationClass();

        //        oc.Name = TextFields.Occupation.Occupations[i];
        //        oc.Traits = Enumerable.ToArray(TextFields.Occupation.GetMultiOptions(TextFields.Occupation.SpecialTrait[i]));
        //        oc.Goals = Enumerable.ToArray(TextFields.Occupation.GetMultiOptions(TextFields.Occupation.SpecialGoal[i]));
        //        oc.SpecialBasicProperty = (int)Enum.Parse(typeof(OccupationClass.BpNames), TextFields.Occupation.SpecialBp[i], true);
        //        oc.Skills = new string[] { TextFields.Occupation.SpecialSkills[i] };
        //        oc.Talents = Enumerable.ToArray(TextFields.Occupation.GetMultiOptions(TextFields.Occupation.SpecialTalents[i]));
        //        oc.Weapons = Enumerable.ToArray(TextFields.Occupation.GetMultiOptions(TextFields.Occupation.SpecialWeapon[i]));
        //        List<string> gearList = TextFields.Occupation.GetMultiOptions(TextFields.Occupation.SpecialEquipment[i]);
        //        oc.AmmoDice = Convert.ToInt32(gearList[0]);
        //        oc.FoodDice = Convert.ToInt32(gearList[1]);
        //        oc.WaterDice = Convert.ToInt32(gearList[2]);
        //        if (i == 1)
        //        {
        //            oc.HasArtifactItem = true;
        //        }
        //        else
        //        {
        //            oc.HasArtifactItem = false;
        //        }
        //        oc.HasGarbageItem = false;

        //        oc.SaveToFile();
        //    }
        //}

        private void btnSaveOccupation_Click(object sender, RoutedEventArgs e)
        {
            Occupation occupation = new Occupation();
            occupation += Form.CurrentForm;

            occupation.SaveToFile();
        }

        private void btnOpenOccupation_Click(object sender, RoutedEventArgs e)
        {
            
                Occupation occupation = new Occupation();
                occupation.LoadFromFile();
            if (occupation.IsLoaded)
            {
                Form.CurrentForm.Empty();

                Form.CurrentForm += occupation;

                tbName.Text = Form.CurrentForm.Name;
                cbSpecialBP.SelectedItem = cbSpecialBP.Items[Form.CurrentForm.SpecialBasicProperty];
                cbT6Ammo.SelectedItem = cbT6Ammo.Items[Form.CurrentForm.AmmoDice];
                cbT6Food.SelectedItem = cbT6Food.Items[Form.CurrentForm.FoodDice];
                cbT6Water.SelectedItem = cbT6Water.Items[Form.CurrentForm.WaterDice];

                if (Form.CurrentForm.HasArtifactItem)
                {
                    rbArtifactYes.IsChecked = true;
                }
                else
                {
                    rbArtifactNo.IsChecked = true;
                }

                if (Form.CurrentForm.HasGarbageItem)
                {
                    rbGarbageYes.IsChecked = true;
                }
                else
                {
                    rbGarbageNo.IsChecked = true;
                }
                SetSelectedItemToComboBox(cbGoals);
                SetSelectedItemToComboBox(cbSpecialSkills);
                SetSelectedItemToComboBox(cbTalents);
                SetSelectedItemToComboBox(cbTraits);
                SetSelectedItemToComboBox(cbWeapons);
            }
            

        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbSpecialBP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           Form.CurrentForm.SpecialBasicProperty = Convert.ToInt32(((ComboBoxItem)cbSpecialBP.SelectedItem).Uid);
        }

        private void cbT6Ammo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int result;
            int.TryParse(((ComboBoxItem)cbT6Ammo.SelectedItem).Content as string, out result);
            Form.CurrentForm.AmmoDice = Convert.ToInt32(result);
        }

        private void cbT6Food_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int result;
            int.TryParse(((ComboBoxItem)cbT6Food.SelectedItem).Content as string, out result);
            Form.CurrentForm.FoodDice = Convert.ToInt32(result);
        }

        private void cbT6Water_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int result;
            int.TryParse(((ComboBoxItem)cbT6Water.SelectedItem).Content as string, out result);
            Form.CurrentForm.WaterDice = Convert.ToInt32(result);
        }

        private void rbArtifactYes_Checked(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.HasArtifactItem = true;
        }

        private void rbArtifactYes_Unchecked(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.HasArtifactItem = false;
        }

        private void rbGarbageYes_Checked(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.HasGarbageItem = true;
        }

        private void rbGarbageYes_Unchecked(object sender, RoutedEventArgs e)
        {
            Form.CurrentForm.HasGarbageItem = false;
        }


        private void SetSelectedItemToComboBox(ComboBox cb)
        {
            if (cb.Items.Count != 0)
            {
                var list = cb.ItemsSource;
                cb.SelectedItem = list.Cast<string>().Last<string>();
            }
        }
    }
}
