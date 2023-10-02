using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDead : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] AudioClip[] dead;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        int random = Random.Range(0, dead.Length);
        audio.Stop();
        audio.PlayOneShot(dead[random]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
