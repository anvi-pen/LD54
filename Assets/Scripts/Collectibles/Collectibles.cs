using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerManager player;
    [Serializable]public enum itemType
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

    [SerializeField] private itemType item;
    void Start()
    {
        player = PlayerManager.self;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            impactPlayer();
        }
        Destroy(gameObject);
    }

    private void impactPlayer()
    {
        switch (item)
        {
            case itemType.famPhoto:
                player.maxSanity += 1;
                break;
            case itemType.crewPhoto:
                player.addSanity(1);
                break;
            case itemType.snacks:
                player.addSanity(1);
                break;
            case itemType.goodmeal:
                player.maxSanity += 1;
                break;
            case itemType.firstaid:
                player.addHealth(1);
                break;
            case itemType.syrette:
                player.maxHealth += 1;
                break;
            case itemType.ammo:
                player.addBullets(1);
                break;
            //need to add someything for keycard
            
        }
    }
}
