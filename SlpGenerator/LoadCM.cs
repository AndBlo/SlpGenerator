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
    partial class MainWindow
    {
        private void PopulatePointCM(Button targetBtn)
        {
            List<string> list = new List<string>
            {
                "0", "1", "2", "3", "4", "5"
            };

            Menus.SlpMenu.point = new DropMenu
                (list,
                new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                "Point",
                false);

            targetBtn.ContextMenu = Menus.SlpMenu.point as DropMenu;
        }

        private void PopulateEquipmentCM(Button targetBtn)
        {
            Menus.SlpMenu.equipment = new DropMenu
                            ("SPECIFIKT FÖR SYSSLA",
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Equipments",
                            true);
            Menus.SlpMenu.equipment.Items.Add(new DropItem() { Header = "VAPEN" });
            Menus.SlpMenu.equipment.Items.Add(new DropItem() { Header = "UTRUSTNING" });
            Menus.SlpMenu.equipment.Items.Add(new DropItem() { Header = "ARTEFAKT" });

            // Lägger till sysslor som submenyer i "SPECIFIKT FR SYSSLA"
            ((DropItem)Menus.SlpMenu.equipment.Items[4]).AddRange(Occupation.Occupations);

            // Lägger till submenyer för vapen, utrustning och artefakter i respektive syssla
            for (int i = 0; i < ((DropItem)Menus.SlpMenu.equipment.Items[4]).Items.Count; i++)
            {
                ((((DropItem)Menus.SlpMenu.equipment.Items[4]) as DropItem).Items[i] as DropItem).Items.Add(new DropItem() { Header = "VAPEN" });
                ((((DropItem)Menus.SlpMenu.equipment.Items[4]) as DropItem).Items[i] as DropItem).Items.Add(new DropItem() { Header = "UTRUSTNING" });

                // Lägger till artefakt som submeny hos skrotskalle
                if (i == 1)
                    ((((DropItem)Menus.SlpMenu.equipment.Items[4]) as DropItem).Items[1] as DropItem).Items.Add(new DropItem() { Header = "ARTEFAKT" });
            }

            // Lägger till items i respektive submeny i specifikt för syssla
            DropItem di = new DropItem();
            di = Menus.SlpMenu.equipment.Items[4] as DropItem;
            for (int i = 0; i < di.Items.Count; i++)
            {
                ((DropItem)((DropItem)di.Items[i]).Items[0]).AddRange(
                    Occupation.GetMultiOptions(
                        Occupation.SpecialWeapon[i]),
                    new RoutedEventHandler(
                        Menus.SlpMenu.SetTextFromContext));

                ((DropItem)((DropItem)di.Items[i]).Items[1]).AddItem(
                    Occupation.ShowEquipmentDice(
                        Occupation.GetMultiOptions(
                            Occupation.SpecialEquipment[i])),
                    new RoutedEventHandler(Menus.SlpMenu.SetEquipment));

                if (i == 1)
                {
                    ((DropItem)((DropItem)di.Items[i]).Items[2]).AddRange(
                        Artifact.Artifacts,
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));
                }

            }

            // Lägger till vapen items i Vapen-submenyn i första menyn.
            ((DropItem)Menus.SlpMenu.equipment.Items[5]).AddRange(
                Occupation.GetAllOptions(Occupation.SpecialWeapon),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));

            // Lägger till items i utrustning
            for (int i = 0; i < Occupation.SpecialEquipment.Count; i++)
            {
                ((DropItem)Menus.SlpMenu.equipment.Items[6]).
                    AddItem(
                Occupation.ShowEquipmentDice(
                    Occupation.GetMultiOptions(
                        Occupation.SpecialEquipment[i])),
                new RoutedEventHandler(Menus.SlpMenu.SetEquipment));
            }

            // Lägger till items i Artefakter
            ((DropItem)Menus.SlpMenu.equipment.Items[7]).AddRange(Artifact.Artifacts, new RoutedEventHandler(Menus.SlpMenu.SetArtifact));
            //((DropItem)Menus.SlpMenu.equipment.Items[7]).AddRange(Artifact.Artifacts, new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext));

            targetBtn.ContextMenu =
                Menus.SlpMenu.equipment;
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
            Menus.SlpMenu.talent = new DropMenu
                            (Occupation.Occupations,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Talents",
                            true);
            for (int i = 4; i < Menus.SlpMenu.trait.Items.Count; i++)
            {
                Menus.SlpMenu.talent.
                    AddItemsToSubMenu(Occupation.GetMultiOptions(Occupation.SpecialTalents[i - 4]),
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                    i);
            }
            targetBtn.ContextMenu = Menus.SlpMenu.talent;
        }

        private void PopulateSkillCM(Button targetBtn)
        {
            Menus.SlpMenu.skill = new DropMenu
                (TextFields.Skill.Skills,
                new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                "Skills",
                false);
            //Lägger till submenyn för sysslor
            Menus.SlpMenu.skill.AddSubMenu(4, "SPECIFIKT FÖR SYSSLA");
            // Lägger till sysslor i submenyn.
            Menus.SlpMenu.skill.
            AddItemsToSubMenu(Occupation.Occupations, 4);
            // Lägger till items i de olika sysslorna
            for (int i = 0; i < Occupation.Occupations.Count; i++)
            {
                Menus.SlpMenu.skill.
                    AddItemsToSubMenu(Occupation.SpecialSkills[i], new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext), 4, i);
            }
            // Lägger till DropMenu som ContextMenu.
            targetBtn.ContextMenu = Menus.SlpMenu.skill;
        }

        private void PopulateGoalCM(Button targetBtn)
        {
            Menus.SlpMenu.goal = new DropMenu
                (Occupation.Occupations,
                new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                "Goals",
                true);
            for (int i = 4; i < Menus.SlpMenu.goal.Items.Count; i++)
            {
                Menus.SlpMenu.goal.
                    AddItemsToSubMenu(Occupation.GetMultiOptions(Occupation.SpecialGoal[i - 4]),
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                    i);
            }
            targetBtn.ContextMenu = Menus.SlpMenu.goal;
        }

        private void PopulateTraitCM(Button targetBtn)
        {
            Menus.SlpMenu.trait = new DropMenu
                            (Occupation.Occupations,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Traits",
                            true);
            for (int i = 4; i < Menus.SlpMenu.trait.Items.Count; i++)
            {
                Menus.SlpMenu.trait.
                    AddItemsToSubMenu(Occupation.GetMultiOptions(Occupation.SpecialTrait[i - 4]),
                    new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                    i);
            }
            targetBtn.ContextMenu = Menus.SlpMenu.trait;
        }

        private void PopulateOccuCM(Button targetBtn)
        {
            Menus.SlpMenu.occupation = new DropMenu
                            (Occupation.Occupations,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Occupations",
                            false);
            targetBtn.ContextMenu = Menus.SlpMenu.occupation;
        }

        private void PopulateNameCM(Button targetBtn)
        {
            Menus.SlpMenu.name = new DropMenu
                            (MutantHumanName.Mutants,
                            new RoutedEventHandler(Menus.SlpMenu.GetRandom),
                            new RoutedEventHandler(Menus.SlpMenu.SetTextFromContext),
                            "Names",
                            false);
            targetBtn.ContextMenu =
                Menus.SlpMenu.name;
        }
    }
}
