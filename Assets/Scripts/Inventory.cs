using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



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
    

    [SerializeField]private TMP_Text[] texts;
    
    private static Dictionary<itemType, int> inventory = new Dictionary<itemType, int>();
    public static Inventory self;

    private void Awake()
    {
        self = GetComponent<Inventory>();
        
    }

    private void Update()
    {
        texts[0].text = GetInventoryCount(itemType.ammo).ToString();
        texts[1].text = GetInventoryCount(itemType.crewPhoto).ToString();
        texts[2].text = GetInventoryCount(itemType.famPhoto).ToString();
        texts[3].text = GetInventoryCount(itemType.firstaid).ToString();
        texts[4].text = GetInventoryCount(itemType.keycard).ToString();
        texts[5].text = GetInventoryCount(itemType.goodmeal).ToString();
        texts[6].text = GetInventoryCount(itemType.snacks).ToString();
        texts[7].text = GetInventoryCount(itemType.syrette).ToString();

    }

    public Button[] buttons;

    private void Start()
    {
        player = PlayerManager.self;
        buttons[0].onClick.AddListener(() => UseItem(itemType.ammo));
        buttons[1].onClick.AddListener(() => UseItem(itemType.crewPhoto));
        buttons[2].onClick.AddListener(() => UseItem(itemType.famPhoto));
        buttons[3].onClick.AddListener(() => UseItem(itemType.firstaid));
        buttons[4].onClick.AddListener(() => UseItem(itemType.keycard));
        buttons[5].onClick.AddListener(() => UseItem(itemType.goodmeal));
        buttons[6].onClick.AddListener(() => UseItem(itemType.snacks));
        buttons[7].onClick.AddListener(() => UseItem(itemType.syrette));


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


    public void UseAmmo()
    {
        if (GetInventoryCount(itemType.ammo) <= 0)
        {
            return;
        }
        ModifyInventory(itemType.ammo, - 1);
        player.addBullets(1);
    }
    public void UseItem(itemType item )
    {
        if (GetInventoryCount(item) <=0)
        {
            return;
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

    }
}
