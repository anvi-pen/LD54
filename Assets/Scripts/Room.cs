using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Room : MonoBehaviour
{
    private List<GameObject> gates = new List<GameObject>();
    private bool playerInside = false;

    // Start is called before the first frame update
    void Start()
    {
        var children = GetComponentsInChildren<Transform>().Where(t => t != transform);
        foreach (Transform c in children)
        {
            gates.Add(c.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateRoomState()
    {
        playerInside = !playerInside;
    }

    public bool getPlayerInside()
    {
        return playerInside;
    }

    public int countOpenGates()
    {
        int open = 0;
        foreach (GameObject g in gates)
        {
            if (g.GetComponent<Gate>())
            {
                open++;
            }
        }
        return open;
    }
}
