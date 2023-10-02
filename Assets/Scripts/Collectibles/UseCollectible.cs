using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    // private Inventory _inventory;
    // private PlayerManager player;
    // void Start()
    // {
    //     _inventory = Inventory.self;
    //     player = PlayerManager.self;
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UseItem(Inventory.itemType item )
    {
        
        // if (_inventory.GetInventoryCount(item) <=0)
        // {
        //     return;
        // }
        // switch (item)
        // {
        //     case Inventory.itemType.famPhoto:
        //         _inventory.ModifyInventory(Inventory.itemType.famPhoto, - 1);
        //         player.addSanity(player.maxSanity - player.getSanity());
        //         break;
        //     case Inventory.itemType.crewPhoto:
        //         _inventory.ModifyInventory(Inventory.itemType.crewPhoto, - 1);
        //         player.addSanity(1);
        //         break;
        //     case Inventory.itemType.snacks:
        //         _inventory.ModifyInventory(Inventory.itemType.snacks, - 1);
        //         player.addSanity(1);
        //         break;
        //     case Inventory.itemType.goodmeal:
        //         _inventory.ModifyInventory(Inventory.itemType.goodmeal, - 1);
        //         player.addSanity(player.maxSanity - player.getSanity());
        //         break;
        //     case Inventory.itemType.firstaid:
        //         _inventory.ModifyInventory(Inventory.itemType.firstaid, - 1);
        //         player.addHealth(1);
        //         break;
        //     case Inventory.itemType.syrette:
        //         _inventory.ModifyInventory(Inventory.itemType.syrette, - 1);
        //         player.addHealth(player.maxHealth - player.getHealth());
        //         break;
        //     case Inventory.itemType.ammo:
        //         _inventory.ModifyInventory(Inventory.itemType.ammo, - 1);
        //         player.addBullets(1);
        //         break;
        //     
        //     //need to add someything for keycard
        // }

    }
}
