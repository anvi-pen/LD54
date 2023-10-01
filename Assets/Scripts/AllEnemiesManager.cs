using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AllEnemiesManager : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        var children = GetComponentsInChildren<Transform>().Where(t => t != transform);
        foreach (Transform c in children) 
        {
            enemies.Add(c.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void adjustStats(int playerSanity)
    {
        int damageWithstand = 0;
        int power = 0;
        switch (playerSanity)
        {
            case 3:
                damageWithstand = 1;
                power = 1;
                break;
            case 2:
                damageWithstand = 2;
                power = 1;
                break;
            case 1:
                damageWithstand = 3;
                power = 1;
                break;
            case 0:
                damageWithstand = 4;
                power = 2;
                break;
        }
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyManager>().adjustMaxDamage(damageWithstand);
            enemy.GetComponent<EnemyManager>().adjustPower(power);
        }
    }
}
