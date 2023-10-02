using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GateManager : MonoBehaviour
{
    [SerializeField] float waitTime;
    private List<GameObject> rooms = new List<GameObject>();
    // private List<GameObject> gates = new List<GameObject>();
    private bool waiting = true;

    // Start is called before the first frame update
    void Start()
    {
        var children = GetComponentsInChildren<Transform>().Where(t => t != transform);
        foreach (Transform c in children)
        {
            if (c.GetComponent<Room>())
            {
                rooms.Add(c.gameObject);
            }
            else if (c.GetComponent<Gate>())
            {
                c.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                c.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                // gates.Add(c.gameObject);
            }
        }

        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            enableAtRandom();
            StartCoroutine(wait());
        }
    }

    private void enableAtRandom()
    {
        // first select a room at random
        int randomNum = Random.Range(0, rooms.Count);
        GameObject chosenRoom = rooms[randomNum];

        // check if player is inside the chosen room
        // and if the room only has one open gate
        if (chosenRoom.GetComponent<Room>().getPlayerInside()
            && (chosenRoom.GetComponent<Room>().countOpenGates() == 1))
        {
            // if this is the only room with an open gate, don't close gate
            if (rooms.Count == 1)
                return;

            // chose another room to close the gate of
            rooms.RemoveAt(randomNum);
            randomNum = Random.Range(0, rooms.Count);
            rooms.Add(chosenRoom);
            chosenRoom = rooms[randomNum];
        }

        // get all of the gates of the chosen room
        var children = chosenRoom.GetComponentsInChildren<Transform>().Where(t => t != transform);
        List<GameObject> gates = new List<GameObject>();
        foreach (Transform c in children)
        {
            if (c.GetComponent<Gate>())
                gates.Add(c.gameObject);
        }

        // then select a gate associated with that room at random
        int random = Random.Range(0, gates.Count);
        GameObject chosen = gates[random];

        // close gate
        chosen.GetComponent<SpriteRenderer>().enabled = true;
        chosen.GetComponent<BoxCollider2D>().isTrigger = false;
        Destroy(chosen.GetComponent<Gate>());
        gates.RemoveAt(random);

        if (gates.Count == 0)
        {
            rooms.RemoveAt(randomNum);
            Destroy(chosenRoom.GetComponent<Room>());
        }

        if (rooms.Count == 0)
        {
            Destroy(this);
        }
    }

    IEnumerator wait()
    {
        waiting = true;
        yield return new WaitForSeconds(waitTime);
        waiting = false;
    }
}
