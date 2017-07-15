using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SlpGenerator.TextFields.Menus.MenuList
{
    class DropMenu : ContextMenu
    {
        Random rnd;
        public DropMenu(List<string> list, RoutedEventHandler random, RoutedEventHandler textSetter, string name)
        {
            AddInitialItems(random, textSetter);
            AddItems(list, textSetter);
            this.Name = name;
        }

        private void AddInitialItems(RoutedEventHandler random, RoutedEventHandler textSetter)
        {
            //Skapar första menyvalet "SLUMPA!"
            MenuItem firstItem = new MenuItem();
            firstItem.Click += new RoutedEventHandler(random);
            firstItem.Header = "SLUMPA";
            firstItem.Tag = 0;

            // Skapar en separator
            Separator secondItem = new Separator();
            secondItem.Uid = "separator";

            // SKapar andra menyvalet som nollar textfältet
            MenuItem thirdItem = new MenuItem();
            thirdItem.Click += new RoutedEventHandler(textSetter);
            thirdItem.Header = "TÖM";
            thirdItem.Tag = 0;

            //Skapar en andra separator
            Separator fourthItem = new Separator();
            fourthItem.Uid = "separator";

            this.Items.Add(firstItem);
            this.Items.Add(secondItem);
            this.Items.Add(thirdItem);
            this.Items.Add(fourthItem);
        }
        private void AddInitialItems(MenuItem subMi ,RoutedEventHandler random, RoutedEventHandler textSetter)
        {
            //Skapar första menyvalet "SLUMPA!"
            MenuItem firstItem = new MenuItem();
            firstItem.Click += new RoutedEventHandler(random);
            firstItem.Header = "SLUMPA";
            firstItem.Tag = 1;

            // Skapar en separator
            Separator secondItem = new Separator();
            secondItem.Uid = "separator";

            // SKapar andra menyvalet som nollar textfältet
            MenuItem thirdItem = new MenuItem();
            thirdItem.Click += new RoutedEventHandler(textSetter);
            thirdItem.Header = "TÖM";
            thirdItem.Tag = 1;

            //Skapar en andra separator
            Separator fourthItem = new Separator();
            fourthItem.Uid = "separator";

            subMi.Items.Add(firstItem);
            subMi.Items.Add(secondItem);
            subMi.Items.Add(thirdItem);
            subMi.Items.Add(fourthItem);
        }

        public void AddItems(List<string> list, RoutedEventHandler textSetter)
        {
            for (int i = 0; i < list.Count; i++)
            {
                MenuItem mi = new MenuItem();
                mi.Header = list[i];
                mi.Click += textSetter;
                this.Items.Add(mi);
            }
        }
        public void AddItemsToSubMenu(List<string> list, RoutedEventHandler random, RoutedEventHandler textSetter, int subMenuIndex)
        {
            if (this.HasItems)
            {
                AddInitialItems((MenuItem)this.Items[subMenuIndex], random ,textSetter);

                for (int i = 0; i < list.Count; i++)
                {
                    MenuItem mi = new MenuItem();
                    mi.Header = list[i];
                    mi.Click += textSetter;
                    ((MenuItem)this.Items[subMenuIndex]).Items.Add(list[i]);
                }
            }
            
        }

        public void AddSubMenu(int insertIndex, string header)
        {
            MenuItem mi = new MenuItem() { Header = header, Name = header };
            this.Items.Insert(insertIndex, mi);
        }

        public MenuItem GetRandom(int index)
        {
            rnd = new Random();
            if (index == -1)
            {
                return ((MenuItem)this.Items[rnd.Next(4, Items.Count)]);
            }
            else
            {
                MenuItem mi = new MenuItem();
                mi = (MenuItem)this.Items[index];

                return ((MenuItem)mi.Items[rnd.Next(4, Items.Count)]);
            }
        }
    }
}
