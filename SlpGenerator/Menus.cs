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
        static public void GetRandom(object sender, RoutedEventArgs e)
        {
            DropItem sent;
            Label lbl;
            GetLabel(sender, out sent, out lbl);

            DropItem mi = new DropItem();
            mi = sent.Parent as DropItem;

            DropMenu dm;
            dm = sent.Parent as DropMenu;

            SetTextField(dm.GetRandom(), lbl);

            //int index = GetIndex(sender, dm);

            //SetTextField(dm.GetRandom(index), lbl);


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
