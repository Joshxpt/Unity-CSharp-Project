using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageController : MonoBehaviour
{
    public Transform connection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //current position
        Vector3 position = other.transform.position;
        //changing position to connection point
        position.x = connection.position.x;
        position.y = connection.position.y;
        other.transform.position = position;
    }

}

