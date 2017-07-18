using SlpGenerator.TextFields.Lists;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SlpGenerator.TextFields
{
    public static class Occupation
    {
        // Lagrar namnet på de olika sysslorna
        public static OccupationList Occupations { get; set; } = new OccupationList();

        /* "Special"-variablerna lagrar de specifika egenskaperna för de olika sysslorna i följande index": 
         *              0 = Krossare, 
         *              1 = Skrotskalle, 
         *              2 = Zonstrykare, 
         *              3 = Fixare, 
         *              4 = Mutant med hund,
         *              5 = Krönikör.
         *              6 = Boss
         *              7 = Slav*/
        public static OccupationList SpecialProps { get; set; } = new OccupationList();

        public static OccupationList SpecialSkills { get; set; } = new OccupationList();

        public static OccupationList SpecialTalents { get; set; } = new OccupationList();

        public static OccupationList SpecialEquipment { get; set; } = new OccupationList();

        public static OccupationList SpecialWeapon { get; set; } = new OccupationList();

        public static OccupationList SpecialTrait { get; set; } = new OccupationList();

        public static OccupationList SpecialGoal { get; set; } = new OccupationList();

        /* CurrentOccu: 
         *              0 = Syssla, 
         *              1 = Grundegenskap, 
         *              2 = Färdighet, 
         *              3 = Talang, 
         *              4 = Vapen,
         *              5 = Utrustning.
         *              6 = Utseende
         *              7 = Mål*/
        public static OccupationList CurrentOccu { get; set; } = new OccupationList() { "", "", "", "", "", "", "", "" };

        // CurrentEquip lagrar värdena för vad karaktären startar med för mängd: [0]Patroner, [1]Krubb, [2]Vatten.
        // Instansieras i "InitializeCurrentEquipVar" och får sina värden i "GetEquipment"
        public static OccupationList CurrentEquip { get; set; }

        // Laddar värdena för den speciella sysslans alla olika egenskaper, baserat på vilken syssla som slumpats fram.
        public static void SetCurrentOccu()
        {
            string occupationString;
            if (CurrentOccu[0] == "MUTANT MED HUND")
            {
                occupationString = "MUTANTMEDHUND";
            }
            else
            {
                occupationString = CurrentOccu[0];
            }

            OccupationsEnum result;
            if (Enum.TryParse<OccupationsEnum>(occupationString, true, out result))
            {

                switch (result)
                {
                    case OccupationsEnum.KROSSARE:
                        CurrentOccu[1] = SpecialProps[0];
                        CurrentOccu[2] = SpecialSkills[0];
                        CurrentOccu[3] = SpecialTalents[0];
                        CurrentOccu[4] = SpecialWeapon[0];
                        CurrentOccu[5] = SpecialEquipment[0];
                        CurrentOccu[6] = SpecialTrait[0];
                        CurrentOccu[7] = SpecialGoal[0];
                        break;
                    case OccupationsEnum.SKROTSKALLE:
                        CurrentOccu[1] = SpecialProps[1];
                        CurrentOccu[2] = SpecialSkills[1];
                        CurrentOccu[3] = SpecialTalents[1];
                        CurrentOccu[4] = SpecialWeapon[1];
                        CurrentOccu[5] = SpecialEquipment[1];
                        CurrentOccu[6] = SpecialTrait[1];
                        CurrentOccu[7] = SpecialGoal[1];
                        break;
                    case OccupationsEnum.ZONSTRYKARE:
                        CurrentOccu[1] = SpecialProps[2];
                        CurrentOccu[2] = SpecialSkills[2];
                        CurrentOccu[3] = SpecialTalents[2];
                        CurrentOccu[4] = SpecialWeapon[2];
                        CurrentOccu[5] = SpecialEquipment[2];
                        CurrentOccu[6] = SpecialTrait[2];
                        CurrentOccu[7] = SpecialGoal[2];
                        break;
                    case OccupationsEnum.FIXARE:
                        CurrentOccu[1] = SpecialProps[3];
                        CurrentOccu[2] = SpecialSkills[3];
                        CurrentOccu[3] = SpecialTalents[3];
                        CurrentOccu[4] = SpecialWeapon[3];
                        CurrentOccu[5] = SpecialEquipment[3];
                        CurrentOccu[6] = SpecialTrait[3];
                        CurrentOccu[7] = SpecialGoal[3];
                        break;
                    case OccupationsEnum.MUTANTMEDHUND:
                        CurrentOccu[1] = SpecialProps[4];
                        CurrentOccu[2] = SpecialSkills[4];
                        CurrentOccu[3] = SpecialTalents[4];
                        CurrentOccu[4] = SpecialWeapon[4];
                        CurrentOccu[5] = SpecialEquipment[4];
                        CurrentOccu[6] = SpecialTrait[4];
                        CurrentOccu[7] = SpecialGoal[4];
                        break;
                    case OccupationsEnum.KRÖNIKÖR:
                        CurrentOccu[1] = SpecialProps[5];
                        CurrentOccu[2] = SpecialSkills[5];
                        CurrentOccu[3] = SpecialTalents[5];
                        CurrentOccu[4] = SpecialWeapon[5];
                        CurrentOccu[5] = SpecialEquipment[5];
                        CurrentOccu[6] = SpecialTrait[5];
                        CurrentOccu[7] = SpecialGoal[5];
                        break;
                    case OccupationsEnum.BOSS:
                        CurrentOccu[1] = SpecialProps[6];
                        CurrentOccu[2] = SpecialSkills[6];
                        CurrentOccu[3] = SpecialTalents[6];
                        CurrentOccu[4] = SpecialWeapon[6];
                        CurrentOccu[5] = SpecialEquipment[6];
                        CurrentOccu[6] = SpecialTrait[6];
                        CurrentOccu[7] = SpecialGoal[6];
                        break;
                    case OccupationsEnum.SLAV:
                        CurrentOccu[1] = SpecialProps[7];
                        CurrentOccu[2] = SpecialSkills[7];
                        CurrentOccu[3] = SpecialTalents[7];
                        CurrentOccu[4] = SpecialWeapon[7];
                        CurrentOccu[5] = SpecialEquipment[7];
                        CurrentOccu[6] = SpecialTrait[7];
                        CurrentOccu[7] = SpecialGoal[7];
                        break;
                    default:
                        break;
                }
            }
        }

        // Slumpar fram ett värde från en sträng som innehåller fler alternativ, där alternativen separeras med "_".
        public static string GetRandomMultiOption(int index)
        {
            string[] multiOption;
            multiOption = CurrentOccu[index].Split('_');

            Random Random = new Random(DateTime.Now.Millisecond ^ multiOption[0].Length);
            Thread.Sleep(1);

            string result = multiOption[Random.Next() % multiOption.Length];

            if (result.ToLower() == "inget")
            {
                return "";
            }
            else
            {
                return result;
            }

        }

        // Slumpar fram ett värde från en sträng som innehåller fler alternativ, där alternativen separeras med "_".
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

        public static List<string> GetMultiOptions(int index)
        {
            string[] multiOption;
            multiOption = CurrentOccu[index].Split('_');
            List<string> strList = new List<string>();

            return multiOption.ToList<string>();
        }

        public static List<string> GetMultiOptions(string multiString)
        {
            string[] multiOption;
            multiOption = multiString.Split('_');
            List<string> strList = new List<string>();

            return multiOption.ToList<string>();
        }

        public static List<string> GetAllOptions(List<string> list)
        {
            List<string> returnList = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                string[] multiOption;
                multiOption = list[i].Split('_');

                returnList.AddRange(multiOption);
            }

            return returnList;
        }


        public static OccupationList GetAllOptions(OccupationList list)
        {
            OccupationList returnList = new OccupationList();

            for (int i = 0; i < list.Count; i++)
            {
                string[] multiOption;
                multiOption = list[i].Split('_');
                
                returnList.AddRange(multiOption);

                returnList = DeleteDoubles(returnList);
            }

            return returnList;
        }

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

        // Instansierar och sätter de initiala sträng-värdena på CurrentEquip
        public static void InitializeCurrentEquipVar()
        {
            if (CurrentEquip != null)
            CurrentEquip.Clear();

            CurrentEquip = new OccupationList() { "PATRONER: ", "KRUBB: ", "VATTEN: " };
        }

        // Slumpar fram värdena för utrustningen baserat på de värdena som är speciella för sysslan.
        // Simulerar tärningsslag med T6or
        public static void GetEquipment()
        {
            InitializeCurrentEquipVar();

            string[] gear = new string[3];
            gear = CurrentOccu[5].Split('_');

            // "Antalet tärningar" att kasta för varje sak
            int ammoInt = Convert.ToInt32(gear[0]);
            int foodInt = Convert.ToInt32(gear[1]);
            int waterInt = Convert.ToInt32(gear[1]);

            Random rnd = new Random();

            int ammoRes = 0;
            int foodRes = 0;
            int waterRes = 0;

            // "slår tärningar", T6or. ammoInt är antalet tärningar att kasta.
            for (int i = 0; i < ammoInt; i++)
            {
                ammoRes += rnd.Next(1, 7);
            }

            for (int i = 0; i < foodInt; i++)
            {
                foodRes += rnd.Next(1, 7);
            }

            for (int i = 0; i < waterInt; i++)
            {
                waterRes += rnd.Next(1, 7);
            }

            CurrentEquip[0] += ammoRes.ToString();
            CurrentEquip[1] += foodRes.ToString();
            CurrentEquip[2] += waterRes.ToString();
        }

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

        public static string ShowEquipmentDice(List<string> list, int index)
        {
            string ammo = "PATRONER: " + list[0] + "X1 T6. ";
            string food = "KRUBB: " + list[0] + "X1 T6. ";
            string water = "VATTEN: " + list[0] + "X1 T6. ";

            return ammo + food + water;
        }


    }

    public enum OccupationsEnum : int
    {
        KROSSARE,
        SKROTSKALLE,
        ZONSTRYKARE,
        FIXARE,
        MUTANTMEDHUND,
        KRÖNIKÖR,
        BOSS,
        SLAV

    }

}