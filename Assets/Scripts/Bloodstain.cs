using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodstain : MonoBehaviour
{
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
        GameObject ob = collision.gameObject;
        if (ob.tag == "Player")
        {
            ob.GetComponent<PlayerManager>().addSanity(-1);
        }
    }
}