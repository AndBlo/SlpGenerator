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

        static public void SetTextFromContext(object sender, RoutedEventArgs e)
        {
            MenuItem sent;
            Label lbl;
            GetLabel(sender, out sent, out lbl);

            SetTextField(sent, lbl);

        }

        private static void GetLabel(object sender, out MenuItem sent, out Label lbl)
        {
            sent = sender as MenuItem;
            ContextMenu cm = new ContextMenu();

            cm = sent.Parent as ContextMenu;

            ItemsControl ic = sent.Parent as ItemsControl;

            Button btn = cm.PlacementTarget as Button;
            Viewbox vb = btn.Content as Viewbox;
            lbl = vb.Child as Label;
        }

        static public void SetTextField(MenuItem mi, Label field)
        {
            field.Content =
                        (string)mi.Header == "TÖM" ?
                        "" :
                        mi.Header.ToString();
        }
        static public void GetRandom(object sender, RoutedEventArgs e)
        {
            MenuItem sent;
            Label lbl;
            GetLabel(sender, out sent, out lbl);

            MenuItem mi = new MenuItem();
            mi = sent.Parent as MenuItem;

            DropMenu dm;
            dm = sent.Parent as DropMenu;

            int index = GetIndex(sender, dm);

            SetTextField(dm.GetRandom(index), lbl);


        }

        private static int GetIndex(object sender, DropMenu dm)
        {
            List<string> list = new List<string>() { "init1", "init2", "init3", "init4" };
            for (int i = 4; i < dm.Items.Count; i++)
            {
                list.Add(((MenuItem)dm.Items[i]).Header.ToString());

            }
            int index;
            index = list.FindIndex(p => p == ((MenuItem)sender).Header.ToString());
            return index;
        }
    }
}
