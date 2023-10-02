using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Vector2 dir = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dir = collision.gameObject.GetComponent<PlayerMovement>().getDirection();
            Debug.Log(dir);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 exitDir = collision.gameObject.GetComponent<PlayerMovement>().getDirection();
            Debug.Log(exitDir);

            bool matchX = false;
            bool matchY = false;

            if (dir.x * exitDir.x >= 0)
            {
                matchX = true;
            }
            if (dir.y * exitDir.y >= 0)
            {
                matchY = true;
            }

            if (matchX && matchY)
            {
                transform.parent.gameObject.GetComponent<Room>().updateRoomState();
            }
        }
    }
}
