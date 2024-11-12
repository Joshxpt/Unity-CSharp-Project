using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerup : MonoBehaviour
{
    //protected so other classes can access. Virtual allows for override
    protected virtual void CollectHeart()
    {
        FindObjectOfType<GameManager>().HeartPowerup(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //check to ensure only prisoner collides with heart
        if (other.gameObject.layer == LayerMask.NameToLayer("Prisoner"))
        {
            CollectHeart();
        }
    }

}
