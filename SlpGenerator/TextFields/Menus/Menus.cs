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
using System.Windows.Controls.Primitives;

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

            //SetTextField(Occupation.GetEquipment(ExtractIntegersFromEquipment(sent.Header as string)), lbl);
            SetTextField(ThrowDice(sent.Header as string), lbl);
        }

        static public void SetStuff(object sender, RoutedEventArgs e)
        {
            DropItem sent;
            Label lbl;
            GetLabel(sender, out sent, out lbl);

            SetTextField(ThrowDice(sent.Header as string), lbl);

        }

        //static public List<string> ExtractIntegersFromEquipment(string str)
        //{
        //    List<string> returnList = new List<string>();
        //    char[] arr = str.ToCharArray();
        //    foreach (char item in arr)
        //    {
        //        int i = -1;
        //        bool isInt =
        //        int.TryParse(item.ToString(), out i);

        //        if (isInt && i != -1 && i != 6)
        //        {
        //            returnList.Add(i.ToString());
        //        }
        //    }
        //    return returnList;
            
        //}


        //static public string ThrowDice(string str)
        //{
        //    if (str.Contains("T6"))
        //    {
        //        Random rnd = new Random();
        //        List<string> list = new List<string>();
        //        list.AddRange(str.Split(' '));

        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            if (list[i].Contains("T6") && !(list[i].Contains("T66")))
        //            {
        //                int diceMax = 1;

        //                var die = list[i].Split('T')[0].ToCharArray().Where(p => Char.IsNumber(p)).ToArray<char>();
        //                if (die.Length != 0)
        //                {
        //                    diceMax = Convert.ToInt32(string.Join("", die));
        //                }
        //                else
        //                {
        //                    diceMax *= 6;
        //                }
        //                list[i] = rnd.Next(1, diceMax + 1).ToString();


        //            }
        //            else if (list[i] == "T66")
        //            {
        //                if (list.Contains("ST"))
        //                {
        //                    list[i] = rnd.Next(1, 67).ToString();
        //                }
        //                else
        //                {
        //                    list[i] = rnd.Next(1, 67).ToString() + " ST";
        //                }
        //            }

        //        }


        //        string returnString = "";

        //        foreach (string item in list)
        //        {
        //            returnString += item + " ";
        //        }

        //        return returnString;
        //    }
        //    else
        //    {
        //        return str;
        //    }


        //}


        static public string ThrowDice(string str)
        {
            if (str.Contains("T6"))
            {
                Random rnd = new Random();
                List<string> list = new List<string>();
                list.AddRange(str.Split(' '));

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Contains("T6"))
                    {
                        //int diceMax = 1;

                        //var die = list[i].Split('T')[0].ToCharArray().Where(p => Char.IsNumber(p)).ToArray<char>();
                        //if (die.Length != 0)
                        //{
                        //    diceMax = Convert.ToInt32(string.Join("", die));
                        //}
                        //else
                        //{
                        //    diceMax *= 6;
                        //}
                        //list[i] = rnd.Next(1, diceMax + 1).ToString();

                        int left = GetDiceLeftSide(list[i]);

                        int right = GetDiceRightSide(list[i]);

                        if (left == 0 || right == 0)
                        {
                            list[i] = "0";
                        }
                        else
                        {
                            list[i] = rnd.Next(1, left * right).ToString();
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


        public static int GetDiceLeftSide(string str)
        {
            var left = str.Split('T')[0].ToCharArray().Where(p => Char.IsNumber(p)).ToArray<char>();

            int returnInt = 0;
            if (int.TryParse(string.Join("", left), out returnInt))
            {
                return returnInt;
            }
            else
            {
                return 1;
            }
        }

        public static int GetDiceRightSide(string str)
        {
            var right = str.Split('T')[1].ToCharArray().Where(p => Char.IsNumber(p)).ToArray<char>();

            int returnInt = 0;
            if (int.TryParse(string.Join("", right), out returnInt))
            {
                return returnInt;
            }
            else
            {
                return 1;
            }
        }

        //static public string ThrowDice(string str)
        //{
        //    if (str.Contains("T6"))
        //    {
        //        Random rnd = new Random();
        //        List<string> list = new List<string>();
        //        list.AddRange(str.Split(' '));

        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            if (list[i] == "T6")
        //            {
        //                if (list.Contains("ST"))
        //                {
        //                    list[i] = rnd.Next(1, 7).ToString();
        //                }
        //                else
        //                {
        //                    list[i] = rnd.Next(1, 7).ToString() + " ST";
        //                }

        //            }
        //            else if (list[i] == "T66")
        //            {
        //                if (list.Contains("ST"))
        //                {
        //                    list[i] = rnd.Next(1, 67).ToString();
        //                }
        //                else
        //                {
        //                    list[i] = rnd.Next(1, 67).ToString() + " ST";
        //                }
        //            }
        //            else if (list[i] == "2T6")
        //            {
        //                if (list.Contains("ST"))
        //                {
        //                    list[i] = rnd.Next(1, 13).ToString();
        //                }
        //                else
        //                {
        //                    list[i] = rnd.Next(1, 13).ToString() + " ST";
        //                }
        //            }
        //        }


        //        string returnString = "";

        //        foreach (string item in list)
        //        {
        //            returnString += item + " ";
        //        }

        //        return returnString;
        //    }
        //    else
        //    {
        //        return str;
        //    }


        //}

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

            ContextMenu cm = FindContextMenu(sent);

            Button btn = cm.PlacementTarget as Button;
            Viewbox vb = btn.Content as Viewbox;
            lbl = vb.Child as Label;
        }

        public static void GetButton(object sender, out DropItem sent, out Button btn)
        {
            sent = sender as DropItem;

            ContextMenu cm = FindContextMenu(sent);

            btn = cm.PlacementTarget as Button;
        }

        private static ContextMenu FindContextMenu(DropItem sent)
        {
            Control item = (Control)sent.Parent;

            while (!(item is DropMenu))
            {
                item = (Control)item.Parent;
            }

            ContextMenu cm = item as ContextMenu;
            return cm;
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

            DropMenu dm;
            dm = sent.Parent as DropMenu;

            DropItem di = dm.GetRandom();

            if (di.Header.ToString().Contains("T6") && di.Header.ToString().Contains("KRUBB"))
            {
                //SetTextField(Occupation.GetEquipment(ExtractIntegersFromEquipment(di.Header as string)), lbl);
                SetTextField(ThrowDice(di.Header as string), lbl);
            }
            else if(di.Header.ToString().Contains("T6") && !(di.Header.ToString().Contains("KRUBB")))
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
