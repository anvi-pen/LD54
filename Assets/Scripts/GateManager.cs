using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GateManager : MonoBehaviour
{
    [SerializeField] float waitTime;
    private List<GameObject> gates = new List<GameObject>();
    private bool waiting = true;

    // Start is called before the first frame update
    void Start()
    {
        var children = GetComponentsInChildren<Transform>().Where(t => t != transform);
        foreach (Transform c in children)
        {
            // c.gameObject.SetActive(false);
            c.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            c.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gates.Add(c.gameObject);
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
        int random = Random.Range(0, gates.Count);
        // gates[random].SetActive(true);
        GameObject chosen = gates[random];
        if (chosen.GetComponent<Gate>().getDelayClose())
        {
            if (gates.Count == 1)
            {
                return;
            }
            gates.RemoveAt(random);
            random = Random.Range(0, gates.Count);
            gates.Add(chosen);
            chosen = gates[random];
        }
        chosen.GetComponent<SpriteRenderer>().enabled = true;
        chosen.GetComponent<BoxCollider2D>().isTrigger = false;
        gates.RemoveAt(random);

        if (gates.Count == 0)
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
