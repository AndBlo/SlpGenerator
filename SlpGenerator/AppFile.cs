using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Collections;

namespace SlpGenerator
{
    public class AppFile
    {
        private Dictionary<string, string> od { get; set; } = new Dictionary<string, string>();

        public List<string> Keys { get; set; } = new List<string>();

        public List<string> Values { get; set; } = new List<string>();

        public string StreamString { get; set; }


        public AppFile(Grid grid)
        {
            PopulateKeys(grid);
        }

        public AppFile()
        {

        }


        private void PopulateLists(Grid grid)
        {
            List<Label> labelList =
            SlpGenerator.MainWindow.GetLabelsFromGrid(grid);

            for (int i = 0; i < labelList.Count; i++)
            {
                Keys.Add(labelList[i].Uid as string);
                Values.Add(labelList[i].Content as string);
            }

        }

        private void PopulateKeys(Grid grid)
        {
            List<Label> labelList =
            SlpGenerator.MainWindow.GetLabelsFromGrid(grid);

            for (int i = 0; i < labelList.Count; i++)
            {
                Keys.Add(labelList[i].Uid as string);
            }

        }

        private void PopulateDictionary(Grid grid)
        {
            List<Label> labelList =
            SlpGenerator.MainWindow.GetLabelsFromGrid(grid);

            for (int i = 0; i < labelList.Count; i++)
            {
                od.Add(labelList[i].Uid, labelList[i].Content as string);
            }

        }

        public void Save(Grid grid)
        {
            PopulateDictionary(grid);

            string output = JsonConvert.SerializeObject(od);
            

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SLP file (*.slp)|*.slp";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName, true))
                {
                    writer.WriteLine(output);
                }
            }

        }

        public void Open (Grid grid)
        {
            string input = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SLP file (*.slp)|*.slp";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                using (var reader = new StreamReader(openFileDialog.FileName, true))
                {
                    input = reader.ReadLine();
                }
            }

            var odIn = JsonConvert.DeserializeObject<Dictionary<string, string>>(input);

            List<Label> labelList =
                    SlpGenerator.MainWindow.GetLabelsFromGrid(grid);

            foreach (var pair in odIn)
            {
                MainWindow.SetLabel(labelList, pair.Key, pair.Value);
            }
        }

        //public void Save(Grid grid)
        //{
        //    PopulateLists(grid);

        //    for (int i = 0; i < Keys.Count; i++)
        //    {
        //        StreamString
        //            += Keys[i]
        //            + "_";
        //        StreamString
        //            += Values[i]
        //            + "|";
        //    }

        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "SLP file (*.slp)|*.slp";
        //    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //    if (saveFileDialog.ShowDialog() == true)
        //    {
        //        using (var writer = new StreamWriter(saveFileDialog.FileName, true))
        //        {
        //            writer.WriteLine(StreamString);
        //        }
        //    }
        //}
        //public void Open(Grid grid)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "SLP file (*.slp)|*.slp";
        //    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        using (var reader = new StreamReader(openFileDialog.FileName, true))
        //        {
        //            StreamString = reader.ReadLine();
        //        }
        //    }

        //    if (StreamString != null)
        //    {

        //        string[] arr;
        //        string[] arr2;
        //        arr = StreamString.Split('|');

        //        for (int i = 0; i < arr.Length - 1; i++)
        //        {
        //            arr2 = arr[i].Split('_');
        //            Keys.Add(arr2[0]);
        //            Values.Add(arr2[1]);
        //        }

        //        List<Label> labelList =
        //            SlpGenerator.MainWindow.GetLabelsFromGrid(grid);

        //        for (int i = 0; i < labelList.Count; i++)
        //        {
        //            MainWindow.SetLabel(labelList, Keys[i], Values[i]);
        //        }
        //    }


        //}

    }
}
