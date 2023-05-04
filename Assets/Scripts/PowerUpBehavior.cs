using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    private static PowerUpBehavior Instance;
    //private void Awake()
    //{

    //    // Singleton pattern
    //    if (Instance != null && Instance != this)
    //    {
    //        Destroy(this);
    //    }
    //    else
    //    {
    //        Instance = this;
    //    }

    //}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("coin gone");
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy the game object when it collides with the player
           
            Destroy(this.gameObject);
        }
    }
}
