using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRoaming : GuardBehaviour
{
    private void OnDisable()
    {
        guard.roam.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();
        
        //checks
        if (node != null && this.enabled && !this.guard.mobilised.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            //no backtracking
            if (node.availableDirections[index] == -this.guard.movement.direction && node.availableDirections.Count > 1)
            {
                index++;

                if (index >= node.availableDirections.Count)
                {
                    index = 0;
                }
            }

            this.guard.movement.SetDirection(node.availableDirections[index]);
        }
    }
}
