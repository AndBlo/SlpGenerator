using SlpGenerator.TextFields.Menus.MenuList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SlpGenerator.TextFields.Menus.DropItem
{
    class DropItem : MenuItem
    {
        Random rnd;

        public DropItem GetRandomChildItem()
        {
            rnd = new Random();
            List<DropItem> list = GetList(this as DropItem);
            return list[rnd.Next(0, list.Count)];
        }


        public static List<DropItem> GetList(DropItem di)
        {
            List<DropItem> diLi = new List<DropItem>();
            for (int i = 0; i < di.Items.Count; i++)
            {
                if (!(((object)di.Items[i]).GetType() == typeof(Separator)))
                {
                    if (!(((DropItem)di.Items[i]).Header.ToString().Contains("SLUMPA") ||
                        ((DropItem)di.Items[i]).Header.ToString().Contains("TÖM") ||
                        ((DropItem)di.Items[i]).Header.ToString().Contains("KASTA OM")))
                    {
                        if (((DropItem)di.Items[i]).HasItems)
                        {
                            diLi.AddRange(GetList(di.Items[i] as DropItem));
                        }
                        else
                        {
                            diLi.Add(di.Items[i] as DropItem);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            return diLi;
        }

        public static List<DropItem> GetList(DropMenu di)
        {
            List<DropItem> diLi = new List<DropItem>();
            for (int i = 0; i < di.Items.Count; i++)
            {
                if (!(((object)di.Items[i]).GetType() == typeof(Separator)))
                {
                    if (!(((DropItem)di.Items[i]).Header.ToString().Contains("SLUMPA") ||
                        ((DropItem)di.Items[i]).Header.ToString().Contains("TÖM")) ||
                        ((DropItem)di.Items[i]).Header.ToString().Contains("KASTA OM"))
                    {
                        if (((DropItem)di.Items[i]).HasItems)
                        {
                            diLi.AddRange(GetList(di.Items[i] as DropItem));
                        }
                        else
                        {
                            diLi.Add(di.Items[i] as DropItem);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            return diLi;
        }

        public void AddRange(List<string> list, RoutedEventHandler textSetter)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DropItem di = new DropItem();
                di.Header = list[i];
                di.Click += textSetter;
                this.Items.Add(di);
            }

        }
        public void AddRange(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                DropItem di = new DropItem();
                di.Header = list[i];
                this.Items.Add(di);
            }

        }

        public void AddItem(string item, RoutedEventHandler textSetter)
        {
                DropItem di = new DropItem();
                di.Header = item;
                di.Click += textSetter;
                this.Items.Add(di);

        }


        //public List<DropItem> GetList(DropItem di)
        //{
        //    List<DropItem> diLi = new List<DropItem>();
        //    for (int i = 0; i < this.Items.Count; i++)
        //    {
        //        if (!((DropItem)this.Items[i]).Header.ToString().Contains("SLUMPA") ||
        //            !((DropItem)this.Items[i]).Header.ToString().Contains("TÖM") ||
        //            !((DropItem)this.Items[i]).Header.ToString().Contains("SPECIFIKT") ||
        //            ((DropItem)this.Items[i]) != null)
        //        {
        //            if (((DropItem)this.Items[i]).HasItems)
        //            {
        //                diLi.AddRange(GetList(this.Items[i] as DropItem));
        //            }
        //            else
        //            {
        //                diLi.Add(this.Items[i] as DropItem);
        //            }
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //    return diLi;
        //}



    }
}
