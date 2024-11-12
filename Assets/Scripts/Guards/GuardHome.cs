using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHome : GuardBehaviour
{
    public Transform outside;

    //public override void Enable(float duration)
    //{
    //Invoke(nameof(Dequeue), duration);
    //}

    public override void HomeEnable(float HomeDuration)
    {
        Invoke(nameof(Dequeue), HomeDuration);
    }

    private void Dequeue()
    {
        //current position
        Vector3 position = transform.position;
        position.x = outside.position.x;
        position.y = outside.position.y;
        transform.position = position;

        //movement after released
        guard.movement.SetDirection(new Vector2(Random.value < 0.5f ? -1f : 1f, 0f), true);
        guard.movement.rigidbody.isKinematic = false;
        guard.movement.enabled = true;
        guard.nextBehaviour.Disable();
    }

}


