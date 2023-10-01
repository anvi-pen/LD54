using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{ 
    private int maxDamage;
    private int damage;
    private int power;

    // Start is called before the first frame update
    void Start()
    {
        maxDamage = 1;
        damage = 0;
        power = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        damage++;
        if (damage == maxDamage)
        {
            Destroy(gameObject);
        }
    }

    public void adjustMaxDamage(int max)
    {
        maxDamage = max;
    }

    public void adjustPower(int p)
    {
        power = p;
        gameObject.GetComponent<EnemyMovement>().adjustPower(p);
    }

    public int getPower()
    {
        return power;
    }
}
