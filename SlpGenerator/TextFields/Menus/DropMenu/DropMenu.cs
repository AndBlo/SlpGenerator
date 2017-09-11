using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SlpGenerator.TextFields.Menus.DropItem;
using System.Collections;

namespace SlpGenerator.TextFields.Menus.MenuList
{
    class DropMenu : ContextMenu
    {
        Random rnd;

        public Menus.DropItem.DropItem GetItem(string headerName)
        {
            var collection = this.Items.SourceCollection;

            //var diCollection = collection.Cast<object>().Where(p => (p is DropItem.DropItem));

            //DropItem.DropItem di = diCollection.First(p => (p as DropItem.DropItem).Header.ToString() == headerName) as DropItem.DropItem;

            DropItem.DropItem di = 
                collection.Cast<object>().
                Where(p => (p is DropItem.DropItem)).
                First(p => (p as DropItem.DropItem).Header.ToString() == headerName) as DropItem.DropItem;

            return di;
        }

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

        public DropItem.DropItem GetRandom()
        {
            rnd = new Random();
            List<DropItem.DropItem> diLi = new List<DropItem.DropItem>();
            diLi = DropItem.DropItem.GetList(this);
            return diLi[rnd.Next(0, diLi.Count)];
        }

    }
}
