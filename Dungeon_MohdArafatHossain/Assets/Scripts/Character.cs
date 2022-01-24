using UnityEngine;
using Kryz.CharacterStats;
using Invector.vCharacterController;
//using System.Collections;

public class Character : MonoBehaviour
{
    public CharacterStat Strength;
    public CharacterStat Defense;
    public CharacterStat Agility;

    GameObject tpcGameObject;

    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatPanel statPanel;

    public void Awake()
    {
        statPanel.SetStats(Strength, Defense, Agility);
        statPanel.UpdateStatValues();

        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;

        
    }

    private void EquipFromInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem)item);
        }
        

        else if(item.ItemName == "HealthPotion")
        {
            inventory.RemoveItem(item);
            tpcGameObject = GameObject.Find("vMeleeController_PlayerBodyMesh");
            tpcGameObject.GetComponent<vThirdPersonController>().currentHealth = 100;
        }

    }

    private void UnequipFromEquipPanel(Item item)
    {
        if(item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }

    public void Equip(EquippableItem item)
    {
        if(inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if(previousItem != null)
                {
                    inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                statPanel.UpdateStatValues();
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            statPanel.UpdateStatValues();
            inventory.AddItem(item);
        }
    }
    
}
