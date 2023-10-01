using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicFam : Collectibles // add sanity to max
{

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
        player.addSanity(player.maxSanity  - player.getSanity());
        Destroy(gameObject);
    }
}
