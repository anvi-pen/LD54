using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PicFrame : Collectibles
{
    // Start is called before the first frame update
    [SerializeField] private PlayerManager player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void impactPlayer()
    {
        player.addSanity(1);
        Destroy(gameObject);
    }
}
