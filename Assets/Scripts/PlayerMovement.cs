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
    // private bool inventoryOpen = false;
    [SerializeField] GameObject bulletPrefab;
    private PlayerManager player;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.self;
        player = PlayerManager.self;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (new Vector3(xMove, yMove, 0)) * Time.deltaTime * speed;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        xMove = movementVector.x;
        yMove = movementVector.y;
    }

    // private void OnInventory() // for when inventory was game object
    // {
    //     inventory.SetActive(!inventory.activeSelf);
    // }
    
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

    private void OnReload()
    {
        Debug.Log("hello");
        Debug.Log(inventory.GetInventoryCount(Inventory.itemType.ammo));
        inventory.UseItem(Inventory.itemType.ammo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        collidedObject = collision.gameObject;
        if (collision.gameObject.GetComponent<Item>() != null)
            onTriggerEnterItem = collision.gameObject.GetComponent<Item>().ItemName;

        Debug.Log("on trigger enter");
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.GetComponent<Item>() != null)
        {
            if (onTriggerEnterItem == collision.gameObject.GetComponent<Item>().ItemName)
            {
                collidedObject = null;
                onTriggerEnterItem = "";
            }
        }
        else
        {
            collidedObject = null;
            onTriggerEnterItem = "";
        }

        Debug.Log("on trigger exit");
        */
    }
}
