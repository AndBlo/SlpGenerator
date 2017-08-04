using SlpGenerator.TextFields.Menus.MenuList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SlpGenerator.TextFields;
using System.Windows;
using SlpGenerator.TextFields.Menus.DropItem;

namespace SlpGenerator.Menus
{
    static class SlpMenu
    {
        public static DropMenu name { get; set; }
        public static DropMenu occupation { get; set; }
        public static DropMenu trait { get; set; }
        public static DropMenu goal { get; set; }
        public static DropMenu skill { get; set; }
        public static DropMenu talent { get; set; }
        public static DropMenu mutation { get; set; }
        public static DropMenu equipment { get; set; }
        public static DropMenu point { get; set; }

        static public void SetEquipment(object sender, RoutedEventArgs e)
        {
            DropItem sent;
            Label lbl;
            GetLabel(sender, out sent, out lbl);

            SetTextField(Occupation.GetEquipment(ExtractIntegersFromEquipment(sent.Header as string)), lbl);

        }

        static public void SetArtifactOrGarbage(object sender, RoutedEventArgs e)
        {
            DropItem sent;
            Label lbl;
            GetLabel(sender, out sent, out lbl);

            SetTextField(ThrowDice(sent.Header as string), lbl);

        }

        static public List<string> ExtractIntegersFromEquipment(string str)
        {
            List<string> returnList = new List<string>();
            char[] arr = str.ToCharArray();
            foreach (char item in arr)
            {
                int i = -1;
                bool isInt =
                int.TryParse(item.ToString(), out i);

                if (isInt && i != -1 && i != 6)
                {
                    returnList.Add(i.ToString());
                }
            }
            return returnList;
            
        }

        static public string ThrowDice(string str)
        {
            if (str.Contains("T6"))
            {
                Random rnd = new Random();
                List<string> list = new List<string>();
                list.AddRange(str.Split(' '));
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == "T6")
                    {
                        if (list.Contains("ST"))
                        {
                            list[i] = rnd.Next(1, 7).ToString();
                        }
                        else
                        {
                            list[i] = rnd.Next(1, 7).ToString() + " ST";
                        }

                    }
                    else if (list[i] == "T66")
                    {
                        if (list.Contains("ST"))
                        {
                            list[i] = rnd.Next(1, 67).ToString();
                        }
                        else
                        {
                            list[i] = rnd.Next(1, 67).ToString() + " ST";
                        }
                    }
                    else if (list[i] == "2T6")
                    {
                        if (list.Contains("ST"))
                        {
                            list[i] = rnd.Next(1, 13).ToString();
                        }
                        else
                        {
                            list[i] = rnd.Next(1, 13).ToString() + " ST";
                        }
                    }
                }
                

                string returnString = "";

                foreach (string item in list)
                {
                    returnString += item + " ";
                }

                return returnString;
            }
            else
            {
                return str;
            }
            

        }

        static public void SetTextFromContext(object sender, RoutedEventArgs e)
        {
            DropItem sent;
            Label lbl;
            GetLabel(sender, out sent, out lbl);

            SetTextField(sent, lbl);

        }

        public static void GetLabel(object sender, out DropItem sent, out Label lbl)
        {
            sent = sender as DropItem;

            ContextMenu cm = new ContextMenu();

            if (sent.Parent.GetType() == typeof(DropMenu))
            {
                cm = sent.Parent as ContextMenu;
            }
            else if (((DropItem)sent.Parent).Parent.GetType() == typeof(DropMenu))
            {
                cm = ((DropItem)sent.Parent).Parent as ContextMenu;
            }
            else if (((DropItem)((DropItem)sent.Parent).Parent).Parent.GetType() == typeof(DropMenu))
            {
                cm = ((DropItem)((DropItem)sent.Parent).Parent).Parent as ContextMenu;
            }
            else if (((DropItem)((DropItem)((DropItem)sent.Parent).Parent).Parent).Parent.GetType() == typeof(DropMenu))
            {
                cm = ((DropItem)((DropItem)((DropItem)sent.Parent).Parent).Parent).Parent as ContextMenu;
            }

            Button btn = cm.PlacementTarget as Button;
            Viewbox vb = btn.Content as Viewbox;
            lbl = vb.Child as Label;
        }

        public static void GetButton(object sender, out DropItem sent, out Button btn)
        {
            sent = sender as DropItem;

            ContextMenu cm = new ContextMenu();

            if (sent.Parent.GetType() == typeof(DropMenu))
            {
                cm = sent.Parent as ContextMenu;
            }
            else if (((DropItem)sent.Parent).Parent.GetType() == typeof(DropMenu))
            {
                cm = ((DropItem)sent.Parent).Parent as ContextMenu;
            }
            else if (((DropItem)((DropItem)sent.Parent).Parent).Parent.GetType() == typeof(DropMenu))
            {
                cm = ((DropItem)((DropItem)sent.Parent).Parent).Parent as ContextMenu;
            }
            else if (((DropItem)((DropItem)((DropItem)sent.Parent).Parent).Parent).Parent.GetType() == typeof(DropMenu))
            {
                cm = ((DropItem)((DropItem)((DropItem)sent.Parent).Parent).Parent).Parent as ContextMenu;
            }

            btn = cm.PlacementTarget as Button;
        }

        static public void SetTextField(DropItem mi, Label field)
        {
            field.Content =
                        (string)mi.Header == "TÖM" ?
                        "" :
                        mi.Header.ToString();
        }

        static public void SetTextField(string text, Label field)
        {
            field.Content =
                        text == "TÖM" ?
                        "" :
                        text;
        }

        static public void GetRandom(object sender, RoutedEventArgs e)
        {
            DropItem sent;
            Label lbl;
            GetLabel(sender, out sent, out lbl);

            //DropItem mi = new DropItem();
            //mi = sent.Parent as DropItem;

            DropMenu dm;
            dm = sent.Parent as DropMenu;

            DropItem di = dm.GetRandom();

            if (((string)di.Header).Contains("PATRONER"))
            {
                SetTextField(Occupation.GetEquipment(ExtractIntegersFromEquipment(di.Header as string)), lbl);
            }
            else if ((((DropItem)di.Parent).Header as string).ToUpper().Contains("SKROT"))
            {
                SetTextField(ThrowDice(di.Header as string), lbl);
            }
            else
            {
                SetTextField(di, lbl);
            }
        }

        private static int GetIndex(object sender, DropMenu dm)
        {
            List<string> list = new List<string>() { "init1", "init2", "init3", "init4" };
            for (int i = 4; i < dm.Items.Count; i++)
            {
                list.Add(((DropItem)dm.Items[i]).Header.ToString());

            }
            int index;
            index = list.FindIndex(p => p == ((DropItem)sender).Header.ToString());
            return index;
        }
    }
}
