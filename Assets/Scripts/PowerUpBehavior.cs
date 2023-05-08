using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpBehavior : MonoBehaviour
{
    private static PowerUpBehavior Instance;
    public int PizzaCount;
    public int CoinCount;
   

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
        Debug.Log(" gone");
        if (other.gameObject.CompareTag("Player")&& this.gameObject.CompareTag("Coin"))
        {
            // Destroy the game object when it collides with the player
            CoinCount++;
            Destroy(this.gameObject);
            Debug.Log(CoinCount);
            PowerCountBehavior.Instance.CoinValue(CoinCount);



        }
        if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Pizza"))
        {
            // Destroy the game object when it collides with the player
            PizzaCount++;
            Destroy(this.gameObject);
            Debug.Log(PizzaCount);
            PowerCountBehavior.Instance.PizzaValue(PizzaCount);

        }
    }
}
