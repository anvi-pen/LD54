using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float xMove = 0;
    private float yMove = 0;

    private float speed = 3;
    // private bool inventoryOpen = false;
    [SerializeField] GameObject bulletPrefab;
    private PlayerManager player;
    private Inventory inventory;
    private AllEnemiesManager enemies;
    private bool reloadDelay = false;

    private AudioSource audio;
    [SerializeField] AudioClip[] dryFire;
    [SerializeField] AudioClip shot;
    [SerializeField] AudioClip[] reloadCombat;
    [SerializeField] AudioClip[] reloadNotCombat;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.self;
        player = PlayerManager.self;
        enemies = GameObject.FindGameObjectWithTag("Enemy Manager").GetComponent<AllEnemiesManager>();

        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mouse - new Vector2(transform.position.x, transform.position.y);
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
            audio.Stop();
            audio.PlayOneShot(shot);
        }
        else
        {
            int randomNum = Random.Range(0, dryFire.Length);
            audio.Stop();
            audio.PlayOneShot(dryFire[randomNum]);
        }
    }

    private void OnReload()
    {
        if (reloadDelay)
            return;

        if (enemies.isPlayerInCombat())
        {
            int randomNum = Random.Range(0, reloadCombat.Length);
            audio.Stop();
            audio.PlayOneShot(reloadCombat[randomNum]);
        }
        else
        {
            int randomNum = Random.Range(0, reloadNotCombat.Length);
            audio.Stop();
            audio.PlayOneShot(reloadNotCombat[randomNum]);
        }

        Debug.Log("hello");
        Debug.Log(inventory.GetInventoryCount(Inventory.itemType.ammo));
        inventory.UseItem(Inventory.itemType.ammo);

        StartCoroutine(ReloadDelay());
    }

    public Vector2 getDirection()
    {
        return new Vector2(xMove, yMove);
    }

    IEnumerator ReloadDelay()
    {
        reloadDelay = true;
        yield return new WaitForSeconds(3);
        reloadDelay = false;
    }
}
