using SlpGenerator.Occupations;
using SlpGenerator.TextFields;
using SlpGenerator.TextFields.Menus.DropItem;
using SlpGenerator.TextFields.Menus.MenuList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SlpGenerator
{
    partial class SlpWindow
    {
        private void PopulatePointCM(Button targetBtn)
        {
            List<string> list = new List<string>
            {
                "0", "1", "2", "3", "4", "5", "6", "7", "8"
            };

            DropMenu point = new DropMenu
                (list,
                new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                "Point",
                false);

            Menus.SlpMenu.point = point;
            targetBtn.ContextMenu = Menus.SlpMenu.point as DropMenu;
        }


        private void PopulateEquipmentCM(Button targetBtn)
        {
            DropMenu equipment = new DropMenu
                            ("SPECIFIKT FÖR SYSSLA",
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Equipments",
                            true);

            AddMainEquipmentMenus(equipment);

            AddSpecificOccupationMenus(equipment.GetItem("SPECIFIKT FÖR SYSSLA"));

            foreach (var occupation in Occupation.Occupations)
            {
                AddEquipmentItemsForSpecificOccupations(equipment.GetItem("SPECIFIKT FÖR SYSSLA").GetItem(occupation.Name));
            }

            foreach (var occupation in Occupation.Occupations)
            {
                AddItemsToSpecificEquipmentMenus(equipment.GetItem("SPECIFIKT FÖR SYSSLA").GetItem(occupation.Name).GetItem("VAPEN"), occupation);
                AddItemsToSpecificEquipmentMenus(equipment.GetItem("SPECIFIKT FÖR SYSSLA").GetItem(occupation.Name).GetItem("UTRUSTNING"), occupation);
                if (occupation.HasArtifactItem)
                {
                    AddItemsToSpecificEquipmentMenus(equipment.GetItem("SPECIFIKT FÖR SYSSLA").GetItem(occupation.Name).GetItem("ARTEFAKT"), occupation);
                }
                if (occupation.HasGarbageItem)
                {
                    AddItemsToSpecificEquipmentMenus(equipment.GetItem("SPECIFIKT FÖR SYSSLA").GetItem(occupation.Name).GetItem("SKROT"), occupation);
                }

            }

            AddWeaponItemsToMainEquipmentMenus(equipment.GetItem("VAPEN"));

            AddSpecialEquipmentItemsToMainEquipmentMenus(equipment.GetItem("UTRUSTNING"));

            AddArtifactItemsToMainEquipmentMenus(equipment.GetItem("ARTEFAKT"));

            AddGarbageItemsToMainEquipmentMenus(equipment.GetItem("SKROT"));

            Menus.SlpMenu.equipment = equipment;

            targetBtn.ContextMenu =
                Menus.SlpMenu.equipment;
        }

        private static void AddGarbageItemsToMainEquipmentMenus(DropItem mainGarbageMenu)
        {
            mainGarbageMenu.AddRange(Garbage.Garbages, new RoutedEventHandler(Menus.SlpMenu.SetStuff));
        }

        private static void AddArtifactItemsToMainEquipmentMenus(DropItem mainArtifactMenu)
        {
            mainArtifactMenu.AddRange(Artifact.Artifacts, new RoutedEventHandler(Menus.SlpMenu.SetStuff));
        }

        private static void AddSpecialEquipmentItemsToMainEquipmentMenus(DropItem mainEquipmentMenu)
        {
            foreach (var occupation in Occupation.Occupations)
            {
                mainEquipmentMenu.
                    AddItem(
                    occupation.GetEquipmentString(),
                new RoutedEventHandler(Menus.SlpMenu.SetEquipment));
            }
        }

        private static void AddWeaponItemsToMainEquipmentMenus(DropItem weaponsMenu)
        {
            foreach (var occupation in Occupation.Occupations)
            {
                weaponsMenu.AddRange(
                occupation.Weapons.ToList(),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));
            }
            
                
        }

        private static void AddItemsToSpecificEquipmentMenus(DropItem specificEquipmentMenu, Occupation occupation)
        {
            if (specificEquipmentMenu.Header as string == "VAPEN")
            {
                    specificEquipmentMenu.AddRange(
                        occupation.Weapons.ToList(),
                        new RoutedEventHandler(
                            Menus.SlpMenu.SetTextFromContext));
            }

            else if (specificEquipmentMenu.Header as string == "UTRUSTNING")
            {
                specificEquipmentMenu.AddItem(
                    occupation.GetEquipmentString(),
                    new RoutedEventHandler(Menus.SlpMenu.SetEquipment));
            }

            else if (specificEquipmentMenu.Header as string == "ARTEFAKT")
            {
                specificEquipmentMenu.AddRange(
                    Artifact.Artifacts,
                new RoutedEventHandler(Menus.SlpMenu.SetStuff));
            }
        }

        private static void AddEquipmentItemsForSpecificOccupations(DropItem occupationMenu)
        {
            occupationMenu.Items.Add(new DropItem() { Header = "VAPEN" });
            occupationMenu.Items.Add(new DropItem() { Header = "UTRUSTNING" });

            if((Occupation.Occupations.Find(p => (p.Name == (string)occupationMenu.Header)).HasArtifactItem))
            {
                occupationMenu.Items.Add(new DropItem() { Header = "ARTEFAKT" });
            }
            if ((Occupation.Occupations.Find(p => (p.Name == (string)occupationMenu.Header)).HasGarbageItem))
            {
                occupationMenu.Items.Add(new DropItem() { Header = "SKROT" });
            }

        }

        private static void AddSpecificOccupationMenus(DropItem specificMenu)
        {

            foreach (var occupation in Occupation.Occupations)
            {
                specificMenu.AddItem(occupation.Name);
            }
        }

        private static void AddMainEquipmentMenus(DropMenu equipment)
        {
            equipment.Items.Add(new DropItem() { Header = "VAPEN" });
            equipment.Items.Add(new DropItem() { Header = "UTRUSTNING" });
            equipment.Items.Add(new DropItem() { Header = "ARTEFAKT" });
            equipment.Items.Add(new DropItem() { Header = "SKROT" });
        }

        private void PopulateMutationCM(Button targetBtn)
        {
            Menus.SlpMenu.mutation = new DropMenu
                            (Mutation.Mutations,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Mutations",
                            false);
            targetBtn.ContextMenu =
                Menus.SlpMenu.mutation;
        }

        private void PopulateTalentCM(Button targetBtn)
        {
            DropMenu talent = new DropMenu(
                            Occupation.Occupations.Select(n => n.Name).ToList<string>(),
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Talents",
                            true);
            
            
            foreach (var occupation in Occupation.Occupations)
            {
                AddTalentItemsToSpecificOccupation(talent.GetItem(occupation.Name), occupation);
            }

            Menus.SlpMenu.talent = talent;
            targetBtn.ContextMenu = Menus.SlpMenu.talent;
        }

        private static void AddTalentItemsToSpecificOccupation(DropItem specificOccupationMenu, Occupation occupation)
        {
                specificOccupationMenu.AddRange(occupation.Talents.ToList(), Menus.SlpMenu.SetTextFromContext);
        }

        private void PopulateSkillCM(Button targetBtn)
        {
            DropMenu skill = new DropMenu
                            ("SPECIFIKT FÖR SYSSLA",
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Skills",
                            true);

            AddSpecificOccupationMenus(skill.GetItem("SPECIFIKT FÖR SYSSLA"));

            foreach (var occupation in Occupation.Occupations)
            {
                AddSkillItemsToSpecificOccupationMenu(skill.GetItem("SPECIFIKT FÖR SYSSLA").GetItem(occupation.Name), occupation);
            }

            skill.AddItems(TextFields.Skill.Skills, new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));

            Menus.SlpMenu.skill = skill;
            targetBtn.ContextMenu = Menus.SlpMenu.skill;
        }

        private static void AddSkillItemsToSpecificOccupationMenu(DropItem specificOccupationMenu, Occupation occupation)
        {
            specificOccupationMenu.AddRange(occupation.Skills.ToList(), new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));
        }

        private void PopulateGoalCM(Button targetBtn)
        {
            DropMenu goal = new DropMenu
                (Occupation.Occupations.Select(p => p.Name).ToList<string>(),
                new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                "Goals",
                true);

            foreach (var occupation in Occupation.Occupations)
            {
                AddGoalItemsToOccupations(goal.GetItem(occupation.Name), occupation);
            }

            Menus.SlpMenu.goal = goal;
            targetBtn.ContextMenu = Menus.SlpMenu.goal;
        }

        private void AddGoalItemsToOccupations(DropItem occupationMenu, Occupation occupation)
        {
            occupationMenu.AddRange(occupation.Goals.ToList(), new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));
        }

        private void PopulateTraitCM(Button targetBtn)
        {
            DropMenu trait = new DropMenu
                            (Occupation.Occupations.Select(p => p.Name).ToList<string>(),
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Traits",
                            true);

            foreach (var occupation in Occupation.Occupations)
            {
                AddTraitItemsToOccupations(trait.GetItem(occupation.Name), occupation);
            }

            Menus.SlpMenu.trait = trait;
            targetBtn.ContextMenu = Menus.SlpMenu.trait;
        }

        private void AddTraitItemsToOccupations(DropItem occupationMenu, Occupation occupation)
        {
            occupationMenu.AddRange(occupation.Traits.ToList(), new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));
        }

        private void PopulateOccuCM(Button targetBtn)
        {
            DropMenu occupation = new DropMenu
                            (Occupation.Occupations.Select(p => p.Name).ToList<string>(),
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Occupations",
                            false);

            Menus.SlpMenu.occupation = occupation;
            targetBtn.ContextMenu = Menus.SlpMenu.occupation;
        }

        private void PopulateNameCM(Button targetBtn)
        {
            DropMenu name = new DropMenu
                            (MutantHumanName.Mutants,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Names",
                            false);

            Menus.SlpMenu.name = name;
            targetBtn.ContextMenu =
                Menus.SlpMenu.name;
        }
    }
}
