using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject bloodstain;

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
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        damage++;
        Instantiate(bloodstain, transform.position, Quaternion.identity);
        GetComponent<EnemyMovement>().slowDown();
        if (damage == maxDamage)
        {
            // Destroy(gameObject);
            StartCoroutine(dead());
        }
    }

    public void adjustMaxDamage(int max)
    {
        maxDamage = max;
        Debug.Log("maxDamage: " + maxDamage);
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

    private void disable()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void enable()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<EnemyMovement>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator dead()
    {
        disable();
        yield return new WaitForSeconds(5);
        enable();
        damage = 0;
    }
}
