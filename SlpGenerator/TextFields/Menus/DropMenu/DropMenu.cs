using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SlpGenerator.TextFields.Menus.DropItem;

namespace SlpGenerator.TextFields.Menus.MenuList
{
    class DropMenu : ContextMenu
    {
        Random rnd;
        public DropMenu(List<string> list, RoutedEventHandler random, RoutedEventHandler textSetter, string name, bool itemsAreParents)
        {
            AddInitialItems(random, textSetter);
            if (!itemsAreParents)
            {
                AddItems(list, textSetter);
            }
            else
            {
                AddItems(list);
            }
            this.Name = name;
        }

        public DropMenu(string item, RoutedEventHandler random, RoutedEventHandler textSetter, string name, bool itemsAreParents)
        {
            AddInitialItems(random, textSetter);
            if (!itemsAreParents)
            {
                AddItems(item, textSetter);
            }
            else
            {
                AddItems(item);
            }
            this.Name = name;
        }

        public DropMenu(string item, string name)
        {
            AddItems(item);
            this.Name = name;
        }

        private void AddInitialItems(RoutedEventHandler random, RoutedEventHandler textSetter)
        {
            //Skapar första menyvalet "SLUMPA!"
            DropItem.DropItem firstItem = new DropItem.DropItem();
            firstItem.Click += new RoutedEventHandler(random);
            firstItem.Header = "SLUMPA";
            firstItem.Tag = 0;

            // Skapar en separator
            Separator secondItem = new Separator();
            secondItem.Uid = "separator";

            // SKapar andra menyvalet som nollar textfältet
            DropItem.DropItem thirdItem = new DropItem.DropItem();
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
        private void AddInitialItems(DropItem.DropItem subMi, RoutedEventHandler random, RoutedEventHandler textSetter)
        {
            //Skapar första menyvalet "SLUMPA!"
            DropItem.DropItem firstItem = new DropItem.DropItem();
            firstItem.Click += new RoutedEventHandler(random);
            firstItem.Header = "SLUMPA";
            firstItem.Tag = 1;

            // Skapar en separator
            Separator secondItem = new Separator();
            secondItem.Uid = "separator";

            // SKapar andra menyvalet som nollar textfältet
            DropItem.DropItem thirdItem = new DropItem.DropItem();
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
                DropItem.DropItem mi = new DropItem.DropItem();
                mi.Header = list[i];
                mi.Click += textSetter;
                this.Items.Add(mi);
            }
        }

        public void AddItems(string item, RoutedEventHandler textSetter)
        {
            DropItem.DropItem mi = new DropItem.DropItem();
            mi.Header = item;
            mi.Click += textSetter;
            this.Items.Add(mi);
        }

        public void AddItems(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DropItem.DropItem mi = new DropItem.DropItem();
                mi.Header = list[i];
                this.Items.Add(mi);
            }
        }

        public void AddItems(string item)
        {
            DropItem.DropItem mi = new DropItem.DropItem();
            mi.Header = item;
            this.Items.Add(mi);
        }

        public void AddItemsToSubMenu(List<string> list, RoutedEventHandler textSetter, int menuIndex)
        {
            if (this.HasItems)
            {
                //AddInitialItems((DropItem.DropItem)this.Items[subMenuIndex], random ,textSetter);

                for (int i = 0; i < list.Count; i++)
                {
                    DropItem.DropItem mi = new DropItem.DropItem();
                    mi.Header = list[i];
                    mi.Click += textSetter;
                    ((DropItem.DropItem)this.Items[menuIndex]).Items.Add(mi);
                }
            }

        }
        public void AddItemsToSubMenu(List<string> list, int menuIndex)
        {
            if (this.HasItems)
            {
                //AddInitialItems((DropItem.DropItem)this.Items[subMenuIndex], random ,textSetter);

                for (int i = 0; i < list.Count; i++)
                {
                    DropItem.DropItem mi = new DropItem.DropItem();
                    mi.Header = list[i];
                    ((DropItem.DropItem)this.Items[menuIndex]).Items.Add(mi);
                }
            }

        }

        public void AddItemsToSubMenu(List<string> list, int menuIndex, int subMenuIndex)
        {
            if (this.HasItems)
            {
                //AddInitialItems((DropItem.DropItem)this.Items[subMenuIndex], random ,textSetter);

                for (int i = 0; i < list.Count; i++)
                {
                    DropItem.DropItem mi = new DropItem.DropItem();
                    mi.Header = list[i];
                    (((DropItem.DropItem)this.Items[subMenuIndex]).Items[subMenuIndex] as DropItem.DropItem).Items.Add(mi);
                }
            }

        }

        public void AddItemsToSubMenu(string item, RoutedEventHandler textSetter, int menuIndex, int subMenuIndex)
        {
            if (this.HasItems)
            {
                //AddInitialItems((DropItem.DropItem)this.Items[subMenuIndex], random ,textSetter);
                DropItem.DropItem mi1 = new DropItem.DropItem();
                DropItem.DropItem mi2 = new DropItem.DropItem();
                DropItem.DropItem miAdd = new DropItem.DropItem();

                mi1 = this.Items[menuIndex] as DropItem.DropItem;
                mi2 = mi1.Items[subMenuIndex] as DropItem.DropItem;

                miAdd.Header = item;
                miAdd.Click += textSetter;
                mi2.Items.Add(miAdd);
            }

        }


        public void AddSubMenu(int insertIndex, string header)
        {
            DropItem.DropItem mi = new DropItem.DropItem() { Header = header, Name = Util.RemoveWhitespace(header) };
            this.Items.Insert(insertIndex, mi);
        }

        public DropItem.DropItem GetRandom()
        {
            rnd = new Random();
            List<DropItem.DropItem> diLi = new List<DropItem.DropItem>();
            diLi = DropItem.DropItem.GetList(this);
            return diLi[rnd.Next(0, diLi.Count)];
        }

    }
}
