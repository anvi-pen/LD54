using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float xMove = 0;
    private float yMove = 0;

    private float speed = 5;

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private PlayerManager player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (new Vector3(xMove, yMove, 0)) * Time.deltaTime * speed;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        if (Mathf.Abs(movementVector.x) > Mathf.Abs(movementVector.y))
        {
            movementVector.y = 0;
        }
        else
        {
            movementVector.x = 0;
        }

        xMove = movementVector.x;
        yMove = movementVector.y;
    }

    private void OnShoot()
    {
        if (player.getBullets() > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Vector2 dirNorm = dir.normalized;
            bullet.GetComponent<Bullet>().setDir(dirNorm.x, dirNorm.y);
            player.addBullets(-1);
        }
        
    }

    public Vector2 getDirection()
    {
        return new Vector2(xMove, yMove);
    }
}
