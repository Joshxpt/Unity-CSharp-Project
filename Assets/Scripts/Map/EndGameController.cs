using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D colission)
    {
        FindObjectOfType<GameManager>().EnableLevelEndScreen(); 
    }
}
