using UnityEngine;
using Kryz.CharacterStats;

public enum EquipmentType{
    Helmet,
    Armor,
    Pants,
    Boots,
    Gloves,
    ShoulderPlate,
    Weapon,
    Shield,
    Utility,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
     public int StrengthBonus;
     public int DefenseBonus;
     public int AgilityBonus;
     [Space]
     public float StrengthPercentBonus;
     public float DefensePercentBonus;
     public float AgilityPercentBonus;
     [Space]
     public EquipmentType EquipmentType;

     public void Equip(Character c)
     {
        if(StrengthBonus !=0)
            c.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));
        if(DefenseBonus !=0)
            c.Defense.AddModifier(new StatModifier(DefenseBonus, StatModType.Flat, this));
        if(AgilityBonus !=0)
            c.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));

        if(StrengthPercentBonus !=0)
            c.Strength.AddModifier(new StatModifier(StrengthPercentBonus, StatModType.Flat, this));
        if(DefensePercentBonus !=0)
            c.Defense.AddModifier(new StatModifier(DefensePercentBonus, StatModType.Flat, this));
        if(AgilityPercentBonus !=0)
            c.Agility.AddModifier(new StatModifier(AgilityPercentBonus, StatModType.Flat, this));

     }

    public void Unequip(Character c)
     {
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Defense.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
     }

}
