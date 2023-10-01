using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PicCrew : Collectibles // +1 sanity
{
    protected PlayerManager player;

    // Start is called before the first frame update
    
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
