using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float vel = 0.01f;
    private float xVel;
    private float yVel;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xVel * vel, yVel * vel);
    }

    public void setDir(float xDir, float yDir)
    {
        xVel = xDir;
        yVel = yDir;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject ob = collision.gameObject;
        if (collision.gameObject.tag == "Enemy")
        {
            ob.GetComponent<EnemyManager>().takeDamage();
        }
        Destroy(gameObject);
    }
}
