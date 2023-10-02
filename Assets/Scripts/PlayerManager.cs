using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool hasKeys  = false;
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
    public static PlayerManager self;

    private AudioSource audio;
    [SerializeField] AudioClip[] playerInjured;
    [SerializeField] AudioClip[] dead;

    private void Awake()
    {
        Health_text = canvas.transform.GetChild(0).GetComponent<TMP_Text>();
        Sanity_text = canvas.transform.GetChild(2).GetComponent<TMP_Text>();
        Bullet_text = canvas.transform.GetChild(1).GetComponent<TMP_Text>();
        self = GetComponent<PlayerManager>();

        audio = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    
    void Start()
    {
        playerHealth = maxHealth;
        playerBullets = maxBullet; //do we ant to start with full ammo or 0 ammo
        playerSanity = maxSanity;
        
        Bullet_text.text = "Bullet: " + playerBullets;
        Sanity_text.text = "Sanity: " + playerSanity;
        Health_text.text = "Health: " + playerHealth;
    }
    // Update is called once per frame
    public void setHasKeys()
    {
        hasKeys = true;
    }

    public bool unlockGate()
    {
        return hasKeys;
    }
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
        if (playerHealth == 0)
            return;

        if (amt < 0)
        {
            int randomNum = UnityEngine.Random.Range(0, playerInjured.Length);
            audio.Stop();
            audio.PlayOneShot(playerInjured[randomNum]);
        }

        playerHealth += math.min(amt, maxHealth - playerHealth);
        Health_text.text = "Health: " + playerHealth;

        if (playerHealth == 0)
        {
            int random = UnityEngine.Random.Range(0, dead.Length);
            audio.Stop();
            audio.PlayOneShot(dead[random]);
        }
    }

    public void addBullets(int amt)
    {
        playerBullets += math.min(amt, maxBullet - playerBullets);
        Bullet_text.text = "Bullet: " + playerBullets;
    }

    public void addSanity(int amt)
    {
        if (playerSanity == 0)
            return;

        playerSanity += math.min(amt, maxSanity-playerSanity );
        Sanity_text.text = "Sanity: " + playerSanity;

        GameObject.FindWithTag("Enemy Manager").GetComponent<AllEnemiesManager>().adjustStats(playerSanity);
    }
}
