using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int playerHealth;

    private int playerBullets;

    [SerializeField] private int maxHealth;

    [SerializeField] private int maxBullet;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        playerBullets = maxBullet; //do we ant to start with full ammo or 0 ammo
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
    public void addHealth(int amt)
    {
        playerHealth += math.min(amt, maxHealth - playerHealth);
    }

    public void addBullets(int amt)
    {
        playerBullets += math.min(amt, maxBullet - playerBullets);
    }
}
