using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerManager player;
    private Inventory inventory;
    public float spawnChance;

    [SerializeField] private Inventory.itemType item;
    void Start()
    {
        player = PlayerManager.self;
        inventory = Inventory.self;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
            inventory.AddItem(item);
            Destroy(gameObject);
        }
        
    }
    
}
