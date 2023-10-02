using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    private Inventory _inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        _inventory = Inventory.self;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Debug.Log(_inventory.GetInventoryCount(Inventory.itemType.keycard));
            if (_inventory.GetInventoryCount(Inventory.itemType.keycard) >= 3)
            {
                SceneManager.LoadScene("Mission Complete");
            }
        }
    }
}
