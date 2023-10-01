using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int playerHealth;

    private int playerSanity;
    private int playerBullets;

    public int maxHealth;
    public int maxSanity;
    public int maxBullet;
    [SerializeField] private Canvas canvas;

    private TMP_Text Health_text;
    private TMP_Text Sanity_text;
    private TMP_Text Bullet_text;

    private void Awake()
    {
        Health_text = canvas.transform.GetChild(0).GetComponent<TMP_Text>();
        Sanity_text = canvas.transform.GetChild(2).GetComponent<TMP_Text>();
        Bullet_text = canvas.transform.GetChild(1).GetComponent<TMP_Text>();


    }
    // Start is called before the first frame update
    
    void Start()
    {
        playerHealth = maxHealth;
        playerBullets = maxBullet; //do we ant to start with full ammo or 0 ammo
        playerSanity = 5;
        
        Bullet_text.text = "Bullet: " + playerBullets;
        Sanity_text.text = "Sanity: " + playerSanity;
        Health_text.text = "Health: " + playerHealth;

    }
    // Update is called once per frame
    void Update()
    {
    }

    public int getBullets()
    {
        return playerBullets;
    }
    

    public int getHealth()
    {
        return playerHealth;
    }

    public int getSanity()
    {
        return playerSanity;
    }
    public void addHealth(int amt)
    {
        playerHealth += math.min(amt, maxHealth - playerHealth);
        Health_text.text = "Health: " + playerHealth;
    }

    public void addBullets(int amt)
    {
        playerBullets += math.min(amt, maxBullet - playerBullets);
        Bullet_text.text = "Bullet: " + playerBullets;
    }

    public void addSanity(int amt)
    {
        playerSanity += math.min(amt, maxSanity-playerSanity );
        Sanity_text.text = "Sanity: " + playerSanity;
    }
}
