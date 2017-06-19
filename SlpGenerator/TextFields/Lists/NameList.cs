using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace SlpGenerator.TextFields.Lists
{
    public class NameList : List<string>
    {
        protected Random Random;

        public void Load(string nameFile)
        {
            string file = @"TextFiles\" + nameFile;

            Random = new Random(DateTime.Now.Millisecond ^ file.Length);
            Thread.Sleep(1);

            using (var sr = new StreamReader(file, Encoding.GetEncoding("windows-1252")))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    Add(line);
                }
            }
        }

        public virtual string GetRandomName()
        {
            Random = new Random();
            return this[Random.Next() % Count];
        }
    }
}
