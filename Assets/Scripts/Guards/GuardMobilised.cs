using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMobilised : GuardBehaviour
{
    public SpriteRenderer Body;
    public SpriteRenderer Mobilised;
    public SpriteRenderer PostMobilisedGuard;
    //guard mobilised inherits guard behaviour -> Hence the override
    //It is also important to override the enable function in GuardBehaviour as if key is picked up whilst already in mobilised state, all the timings need to reset
    public override void Enable(float duration)
    {
        base.Enable(duration);
        this.Body.enabled = false;
        this.Mobilised.enabled = true;
        this.PostMobilisedGuard.enabled = false;
        FindObjectOfType<GameManager>().RemoveAllLives();
        Invoke(nameof(MobilisedSwitch), 6.0f);
    }

    public override void Disable()
    {
        base.Disable();
        this.Body.enabled = true;
        this.Mobilised.enabled = false;
        this.PostMobilisedGuard.enabled = false;
        FindObjectOfType<GameManager>().DeactivateMobilisedWarning();
    }

    private void MobilisedSwitch()
    {
        FindObjectOfType<GameManager>().RemoveAllLives();
        this.Mobilised.enabled = false;
        this.PostMobilisedGuard.enabled = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if (node != null && enabled)
        {
            //shortest direction
            Vector2 direction = Vector2.zero;
            //minimum distance
            float minDistance = float.MaxValue;

            //Looping through all available directions
            foreach (Vector2 availableDirection in node.availableDirections)
            {
                //position of guard if move into new position
                Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                //distance from position to target (player)
                float distance = (this.guard.target.position - newPosition).sqrMagnitude;

                //checking if the calculated distance is actually the shortest path.
                if (distance < minDistance)
                {
                    direction = availableDirection;
                    minDistance = distance;
                }
            }

            guard.movement.SetDirection(direction);
        }
    }

}
