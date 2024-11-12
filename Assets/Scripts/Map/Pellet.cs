using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;

    //protected so other classes can access. Virtual allows for override
    protected virtual void Collect()
    {
        FindObjectOfType<GameManager>().PelletCollected(this);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //check to ensure only prisoner collides with pellet
        if (other.gameObject.layer == LayerMask.NameToLayer("Prisoner"))
        {
            Collect();
        }
    }
}

