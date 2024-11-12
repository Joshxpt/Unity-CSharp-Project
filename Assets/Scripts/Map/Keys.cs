using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Keys inherits Pellet
public class Keys : Pellet
{
    protected override void Collect()
    {
        FindObjectOfType<GameManager>().KeyCollected(this);
    }
}
