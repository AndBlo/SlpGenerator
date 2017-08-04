using SlpGenerator.TextFields.Lists;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SlpGenerator.TextFields
{
    public static class Occupation
    {

        public enum Names : int
        {
            Krossare = 0,
            Skrotskalle = 1,
            Zonstrykare = 2,
            Fixare = 3,
            MutantMedHund = 4,
            Kronikor = 5,
            Boss = 6,
            Slav = 7
        }
        /* "Special"-variablerna lagrar de specifika egenskaperna för de olika sysslorna i följande index": 
 *              0 = Krossare, 
 *              1 = Skrotskalle, 
 *              2 = Zonstrykare, 
 *              3 = Fixare, 
 *              4 = Mutant med hund,
 *              5 = Krönikör.
 *              6 = Boss
 *              7 = Slav*/

        // Lagrar namnet på de olika sysslorna
        public static OccupationList Occupations { get; set; } = new OccupationList();

        public static OccupationList SpecialBp { get; set; } = new OccupationList();

        public static OccupationList SpecialSkills { get; set; } = new OccupationList();

        public static OccupationList SpecialTalents { get; set; } = new OccupationList();

        public static OccupationList SpecialEquipment { get; set; } = new OccupationList();

        public static OccupationList SpecialWeapon { get; set; } = new OccupationList();

        public static OccupationList SpecialTrait { get; set; } = new OccupationList();

        public static OccupationList SpecialGoal { get; set; } = new OccupationList();

        // Returnerar en slumpad sträng från en "multisträng" (En sträng med fler ord som skiljs åt av "_")
        public static string GetRandomMultiOption(string multiString)
        {
            List<string> multiOption = GetMultiOptions(multiString);

            Random Random = new Random(DateTime.Now.Millisecond ^ multiOption[0].Length);
            Thread.Sleep(1);

            string result = multiOption[Random.Next() % multiOption.Count];

            if (result.ToLower() == "inget")
            {
                return "";
            }
            else
            {
                return result;
            }

        }

        // Returnerar en lista av orden från en "multistring".
        public static List<string> GetMultiOptions(string multiString)
        {
            string[] multiOption;
            multiOption = multiString.Split('_');
            List<string> strList = new List<string>();

            return multiOption.ToList<string>();
        }

        // Returnerar en lista med strängar där samtliga "multistrings" i listan lagras
        public static OccupationList GetAllOptions(OccupationList list)
        {
            OccupationList returnList = new OccupationList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] multiOption;
                multiOption = list[i].Split('_');
                
                returnList.AddRange(multiOption);

                // DeletetDoubles raderar dubletter som kan förekomma
                returnList = DeleteDoubles(returnList);
            }

            return returnList;
        }

        // Raderar dubletteri en lista
        public static OccupationList DeleteDoubles(OccupationList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count - i; j++)
                {
                    if (list[i] == list[j])
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            return list;
        }

        // "list" som skickas in innehåller siffror som står för antalet tärningar
        // som ska "kastas". En sträng returneras med färdig-slumpade värden samt 
        // vad de värdena står för.
        public static string GetEquipment(List<string> list)
        {

            int ammoDice = Convert.ToInt32(list[0]);
            int foodDice = Convert.ToInt32(list[1]);
            int waterDice = Convert.ToInt32(list[2]);

            Random rnd = new Random();

            int ammoRes = 0;
            int foodRes = 0;
            int waterRes = 0;

            // "slår tärningar", T6or. ammoInt är antalet tärningar att kasta.
            for (int i = 0; i < ammoDice; i++)
            {
                ammoRes += rnd.Next(1, 7);
            }

            for (int i = 0; i < foodDice; i++)
            {
                foodRes += rnd.Next(1, 7);
            }

            for (int i = 0; i < waterDice; i++)
            {
                waterRes += rnd.Next(1, 7);
            }

            return string.Format("PATRONER: {0} KRUBB: {1} VATTEN: {2}",
                ammoRes,
                foodRes,
                waterRes);
        }

        // Returnerar en lista med antalet tärningar för varje kategori.
        public static string ShowEquipmentDice(List<string> list)
        {
            string ammo = "PATRONER: " + list[0] + "*T6. ";
            string food = "KRUBB: " + list[1] + "*T6. ";
            string water = "VATTEN: " + list[2] + "*T6. ";

            return ammo + food + water;
        }


    }

}