using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    private int[] inventorySlots;
    private PlayerManager player;
    public enum itemType
    {
        crewPhoto,
        famPhoto,
        snacks,
        goodmeal,
        firstaid,
        syrette,
        ammo,
        keycard
        
    }
    private static Dictionary<itemType, int> inventory = new Dictionary<itemType, int>();
    public static Inventory self;

    private void Awake()
    {
        self = GetComponent<Inventory>();
        
    }

    private void Start()
    {
        player = PlayerManager.self;
    }

    public static int ModifyInventory(itemType item, int amount) {
        if (!inventory.ContainsKey(item))
            inventory[item] = 0;
        if (inventory[item] <= 0 && amount < 0)
        {
            return -1;
        }
        inventory[item] += amount;
        return inventory[item];
    }

    public void AddItem(itemType item)
    {
        ModifyInventory(item, 1);
        if (item == itemType.keycard && inventory[item] >= 3)
        {
            player.setHasKeys();
        }
    }
    public int GetInventoryCount(itemType item)
    {
        return inventory.ContainsKey(item) ? inventory[item] : 0;
    }

    //start(): set all inventoryslots to -1

    public bool UseItem(itemType item )
    {
        if (GetInventoryCount(item) <=0)
        {
            return false;
        }
        switch (item)
        {
            case itemType.famPhoto:
                ModifyInventory(itemType.famPhoto, - 1);
                player.addSanity(player.maxSanity - player.getSanity());
                break;
            case itemType.crewPhoto:
                ModifyInventory(itemType.crewPhoto, - 1);
                player.addSanity(1);
                break;
            case itemType.snacks:
                ModifyInventory(itemType.snacks, - 1);
                player.addSanity(1);
                break;
            case itemType.goodmeal:
                ModifyInventory(itemType.goodmeal, - 1);
                player.addSanity(player.maxSanity - player.getSanity());
                break;
            case itemType.firstaid:
                ModifyInventory(itemType.firstaid, - 1);
                player.addHealth(1);
                break;
            case itemType.syrette:
                ModifyInventory(itemType.syrette, - 1);
                player.addHealth(player.maxHealth - player.getHealth());
                break;
            case itemType.ammo:
                ModifyInventory(itemType.ammo, - 1);
                player.addBullets(1);
                break;
            
            //need to add someything for keycard
            
        }

        return true;
    }
}
