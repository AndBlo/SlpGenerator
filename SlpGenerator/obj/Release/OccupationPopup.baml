   M S B A M L   `   `   `  ���� G  CSlpGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SlpGeneratorSlpGenerator  "    SlpGenerator.OccupationPopup   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:SlpGenerator       � Title$  OccupationPopup��$	��430��$	��500��
�������.���  � RowDefinitions �� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 � � ColumnDefinitions �� $
��143* ��� $
��112* ��� $	��50* ��� $
��124* ��� $	��50* �.+�� $��0��$��0��$��5�� �� $	��22* ��� $��9* � �� $	��40* ��� $	��40* ��� $	��40* �.+��� -   $��btnNewOccupation��$
��Nytt��$��0��$��0���� -   $��btnSaveOccupation��$��Spara��$��1��$��0���� -   $��btnOpenOccupation��$��Öppna��$��3��$��0���� $
��Namn��$��0��$��1��
��������� -   $��tbName��$��1��$��1���� $��Kännetecken��$��0��$��2���� -   $��tbTraits��$��1��$��2���� -   $��cbTraits��$��3��$��2���� -   $��btnAddTrait��$��
Lägg till��$��2��$��2���� -   $��btnRemoveTrait��$��Ta Bort��$��4��$��2���� $
��Mål��$��0��$��3���� -	   $��tbGoals��$��1��$��3���� -
   $��cbGoals��$��3��$��3���� -   $��
btnAddGoal��$��
Lägg till��$��2��$��3���� -   $��btnRemoveGoal��$��Ta Bort��$��4��$��3���� $��Speciell Grundegenskap��$��0��$��4���� -   $��cbSpecialBP��$��1��$��4��.@��� $��Styrka��
 J� Uid$ 0���� $
��Kyla��$ 1���� $��Skärpa��$ 2���� $��Känsla��$ 3���� $��Speciell Färdighet��$��0��$��5���� -   $��tbSpecialSkills��$��1��$��5���� -   $��cbSpecialSkills��$��3��$��5���� -   $��btnAddSkill��$��
Lägg till��$��2��$��5���� -   $��btnRemoveSkill��$��Ta Bort��$��4��$��5���� $��
Talang(er)��$��0��$��6���� -   $��	tbTalents��$��1��$��6���� -   $��	cbTalents��$��3��$��6���� -   $��btnAddTalent��$��
Lägg till��$��2��$��6���� -   $��btnRemoveTalent��$��Ta Bort��$��4��$��6���� $��Vapen��$��0��$��7���� -   $��	tbWeapons��$��1��$��7���� -   $��	cbWeapons��$��3��$��7���� -   $��btnAddWeapon��$��
Lägg till��$��2��$��7���� -   $��btnRemoveWeapon��$��Ta Bort��$��4��$��7���� $��Patroner��$��0��$��8����  �� Orientation$ 
Horizontal=�$��1��$��8��.+��� $��Antal T6���� -   $��cbT6Ammo��.@��� $��0�� �� 
IsSelected . �� $��1���� $��2���� $��3���� $��4���� $��5���� $��6���� $��7���� $��8���� $��9���� $��10���� $��Krubb��$��0��$��9���� $ 
Horizontal=�$��1��$��9��.+��� $��Antal T6���� -   $��cbT6Food��.@��� $��0�� . �� $��1���� $��2���� $��3���� $��4���� $��5���� $��6���� $��7���� $��8���� $��9���� $��10���� $��Vatten��$��0��$��10���� $ 
Horizontal=�$��1��$��10��.+��� $��Antal T6���� -   $��	cbT6Water��.@��� $��0�� . �� $��1���� $��2���� $��3���� $��4���� $��5���� $��6���� $��7���� $��8���� $��9���� $��10���� $��Artefakt��$��0��$��11���� $ 
Horizontal=�$��1��$��11��.+�	� -   $��rbArtifactYes�� 	� 	GroupName$ artefact��$��Ja��$��Center=�$��5q�	� -   $��rbArtifactNo��$ artefact��$	��Nej��$��Center=�$��5q� d� 	IsChecked$
 TrueY��� $��Skrot��$��0��$��12���� $ 
Horizontal=�$��1��$��12��.+�	� -   $��rbGarbageYes��$ garbage��$��Ja��$��Center=�$��5q�	� -    $��rbGarbageNo��$ garbage��$	��Nej��$��Center=�$��5q�$
 TrueY�