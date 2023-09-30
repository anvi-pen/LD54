using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.7f;
    [SerializeField] float speedFollow = 4.0f;
    private Vector2 positionA;
    private Vector2 positionB;
    private GameObject player;
    private bool follow = false;
    private bool continueOsc = true;
    private float timeProgress = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        positionA = transform.position;
        positionB = new Vector2(transform.position.x + 7, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = player.transform.position;
        if (Vector2.Distance(transform.position, playerPos) < 3f)
        {
            follow = true;
            continueOsc = false;
        }
        else
        {
            if (follow)
            {
                follow = false;
                //positionA = new Vector2(transform.position.x - 3.5f, transform.position.y);
                //positionB = new Vector2(transform.position.x + 3.5f, transform.position.y);
            }
        }

        if (!continueOsc && !follow)
        {
            Vector3 dir = new Vector3(positionA.x, positionA.y, transform.position.z) - transform.position;
            transform.position += dir.normalized * speedFollow * Time.deltaTime;
            if (Vector2.Distance(positionA, transform.position) < 0.2f)
            {
                timeProgress = 0;
                continueOsc = true;
            }
        }
        else if (continueOsc && !follow)
        {
            timeProgress += Time.deltaTime;
            float time = Mathf.PingPong(timeProgress * speed, 1);
            transform.position = Vector2.Lerp(positionA, positionB, time);
        }
        else
        {
            // transform.LookAt(player.transform);
            Vector2 dir = player.transform.position - transform.position;
            Vector3 dir3D = new Vector3(dir.x, dir.y, transform.position.z);
            transform.position += dir3D.normalized * speedFollow * Time.deltaTime;
        }
    }
}
